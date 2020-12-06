
namespace ImagePresto
{
    partial class ImageScan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressScan = new System.Windows.Forms.ProgressBar();
            this.tbScanDir = new System.Windows.Forms.TextBox();
            this.bScan = new System.Windows.Forms.Button();
            this.lScanInfo = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressScan
            // 
            this.progressScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressScan.Location = new System.Drawing.Point(16, 48);
            this.progressScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressScan.Minimum = 1;
            this.progressScan.Name = "progressScan";
            this.progressScan.Size = new System.Drawing.Size(663, 28);
            this.progressScan.TabIndex = 0;
            this.progressScan.Value = 1;
            // 
            // tbScanDir
            // 
            this.tbScanDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScanDir.Location = new System.Drawing.Point(16, 15);
            this.tbScanDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbScanDir.Name = "tbScanDir";
            this.tbScanDir.Size = new System.Drawing.Size(553, 22);
            this.tbScanDir.TabIndex = 1;
            // 
            // bScan
            // 
            this.bScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bScan.Location = new System.Drawing.Point(579, 12);
            this.bScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(100, 28);
            this.bScan.TabIndex = 2;
            this.bScan.Text = "Scan";
            this.bScan.UseVisualStyleBackColor = true;
            this.bScan.Click += new System.EventHandler(this.bScan_Click);
            // 
            // lScanInfo
            // 
            this.lScanInfo.AutoSize = true;
            this.lScanInfo.Location = new System.Drawing.Point(16, 80);
            this.lScanInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lScanInfo.Name = "lScanInfo";
            this.lScanInfo.Size = new System.Drawing.Size(16, 17);
            this.lScanInfo.TabIndex = 3;
            this.lScanInfo.Text = "0";
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Enabled = false;
            this.bSave.Location = new System.Drawing.Point(579, 113);
            this.bSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(100, 28);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // ImageScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 167);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lScanInfo);
            this.Controls.Add(this.bScan);
            this.Controls.Add(this.tbScanDir);
            this.Controls.Add(this.progressScan);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImageScan";
            this.Text = "ImageScan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressScan;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lScanInfo;
        private System.Windows.Forms.Button bScan;
        private System.Windows.Forms.TextBox tbScanDir;
    }
}