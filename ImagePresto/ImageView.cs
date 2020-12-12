using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePresto
{
    struct BitmapItem
    {
        public ImageSizeItem img;
        public Rectangle rect;
    }

    public partial class ImageView : Form
    {
        private const int WM_NCHITTEST = 0x84;
        private const int HTTRANSPARENT = 0x84;

        readonly IPConfig config;
        readonly List<ImageSizeItem> images= new List<ImageSizeItem>();
        readonly Random rnd = new Random();

        public float Aspect { get { return (float)ClientSize.Width / ClientSize.Height; } }

        private int imgCount = 1;
        private Bitmap BGImage = null;

        public ImageView()
        {
            InitializeComponent();
            config = IPConfig.GetConfig();
            this.ShowInTaskbar = config.ShowInTaskbar;
        }

        private void ImageView_Load(object sender, EventArgs e)
        {
            List<ImageSize> imglist;
            imglist = JsonConvert.DeserializeObject<List<ImageSize>>(File.ReadAllText(config.FileList));
            foreach(var img in imglist)
            {
                images.Add(new ImageSizeItem(img));
            }
            images.Sort();
        }

        private void GenerateNewBG()
        {
            Bitmap newBG = new Bitmap(ClientSize.Width, ClientSize.Height);
            var b1 = NewBG(Width, Height / 2);
            var b2 = NewBG(Width, Height / 2);
            using (var g = Graphics.FromImage(newBG))
            {
                g.DrawImage(b1, 0, 0);
                g.DrawImage(b2, 0, Height / 2);
            }
            Bitmap old = BGImage;
            BGImage = newBG;
            old?.Dispose();
            Invalidate();

        }

        private void ImageView_Click(object sender, EventArgs e)
        {
            GenerateNewBG();
        }

        private Bitmap NewBG(int Width,int Height)
        {
            float minAspect = 1.7f;

            List<Size> uSizes = new List<Size>();
            List<BitmapItem> bitmaps = new List<BitmapItem>();
            int totalWidth = 0;
            Size restSize = new Size(Width, Height);
            bool done = false;
            while (!done)
            {
                ImageSizeItem item;
                float rAspect = (float)(Width - totalWidth) / Height;
                done = (bitmaps.Count >= imgCount) && (rAspect < minAspect);
                if (!done)
                {
                    item = images[rnd.Next(images.Count)];
                }
                else
                {
                    item = images.OrderBy(img => Math.Abs(img.Aspect - rAspect)).First();
                }

                Size uSpace = GetUsedSpace(item.Size.size, restSize);
                BitmapItem bItem = new BitmapItem
                {
                    img = item,
                    rect = new Rectangle(totalWidth, 0, uSpace.Width, uSpace.Height)
                };
                bitmaps.Add(bItem);
                totalWidth += uSpace.Width;
            }


            Bitmap newBG = new Bitmap(totalWidth, Height);
            using (Graphics g = Graphics.FromImage(newBG))
            {
                foreach (var b in bitmaps)
                {
                    using (Image img = Image.FromFile(b.img.Size.fName))
                    {
                        g.DrawImage(img, b.rect);
                    }
                }
            }
            return newBG;
        }

        private Size GetUsedSpace(Size imgSize, Size avSize)
        {
            float ainner = (float)imgSize.Width / imgSize.Height;
            float aouter = (float)avSize.Width / avSize.Height;
            float acomb = aouter / ainner;
            if (acomb < 1)
            {
                return new Size(avSize.Width, (int)(avSize.Height * acomb));
            }
            else
            {
                return new Size((int)(avSize.Width / acomb), avSize.Height);
            }
        }

        private void ImageView_Resize(object sender, EventArgs e)
        {
            //            if (images.Count == 0) return;
            var list = GetImagesWithAspect(Aspect);
            float asp = 0f;         
            Text = $"Aspect: {Aspect:f4} / {list.Count()} - {Aspect / asp}";
            Invalidate();
        }

        private Color RandomColor()
        {
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private IEnumerable<ImageSizeItem> GetImagesWithAspect(float aspect,float margin = 0.1f)
        {
            return images.Where(img => (Math.Abs(img.Aspect - Aspect) < margin));
        }

        private void ImageView_Paint(object sender, PaintEventArgs e)
        {
            if (ClientSize.Width <= 0 || ClientSize.Height <= 0) return;
            if (BGImage == null)
            {
                GenerateNewBG();
            }
            Size uSize = GetUsedSpace(BGImage.Size, ClientSize);
            e.Graphics.DrawImage(BGImage,0,0,uSize.Width,uSize .Height);
//            e.Graphics.DrawImage(BGImage, ClientRectangle);
        }

        private void ImageView_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void ImageView_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (e.Alt)
                    {
                        if (WindowState == FormWindowState.Maximized)
                        {
                            WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            WindowState = FormWindowState.Maximized;
                            AllowTransparency = true;
                        }
                    }
                    break;
                case Keys.Space:
                    GenerateNewBG();
                    break;

            }

        }

        protected override void WndProc(ref Message m)
        {
            if (!config.ClickThrough)
            {
                base.WndProc(ref m);
                return;
            }

            if (m.Msg == WM_NCHITTEST)
                m.Result = new IntPtr(-1);
            else
                base.WndProc(ref m);
        }
    }
}
