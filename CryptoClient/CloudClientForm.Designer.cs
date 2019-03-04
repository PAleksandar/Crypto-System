namespace CryptoClient
{
    partial class CloudClientForm
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.gbPath = new System.Windows.Forms.GroupBox();
            this.gbPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(297, 54);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(131, 56);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.Location = new System.Drawing.Point(40, 54);
            this.btnSourcePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(134, 52);
            this.btnSourcePath.TabIndex = 2;
            this.btnSourcePath.Text = "Source path";
            this.btnSourcePath.UseVisualStyleBackColor = true;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // gbPath
            // 
            this.gbPath.Controls.Add(this.btnSourcePath);
            this.gbPath.Controls.Add(this.btnUpload);
            this.gbPath.Location = new System.Drawing.Point(23, 13);
            this.gbPath.Margin = new System.Windows.Forms.Padding(4);
            this.gbPath.Name = "gbPath";
            this.gbPath.Padding = new System.Windows.Forms.Padding(4);
            this.gbPath.Size = new System.Drawing.Size(524, 164);
            this.gbPath.TabIndex = 14;
            this.gbPath.TabStop = false;
            this.gbPath.Text = "Upload:";
            // 
            // CloudClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 518);
            this.Controls.Add(this.gbPath);
            this.Name = "CloudClientForm";
            this.Text = "CloudClientForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloudClientForm_FormClosing);
            this.gbPath.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.GroupBox gbPath;
    }
}