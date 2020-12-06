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
    public partial class ImageScan : Form
    {
        readonly string ScanDir;
        readonly IPConfig config;
        
        public ImageScan(string v)
        {
            InitializeComponent();            
            ScanDir = v?.Length > 0 ? v : Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            config = IPConfig.GetConfig();
            tbScanDir.Text = ScanDir;
        }

        Size GetImageSize(string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    using (Image img = Image.FromStream(fs, false, false))
                    {
                        return new Size(img.Width, img.Height);
                    }
                }
            }
            catch {}
            return Size.Empty;
        }

        async Task ScanImages(string scanDir, IProgress<ScanProgressReport> progress)
        {
            var fList = Directory.EnumerateFiles(scanDir);
            int index = 1;
            int total = fList.Count();
            
            foreach (var fName in fList)
            {
                var result = await Task.Run<Size>(() => GetImageSize(fName));
                progress.Report(new ScanProgressReport { CurrentProgressAmount = index, TotalProgressAmount = total, CurrentProgressMessage = result.ToString() });
                index++;
            }
        }

        private void ReportProgress(ScanProgressReport progress)
        {
            progressScan.Maximum = progress.TotalProgressAmount;
            progressScan.Value = progress.CurrentProgressAmount;
            lScanInfo.Text = $"{progress.CurrentProgressAmount} / {progress.TotalProgressAmount} {progress.CurrentProgressMessage}";
        }



        private async void bScan_Click(object sender, EventArgs e)
        {
            var progressIndikator = new Progress<ScanProgressReport>(ReportProgress);
            await ScanImages(tbScanDir.Text, progressIndikator);
        }
    }
}
