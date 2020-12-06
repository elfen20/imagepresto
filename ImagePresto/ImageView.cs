﻿using Newtonsoft.Json;
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


        private void ImageView_Click(object sender, EventArgs e)
        {
            NewBG(ClientSize);
            Invalidate();
        }

        private void NewBG(Size size)
        {
            float minAspect = 1.7f;

            List<Size> uSizes = new List<Size>();
            List<BitmapItem> bitmaps = new List<BitmapItem>();
            int totalWidth = 0;
            Size restSize = size;
            bool done = false;
            while (!done)
            {
                ImageSizeItem item;
                float rAspect = (float)(size.Width - totalWidth) / size.Height;
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


            Bitmap newBG = new Bitmap(totalWidth, size.Height);
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

            Bitmap oldBG = BGImage;
            BGImage = newBG;
            oldBG.Dispose();
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
            if (BGImage == null)
            {
                BGImage = new Bitmap(ClientSize.Width, ClientSize.Height);
                using (Graphics g = Graphics.FromImage(BGImage))
                {
                    g.Clear(RandomColor());
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 5; x++)
                        {
                            g.FillEllipse(Brushes.AliceBlue, new Rectangle(x * 100 + 50, y * 100 + 50, 90, 90));
                        }
                    }
                }
            }
            Size uSize = GetUsedSpace(BGImage.Size, ClientSize);
            e.Graphics.DrawImage(BGImage,0,0,uSize.Width,uSize .Height);
//            e.Graphics.DrawImage(BGImage, ClientRectangle);
        }
    }
}
