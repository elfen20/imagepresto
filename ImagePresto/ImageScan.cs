using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImagePresto
{
    public partial class ImageScan : Form
    {
        readonly string ScanDir;
        readonly IPConfig config;
        
        public ImageScan(string v)
        {
            InitializeComponent();
            this.ScanDir = v;
            config = IPConfig.GetConfig();
            tbScanDir.Text = v;
        }
    }
}
