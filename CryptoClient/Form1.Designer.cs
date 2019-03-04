namespace CryptoClient
{
    partial class Form1
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.gbEncryption = new System.Windows.Forms.GroupBox();
            this.cbFileSysWatc = new System.Windows.Forms.CheckBox();
            this.rbDecrypt = new System.Windows.Forms.RadioButton();
            this.rbCrypt = new System.Windows.Forms.RadioButton();
            this.gbPath = new System.Windows.Forms.GroupBox();
            this.btnSource = new System.Windows.Forms.Button();
            this.btnDestination = new System.Windows.Forms.Button();
            this.tbxRC4j = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxRC4i = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxRC4Key = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDESDecrypt = new System.Windows.Forms.Button();
            this.btnRSACrypt = new System.Windows.Forms.Button();
            this.tbxRSASource = new System.Windows.Forms.TextBox();
            this.tbxRSAResult = new System.Windows.Forms.TextBox();
            this.btnRandomKey = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSourcePath = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRC4 = new System.Windows.Forms.TabPage();
            this.btnRandomIV = new System.Windows.Forms.Button();
            this.checkBoxCTR = new System.Windows.Forms.CheckBox();
            this.tbxIV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageRSA = new System.Windows.Forms.TabPage();
            this.btnRSARandomIV = new System.Windows.Forms.Button();
            this.checkBoxRSACTR = new System.Windows.Forms.CheckBox();
            this.tbxRSAIV = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxRSAD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxRSAE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxRSAN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxRSAq = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxRSAp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageA5 = new System.Windows.Forms.TabPage();
            this.tbxA5IV = new System.Windows.Forms.TextBox();
            this.btnA5RandomIV = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxA5Key = new System.Windows.Forms.TextBox();
            this.tabTigerHash = new System.Windows.Forms.TabPage();
            this.btnTigetHash = new System.Windows.Forms.Button();
            this.checkBoxTigerHash = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.gbEncryption.SuspendLayout();
            this.gbPath.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageRC4.SuspendLayout();
            this.tabPageRSA.SuspendLayout();
            this.tabPageA5.SuspendLayout();
            this.tabTigerHash.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // gbEncryption
            // 
            this.gbEncryption.Controls.Add(this.cbFileSysWatc);
            this.gbEncryption.Controls.Add(this.rbDecrypt);
            this.gbEncryption.Controls.Add(this.rbCrypt);
            this.gbEncryption.Location = new System.Drawing.Point(28, 519);
            this.gbEncryption.Margin = new System.Windows.Forms.Padding(4);
            this.gbEncryption.Name = "gbEncryption";
            this.gbEncryption.Padding = new System.Windows.Forms.Padding(4);
            this.gbEncryption.Size = new System.Drawing.Size(175, 134);
            this.gbEncryption.TabIndex = 12;
            this.gbEncryption.TabStop = false;
            this.gbEncryption.Text = "Choose encryption:";
            // 
            // cbFileSysWatc
            // 
            this.cbFileSysWatc.AutoSize = true;
            this.cbFileSysWatc.Location = new System.Drawing.Point(13, 95);
            this.cbFileSysWatc.Margin = new System.Windows.Forms.Padding(4);
            this.cbFileSysWatc.Name = "cbFileSysWatc";
            this.cbFileSysWatc.Size = new System.Drawing.Size(153, 21);
            this.cbFileSysWatc.TabIndex = 2;
            this.cbFileSysWatc.Text = "File system watcher";
            this.cbFileSysWatc.UseVisualStyleBackColor = true;
            this.cbFileSysWatc.CheckedChanged += new System.EventHandler(this.cbFileSysWatc_CheckedChanged);
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.AutoSize = true;
            this.rbDecrypt.Location = new System.Drawing.Point(37, 55);
            this.rbDecrypt.Margin = new System.Windows.Forms.Padding(4);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(78, 21);
            this.rbDecrypt.TabIndex = 1;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.UseVisualStyleBackColor = true;
            this.rbDecrypt.CheckedChanged += new System.EventHandler(this.rbDecrypt_CheckedChanged);
            // 
            // rbCrypt
            // 
            this.rbCrypt.AutoSize = true;
            this.rbCrypt.Location = new System.Drawing.Point(37, 26);
            this.rbCrypt.Margin = new System.Windows.Forms.Padding(4);
            this.rbCrypt.Name = "rbCrypt";
            this.rbCrypt.Size = new System.Drawing.Size(62, 21);
            this.rbCrypt.TabIndex = 0;
            this.rbCrypt.Text = "Crypt";
            this.rbCrypt.UseVisualStyleBackColor = true;
            this.rbCrypt.CheckedChanged += new System.EventHandler(this.rbCrypt_CheckedChanged);
            // 
            // gbPath
            // 
            this.gbPath.Controls.Add(this.btnSource);
            this.gbPath.Controls.Add(this.btnDestination);
            this.gbPath.Enabled = false;
            this.gbPath.Location = new System.Drawing.Point(317, 519);
            this.gbPath.Margin = new System.Windows.Forms.Padding(4);
            this.gbPath.Name = "gbPath";
            this.gbPath.Padding = new System.Windows.Forms.Padding(4);
            this.gbPath.Size = new System.Drawing.Size(196, 134);
            this.gbPath.TabIndex = 13;
            this.gbPath.TabStop = false;
            this.gbPath.Text = "Choose path:";
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(24, 43);
            this.btnSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(147, 28);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Source path";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // btnDestination
            // 
            this.btnDestination.Enabled = false;
            this.btnDestination.Location = new System.Drawing.Point(24, 75);
            this.btnDestination.Margin = new System.Windows.Forms.Padding(4);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(147, 28);
            this.btnDestination.TabIndex = 1;
            this.btnDestination.Text = "Destination path";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // tbxRC4j
            // 
            this.tbxRC4j.Location = new System.Drawing.Point(443, 27);
            this.tbxRC4j.MaxLength = 1;
            this.tbxRC4j.Name = "tbxRC4j";
            this.tbxRC4j.Size = new System.Drawing.Size(38, 22);
            this.tbxRC4j.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(424, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 26);
            this.label9.TabIndex = 34;
            this.label9.Text = "j";
            // 
            // tbxRC4i
            // 
            this.tbxRC4i.Location = new System.Drawing.Point(366, 27);
            this.tbxRC4i.MaxLength = 1;
            this.tbxRC4i.Name = "tbxRC4i";
            this.tbxRC4i.Size = new System.Drawing.Size(39, 22);
            this.tbxRC4i.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(347, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 26);
            this.label7.TabIndex = 32;
            this.label7.Text = "i";
            // 
            // tbxRC4Key
            // 
            this.tbxRC4Key.Location = new System.Drawing.Point(98, 30);
            this.tbxRC4Key.Name = "tbxRC4Key";
            this.tbxRC4Key.Size = new System.Drawing.Size(192, 22);
            this.tbxRC4Key.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(52, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 26);
            this.label8.TabIndex = 30;
            this.label8.Text = "Key";
            // 
            // btnDESDecrypt
            // 
            this.btnDESDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDESDecrypt.Location = new System.Drawing.Point(496, 191);
            this.btnDESDecrypt.Name = "btnDESDecrypt";
            this.btnDESDecrypt.Size = new System.Drawing.Size(90, 48);
            this.btnDESDecrypt.TabIndex = 24;
            this.btnDESDecrypt.Text = "Decrypt";
            this.btnDESDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnRSACrypt
            // 
            this.btnRSACrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRSACrypt.Location = new System.Drawing.Point(271, 194);
            this.btnRSACrypt.Name = "btnRSACrypt";
            this.btnRSACrypt.Size = new System.Drawing.Size(90, 45);
            this.btnRSACrypt.TabIndex = 23;
            this.btnRSACrypt.Text = "Crypt";
            this.btnRSACrypt.Click += new System.EventHandler(this.btnRSACrypt_Click);
            // 
            // tbxRSASource
            // 
            this.tbxRSASource.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxRSASource.Location = new System.Drawing.Point(28, 246);
            this.tbxRSASource.Multiline = true;
            this.tbxRSASource.Name = "tbxRSASource";
            this.tbxRSASource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxRSASource.Size = new System.Drawing.Size(564, 111);
            this.tbxRSASource.TabIndex = 21;
            // 
            // tbxRSAResult
            // 
            this.tbxRSAResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbxRSAResult.Location = new System.Drawing.Point(28, 375);
            this.tbxRSAResult.Multiline = true;
            this.tbxRSAResult.Name = "tbxRSAResult";
            this.tbxRSAResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxRSAResult.Size = new System.Drawing.Size(564, 102);
            this.tbxRSAResult.TabIndex = 22;
            // 
            // btnRandomKey
            // 
            this.btnRandomKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandomKey.Location = new System.Drawing.Point(28, 192);
            this.btnRandomKey.Name = "btnRandomKey";
            this.btnRandomKey.Size = new System.Drawing.Size(90, 48);
            this.btnRandomKey.TabIndex = 36;
            this.btnRandomKey.Text = "Random key";
            this.btnRandomKey.Click += new System.EventHandler(this.btnRandomKey_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSourcePath);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Location = new System.Drawing.Point(791, 293);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(485, 103);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Upload:";
            // 
            // btnSourcePath
            // 
            this.btnSourcePath.Location = new System.Drawing.Point(28, 33);
            this.btnSourcePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSourcePath.Name = "btnSourcePath";
            this.btnSourcePath.Size = new System.Drawing.Size(134, 52);
            this.btnSourcePath.TabIndex = 2;
            this.btnSourcePath.Text = "Source path";
            this.btnSourcePath.UseVisualStyleBackColor = true;
            this.btnSourcePath.Click += new System.EventHandler(this.btnSourcePath_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(256, 31);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(131, 56);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(791, 136);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(343, 148);
            this.listBox1.TabIndex = 39;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(793, 73);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(173, 46);
            this.btnGet.TabIndex = 40;
            this.btnGet.Text = "List files from cloud";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1182, 246);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(173, 38);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(1182, 136);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(173, 38);
            this.btnDownload.TabIndex = 41;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1182, 191);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 38);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRC4);
            this.tabControl1.Controls.Add(this.tabPageRSA);
            this.tabControl1.Controls.Add(this.tabPageA5);
            this.tabControl1.Controls.Add(this.tabTigerHash);
            this.tabControl1.Location = new System.Drawing.Point(28, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 148);
            this.tabControl1.TabIndex = 43;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageRC4
            // 
            this.tabPageRC4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageRC4.Controls.Add(this.btnRandomIV);
            this.tabPageRC4.Controls.Add(this.checkBoxCTR);
            this.tabPageRC4.Controls.Add(this.tbxIV);
            this.tabPageRC4.Controls.Add(this.label4);
            this.tabPageRC4.Controls.Add(this.label8);
            this.tabPageRC4.Controls.Add(this.tbxRC4Key);
            this.tabPageRC4.Controls.Add(this.label7);
            this.tabPageRC4.Controls.Add(this.tbxRC4i);
            this.tabPageRC4.Controls.Add(this.label9);
            this.tabPageRC4.Controls.Add(this.tbxRC4j);
            this.tabPageRC4.Location = new System.Drawing.Point(4, 25);
            this.tabPageRC4.Name = "tabPageRC4";
            this.tabPageRC4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRC4.Size = new System.Drawing.Size(554, 119);
            this.tabPageRC4.TabIndex = 0;
            this.tabPageRC4.Text = "RC4";
            // 
            // btnRandomIV
            // 
            this.btnRandomIV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandomIV.Location = new System.Drawing.Point(464, 62);
            this.btnRandomIV.Name = "btnRandomIV";
            this.btnRandomIV.Size = new System.Drawing.Size(75, 50);
            this.btnRandomIV.TabIndex = 39;
            this.btnRandomIV.Text = "Random IV";
            this.btnRandomIV.Click += new System.EventHandler(this.btnRandomIV_Click);
            // 
            // checkBoxCTR
            // 
            this.checkBoxCTR.AutoSize = true;
            this.checkBoxCTR.Location = new System.Drawing.Point(350, 76);
            this.checkBoxCTR.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCTR.Name = "checkBoxCTR";
            this.checkBoxCTR.Size = new System.Drawing.Size(97, 21);
            this.checkBoxCTR.TabIndex = 38;
            this.checkBoxCTR.Text = "CTR mode";
            this.checkBoxCTR.UseVisualStyleBackColor = true;
            this.checkBoxCTR.CheckedChanged += new System.EventHandler(this.checkBoxCTR_CheckedChanged);
            // 
            // tbxIV
            // 
            this.tbxIV.Enabled = false;
            this.tbxIV.Location = new System.Drawing.Point(98, 76);
            this.tbxIV.Name = "tbxIV";
            this.tbxIV.Size = new System.Drawing.Size(192, 22);
            this.tbxIV.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(61, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 26);
            this.label4.TabIndex = 36;
            this.label4.Text = "IV";
            // 
            // tabPageRSA
            // 
            this.tabPageRSA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageRSA.Controls.Add(this.btnRSARandomIV);
            this.tabPageRSA.Controls.Add(this.checkBoxRSACTR);
            this.tabPageRSA.Controls.Add(this.tbxRSAIV);
            this.tabPageRSA.Controls.Add(this.label10);
            this.tabPageRSA.Controls.Add(this.tbxRSAD);
            this.tabPageRSA.Controls.Add(this.label1);
            this.tabPageRSA.Controls.Add(this.tbxRSAE);
            this.tabPageRSA.Controls.Add(this.label2);
            this.tabPageRSA.Controls.Add(this.tbxRSAN);
            this.tabPageRSA.Controls.Add(this.label3);
            this.tabPageRSA.Controls.Add(this.tbxRSAq);
            this.tabPageRSA.Controls.Add(this.label5);
            this.tabPageRSA.Controls.Add(this.tbxRSAp);
            this.tabPageRSA.Controls.Add(this.label6);
            this.tabPageRSA.Location = new System.Drawing.Point(4, 25);
            this.tabPageRSA.Name = "tabPageRSA";
            this.tabPageRSA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRSA.Size = new System.Drawing.Size(554, 119);
            this.tabPageRSA.TabIndex = 1;
            this.tabPageRSA.Text = "RSA";
            // 
            // btnRSARandomIV
            // 
            this.btnRSARandomIV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRSARandomIV.Location = new System.Drawing.Point(433, 59);
            this.btnRSARandomIV.Name = "btnRSARandomIV";
            this.btnRSARandomIV.Size = new System.Drawing.Size(75, 50);
            this.btnRSARandomIV.TabIndex = 43;
            this.btnRSARandomIV.Text = "Random IV";
            this.btnRSARandomIV.Click += new System.EventHandler(this.btnRSARandomIV_Click);
            // 
            // checkBoxRSACTR
            // 
            this.checkBoxRSACTR.AutoSize = true;
            this.checkBoxRSACTR.Location = new System.Drawing.Point(319, 73);
            this.checkBoxRSACTR.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRSACTR.Name = "checkBoxRSACTR";
            this.checkBoxRSACTR.Size = new System.Drawing.Size(97, 21);
            this.checkBoxRSACTR.TabIndex = 42;
            this.checkBoxRSACTR.Text = "CTR mode";
            this.checkBoxRSACTR.UseVisualStyleBackColor = true;
            this.checkBoxRSACTR.CheckedChanged += new System.EventHandler(this.checkBoxRSACTR_CheckedChanged);
            // 
            // tbxRSAIV
            // 
            this.tbxRSAIV.Enabled = false;
            this.tbxRSAIV.Location = new System.Drawing.Point(67, 73);
            this.tbxRSAIV.Name = "tbxRSAIV";
            this.tbxRSAIV.Size = new System.Drawing.Size(192, 22);
            this.tbxRSAIV.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(30, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 26);
            this.label10.TabIndex = 40;
            this.label10.Text = "IV";
            // 
            // tbxRSAD
            // 
            this.tbxRSAD.Location = new System.Drawing.Point(474, 15);
            this.tbxRSAD.Name = "tbxRSAD";
            this.tbxRSAD.Size = new System.Drawing.Size(38, 22);
            this.tbxRSAD.TabIndex = 30;
            this.tbxRSAD.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(455, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 26);
            this.label1.TabIndex = 29;
            this.label1.Text = "d";
            this.label1.Visible = false;
            // 
            // tbxRSAE
            // 
            this.tbxRSAE.Location = new System.Drawing.Point(378, 15);
            this.tbxRSAE.Name = "tbxRSAE";
            this.tbxRSAE.Size = new System.Drawing.Size(39, 22);
            this.tbxRSAE.TabIndex = 28;
            this.tbxRSAE.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(359, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 26);
            this.label2.TabIndex = 27;
            this.label2.Text = "e";
            this.label2.Visible = false;
            // 
            // tbxRSAN
            // 
            this.tbxRSAN.Location = new System.Drawing.Point(262, 15);
            this.tbxRSAN.Name = "tbxRSAN";
            this.tbxRSAN.Size = new System.Drawing.Size(67, 22);
            this.tbxRSAN.TabIndex = 26;
            this.tbxRSAN.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(233, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 26);
            this.label3.TabIndex = 25;
            this.label3.Text = "N";
            this.label3.Visible = false;
            // 
            // tbxRSAq
            // 
            this.tbxRSAq.Location = new System.Drawing.Point(150, 15);
            this.tbxRSAq.Name = "tbxRSAq";
            this.tbxRSAq.Size = new System.Drawing.Size(39, 22);
            this.tbxRSAq.TabIndex = 24;
            this.tbxRSAq.Text = "23";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(131, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 27);
            this.label5.TabIndex = 23;
            this.label5.Text = "q";
            // 
            // tbxRSAp
            // 
            this.tbxRSAp.Location = new System.Drawing.Point(47, 15);
            this.tbxRSAp.Name = "tbxRSAp";
            this.tbxRSAp.Size = new System.Drawing.Size(39, 22);
            this.tbxRSAp.TabIndex = 22;
            this.tbxRSAp.Text = "17";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 27);
            this.label6.TabIndex = 21;
            this.label6.Text = "p";
            // 
            // tabPageA5
            // 
            this.tabPageA5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPageA5.Controls.Add(this.tbxA5IV);
            this.tabPageA5.Controls.Add(this.btnA5RandomIV);
            this.tabPageA5.Controls.Add(this.label11);
            this.tabPageA5.Controls.Add(this.label12);
            this.tabPageA5.Controls.Add(this.tbxA5Key);
            this.tabPageA5.Location = new System.Drawing.Point(4, 25);
            this.tabPageA5.Name = "tabPageA5";
            this.tabPageA5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageA5.Size = new System.Drawing.Size(554, 119);
            this.tabPageA5.TabIndex = 2;
            this.tabPageA5.Text = "A5/2";
            // 
            // tbxA5IV
            // 
            this.tbxA5IV.Location = new System.Drawing.Point(52, 70);
            this.tbxA5IV.Name = "tbxA5IV";
            this.tbxA5IV.Size = new System.Drawing.Size(415, 22);
            this.tbxA5IV.TabIndex = 45;
            // 
            // btnA5RandomIV
            // 
            this.btnA5RandomIV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnA5RandomIV.Location = new System.Drawing.Point(473, 36);
            this.btnA5RandomIV.Name = "btnA5RandomIV";
            this.btnA5RandomIV.Size = new System.Drawing.Size(75, 50);
            this.btnA5RandomIV.TabIndex = 44;
            this.btnA5RandomIV.Text = "Random IV";
            this.btnA5RandomIV.Click += new System.EventHandler(this.btnA5RandomIV_Click);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(15, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 26);
            this.label11.TabIndex = 40;
            this.label11.Text = "IV";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 26);
            this.label12.TabIndex = 38;
            this.label12.Text = "Key";
            // 
            // tbxA5Key
            // 
            this.tbxA5Key.Location = new System.Drawing.Point(52, 24);
            this.tbxA5Key.Name = "tbxA5Key";
            this.tbxA5Key.Size = new System.Drawing.Size(413, 22);
            this.tbxA5Key.TabIndex = 39;
            // 
            // tabTigerHash
            // 
            this.tabTigerHash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabTigerHash.Controls.Add(this.btnTigetHash);
            this.tabTigerHash.Location = new System.Drawing.Point(4, 25);
            this.tabTigerHash.Name = "tabTigerHash";
            this.tabTigerHash.Padding = new System.Windows.Forms.Padding(3);
            this.tabTigerHash.Size = new System.Drawing.Size(554, 119);
            this.tabTigerHash.TabIndex = 3;
            this.tabTigerHash.Text = "Tiger hash";
            // 
            // btnTigetHash
            // 
            this.btnTigetHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTigetHash.Location = new System.Drawing.Point(193, 36);
            this.btnTigetHash.Name = "btnTigetHash";
            this.btnTigetHash.Size = new System.Drawing.Size(90, 45);
            this.btnTigetHash.TabIndex = 24;
            this.btnTigetHash.Text = "Get hash value";
            this.btnTigetHash.Click += new System.EventHandler(this.btnTigetHash_Click);
            // 
            // checkBoxTigerHash
            // 
            this.checkBoxTigerHash.AutoSize = true;
            this.checkBoxTigerHash.Location = new System.Drawing.Point(41, 163);
            this.checkBoxTigerHash.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTigerHash.Name = "checkBoxTigerHash";
            this.checkBoxTigerHash.Size = new System.Drawing.Size(98, 21);
            this.checkBoxTigerHash.TabIndex = 44;
            this.checkBoxTigerHash.Text = "Tiger hash";
            this.checkBoxTigerHash.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 716);
            this.Controls.Add(this.checkBoxTigerHash);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRandomKey);
            this.Controls.Add(this.btnDESDecrypt);
            this.Controls.Add(this.btnRSACrypt);
            this.Controls.Add(this.tbxRSASource);
            this.Controls.Add(this.tbxRSAResult);
            this.Controls.Add(this.gbEncryption);
            this.Controls.Add(this.gbPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.gbEncryption.ResumeLayout(false);
            this.gbEncryption.PerformLayout();
            this.gbPath.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageRC4.ResumeLayout(false);
            this.tabPageRC4.PerformLayout();
            this.tabPageRSA.ResumeLayout(false);
            this.tabPageRSA.PerformLayout();
            this.tabPageA5.ResumeLayout(false);
            this.tabPageA5.PerformLayout();
            this.tabTigerHash.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.GroupBox gbEncryption;
        private System.Windows.Forms.CheckBox cbFileSysWatc;
        private System.Windows.Forms.RadioButton rbDecrypt;
        private System.Windows.Forms.RadioButton rbCrypt;
        private System.Windows.Forms.GroupBox gbPath;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.TextBox tbxRC4j;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxRC4i;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxRC4Key;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDESDecrypt;
        private System.Windows.Forms.Button btnRSACrypt;
        private System.Windows.Forms.TextBox tbxRSASource;
        private System.Windows.Forms.TextBox tbxRSAResult;
        private System.Windows.Forms.Button btnRandomKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSourcePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageRC4;
        private System.Windows.Forms.TabPage tabPageRSA;
        private System.Windows.Forms.TabPage tabPageA5;
        private System.Windows.Forms.TextBox tbxRSAD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxRSAE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxRSAq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxRSAp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabTigerHash;
        private System.Windows.Forms.TextBox tbxIV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxCTR;
        private System.Windows.Forms.Button btnRandomIV;
        private System.Windows.Forms.Button btnRSARandomIV;
        private System.Windows.Forms.CheckBox checkBoxRSACTR;
        private System.Windows.Forms.TextBox tbxRSAIV;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxRSAN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnA5RandomIV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbxA5Key;
        private System.Windows.Forms.TextBox tbxA5IV;
        private System.Windows.Forms.Button btnTigetHash;
        private System.Windows.Forms.CheckBox checkBoxTigerHash;
    }
}

