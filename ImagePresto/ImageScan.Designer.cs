
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
            this.components = new System.ComponentModel.Container();
            this.progressScan = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbScanDir = new System.Windows.Forms.TextBox();
            this.bScan = new System.Windows.Forms.Button();
            this.lScanInfo = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressScan
            // 
            this.progressScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressScan.Location = new System.Drawing.Point(12, 39);
            this.progressScan.Name = "progressScan";
            this.progressScan.Size = new System.Drawing.Size(497, 23);
            this.progressScan.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbScanDir
            // 
            this.tbScanDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScanDir.Location = new System.Drawing.Point(12, 12);
            this.tbScanDir.Name = "tbScanDir";
            this.tbScanDir.Size = new System.Drawing.Size(416, 20);
            this.tbScanDir.TabIndex = 1;
            // 
            // bScan
            // 
            this.bScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bScan.Location = new System.Drawing.Point(434, 10);
            this.bScan.Name = "bScan";
            this.bScan.Size = new System.Drawing.Size(75, 23);
            this.bScan.TabIndex = 2;
            this.bScan.Text = "Scan";
            this.bScan.UseVisualStyleBackColor = true;
            // 
            // lScanInfo
            // 
            this.lScanInfo.AutoSize = true;
            this.lScanInfo.Location = new System.Drawing.Point(12, 65);
            this.lScanInfo.Name = "lScanInfo";
            this.lScanInfo.Size = new System.Drawing.Size(13, 13);
            this.lScanInfo.TabIndex = 3;
            this.lScanInfo.Text = "0";
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.Location = new System.Drawing.Point(434, 92);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // ImageScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 136);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lScanInfo);
            this.Controls.Add(this.bScan);
            this.Controls.Add(this.tbScanDir);
            this.Controls.Add(this.progressScan);
            this.Name = "ImageScan";
            this.Text = "ImageScan";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressScan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label lScanInfo;
        private System.Windows.Forms.Button bScan;
        private System.Windows.Forms.TextBox tbScanDir;
    }
}