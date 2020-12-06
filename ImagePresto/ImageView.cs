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
        Bitmap bitmap;
        Rectangle rect;
    }

    public partial class ImageView : Form
    {
        readonly IPConfig config;
        readonly List<ImageSizeItem> images= new List<ImageSizeItem>();
        readonly Random rnd = new Random();

        public float Aspect { get { return (float)ClientSize.Width / ClientSize.Height; } }

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
            IEnumerable<ImageSizeItem> query = images.Where(img => (img.Aspect > Aspect));

            IEnumerable<ImageSizeItem> sorter = images.OrderBy(img => Math.Abs(img.Aspect - Aspect));

            int i = query.Count();

            Text = i.ToString();


        }

        private void ImageView_Resize(object sender, EventArgs e)
        {
            //            if (images.Count == 0) return;
            var list = GetImagesWithAspect(Aspect);
            Text = $"Aspect: {Aspect:f4} / {list.Count()}";
        }


        IEnumerable<ImageSizeItem> GetImagesWithAspect(float aspect,float margin = 0.1f)
        {
            return images.Where(img => (Math.Abs(img.Aspect - Aspect) < margin));
        }
    }
}
