namespace MyProgram
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpEncrypt = new System.Windows.Forms.TabPage();
            this.lbKey = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btChooseEI = new System.Windows.Forms.Button();
            this.pbEI = new System.Windows.Forms.PictureBox();
            this.tpEmbed = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.tbMax = new System.Windows.Forms.TextBox();
            this.btEmbed = new System.Windows.Forms.Button();
            this.btOpenEMM = new System.Windows.Forms.Button();
            this.rtbEMM = new System.Windows.Forms.RichTextBox();
            this.pbEMM = new System.Windows.Forms.PictureBox();
            this.tpDecrypt = new System.Windows.Forms.TabPage();
            this.btChooseDI = new System.Windows.Forms.Button();
            this.pbDI = new System.Windows.Forms.PictureBox();
            this.tpExtract = new System.Windows.Forms.TabPage();
            this.btExtract = new System.Windows.Forms.Button();
            this.rtbEM = new System.Windows.Forms.RichTextBox();
            this.pbEM = new System.Windows.Forms.PictureBox();
            this.tpMetadata = new System.Windows.Forms.TabPage();
            this.btMeta = new System.Windows.Forms.Button();
            this.rtbMeta = new System.Windows.Forms.RichTextBox();
            this.pbMeta = new System.Windows.Forms.PictureBox();
            this.tbCC = new System.Windows.Forms.TabPage();
            this.btChoose = new System.Windows.Forms.Button();
            this.rtbCC = new System.Windows.Forms.RichTextBox();
            this.pbCC2 = new System.Windows.Forms.PictureBox();
            this.pbCC1 = new System.Windows.Forms.PictureBox();
            this.tbDesc = new System.Windows.Forms.TabPage();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.btDate = new System.Windows.Forms.Button();
            this.pbDes = new System.Windows.Forms.PictureBox();
            this.lbFN = new System.Windows.Forms.Label();
            this.tbFN = new System.Windows.Forms.TextBox();
            this.lbW = new System.Windows.Forms.Label();
            this.lbH = new System.Windows.Forms.Label();
            this.tbW = new System.Windows.Forms.TextBox();
            this.tbH = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tpEncrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEI)).BeginInit();
            this.tpEmbed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEMM)).BeginInit();
            this.tpDecrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDI)).BeginInit();
            this.tpExtract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEM)).BeginInit();
            this.tpMetadata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMeta)).BeginInit();
            this.tbCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCC1)).BeginInit();
            this.tbDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpEncrypt);
            this.tabControl1.Controls.Add(this.tpEmbed);
            this.tabControl1.Controls.Add(this.tpDecrypt);
            this.tabControl1.Controls.Add(this.tpExtract);
            this.tabControl1.Controls.Add(this.tpMetadata);
            this.tabControl1.Controls.Add(this.tbCC);
            this.tabControl1.Controls.Add(this.tbDesc);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(705, 429);
            this.tabControl1.TabIndex = 0;
            // 
            // tpEncrypt
            // 
            this.tpEncrypt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpEncrypt.Controls.Add(this.lbKey);
            this.tpEncrypt.Controls.Add(this.tbKey);
            this.tpEncrypt.Controls.Add(this.btChooseEI);
            this.tpEncrypt.Controls.Add(this.pbEI);
            this.tpEncrypt.Location = new System.Drawing.Point(4, 22);
            this.tpEncrypt.Name = "tpEncrypt";
            this.tpEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tpEncrypt.Size = new System.Drawing.Size(697, 403);
            this.tpEncrypt.TabIndex = 0;
            this.tpEncrypt.Text = "Encrypt Image";
            // 
            // lbKey
            // 
            this.lbKey.AutoSize = true;
            this.lbKey.Location = new System.Drawing.Point(7, 382);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(28, 13);
            this.lbKey.TabIndex = 6;
            this.lbKey.Text = "KEY";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(41, 379);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(188, 20);
            this.tbKey.TabIndex = 5;
            // 
            // btChooseEI
            // 
            this.btChooseEI.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btChooseEI.Location = new System.Drawing.Point(598, 380);
            this.btChooseEI.Name = "btChooseEI";
            this.btChooseEI.Size = new System.Drawing.Size(89, 23);
            this.btChooseEI.TabIndex = 4;
            this.btChooseEI.Text = "Choose File ....";
            this.btChooseEI.UseVisualStyleBackColor = false;
            this.btChooseEI.Click += new System.EventHandler(this.btChooseEI_Click);
            // 
            // pbEI
            // 
            this.pbEI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbEI.Location = new System.Drawing.Point(6, 6);
            this.pbEI.Name = "pbEI";
            this.pbEI.Size = new System.Drawing.Size(682, 367);
            this.pbEI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEI.TabIndex = 3;
            this.pbEI.TabStop = false;
            // 
            // tpEmbed
            // 
            this.tpEmbed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpEmbed.Controls.Add(this.label2);
            this.tpEmbed.Controls.Add(this.label1);
            this.tpEmbed.Controls.Add(this.tbStart);
            this.tpEmbed.Controls.Add(this.tbMax);
            this.tpEmbed.Controls.Add(this.btEmbed);
            this.tpEmbed.Controls.Add(this.btOpenEMM);
            this.tpEmbed.Controls.Add(this.rtbEMM);
            this.tpEmbed.Controls.Add(this.pbEMM);
            this.tpEmbed.Location = new System.Drawing.Point(4, 22);
            this.tpEmbed.Name = "tpEmbed";
            this.tpEmbed.Size = new System.Drawing.Size(697, 403);
            this.tpEmbed.TabIndex = 3;
            this.tpEmbed.Text = "Embending Message";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(608, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(521, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Blok";
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(555, 346);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(47, 20);
            this.tbStart.TabIndex = 6;
            // 
            // tbMax
            // 
            this.tbMax.Location = new System.Drawing.Point(642, 346);
            this.tbMax.Name = "tbMax";
            this.tbMax.ReadOnly = true;
            this.tbMax.Size = new System.Drawing.Size(47, 20);
            this.tbMax.TabIndex = 5;
            // 
            // btEmbed
            // 
            this.btEmbed.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btEmbed.Location = new System.Drawing.Point(615, 376);
            this.btEmbed.Name = "btEmbed";
            this.btEmbed.Size = new System.Drawing.Size(75, 23);
            this.btEmbed.TabIndex = 4;
            this.btEmbed.Text = "Embed";
            this.btEmbed.UseVisualStyleBackColor = false;
            this.btEmbed.Click += new System.EventHandler(this.btEmbed_Click);
            // 
            // btOpenEMM
            // 
            this.btOpenEMM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btOpenEMM.Location = new System.Drawing.Point(334, 376);
            this.btOpenEMM.Name = "btOpenEMM";
            this.btOpenEMM.Size = new System.Drawing.Size(75, 23);
            this.btOpenEMM.TabIndex = 3;
            this.btOpenEMM.Text = "Open File ...";
            this.btOpenEMM.UseVisualStyleBackColor = false;
            this.btOpenEMM.Click += new System.EventHandler(this.btOpenEMM_Click);
            // 
            // rtbEMM
            // 
            this.rtbEMM.Location = new System.Drawing.Point(415, 4);
            this.rtbEMM.Name = "rtbEMM";
            this.rtbEMM.Size = new System.Drawing.Size(275, 335);
            this.rtbEMM.TabIndex = 2;
            this.rtbEMM.Text = "";
            // 
            // pbEMM
            // 
            this.pbEMM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbEMM.Location = new System.Drawing.Point(5, 3);
            this.pbEMM.Name = "pbEMM";
            this.pbEMM.Size = new System.Drawing.Size(404, 367);
            this.pbEMM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEMM.TabIndex = 1;
            this.pbEMM.TabStop = false;
            // 
            // tpDecrypt
            // 
            this.tpDecrypt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpDecrypt.Controls.Add(this.btChooseDI);
            this.tpDecrypt.Controls.Add(this.pbDI);
            this.tpDecrypt.Location = new System.Drawing.Point(4, 22);
            this.tpDecrypt.Name = "tpDecrypt";
            this.tpDecrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tpDecrypt.Size = new System.Drawing.Size(697, 403);
            this.tpDecrypt.TabIndex = 1;
            this.tpDecrypt.Text = "Decrypt Image";
            // 
            // btChooseDI
            // 
            this.btChooseDI.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btChooseDI.Location = new System.Drawing.Point(598, 377);
            this.btChooseDI.Name = "btChooseDI";
            this.btChooseDI.Size = new System.Drawing.Size(89, 23);
            this.btChooseDI.TabIndex = 2;
            this.btChooseDI.Text = "Choose File ....";
            this.btChooseDI.UseVisualStyleBackColor = false;
            this.btChooseDI.Click += new System.EventHandler(this.btChooseDI_Click);
            // 
            // pbDI
            // 
            this.pbDI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbDI.Location = new System.Drawing.Point(6, 3);
            this.pbDI.Name = "pbDI";
            this.pbDI.Size = new System.Drawing.Size(682, 367);
            this.pbDI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDI.TabIndex = 1;
            this.pbDI.TabStop = false;
            // 
            // tpExtract
            // 
            this.tpExtract.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpExtract.Controls.Add(this.btExtract);
            this.tpExtract.Controls.Add(this.rtbEM);
            this.tpExtract.Controls.Add(this.pbEM);
            this.tpExtract.Location = new System.Drawing.Point(4, 22);
            this.tpExtract.Name = "tpExtract";
            this.tpExtract.Size = new System.Drawing.Size(697, 403);
            this.tpExtract.TabIndex = 2;
            this.tpExtract.Text = "Extraction Message";
            // 
            // btExtract
            // 
            this.btExtract.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btExtract.Location = new System.Drawing.Point(616, 377);
            this.btExtract.Name = "btExtract";
            this.btExtract.Size = new System.Drawing.Size(75, 23);
            this.btExtract.TabIndex = 3;
            this.btExtract.Text = "Extract";
            this.btExtract.UseVisualStyleBackColor = false;
            this.btExtract.Click += new System.EventHandler(this.btExtract_Click);
            // 
            // rtbEM
            // 
            this.rtbEM.Location = new System.Drawing.Point(416, 4);
            this.rtbEM.Name = "rtbEM";
            this.rtbEM.ReadOnly = true;
            this.rtbEM.Size = new System.Drawing.Size(275, 366);
            this.rtbEM.TabIndex = 1;
            this.rtbEM.Text = "";
            // 
            // pbEM
            // 
            this.pbEM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbEM.Location = new System.Drawing.Point(5, 3);
            this.pbEM.Name = "pbEM";
            this.pbEM.Size = new System.Drawing.Size(404, 367);
            this.pbEM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEM.TabIndex = 0;
            this.pbEM.TabStop = false;
            // 
            // tpMetadata
            // 
            this.tpMetadata.BackColor = System.Drawing.Color.Gainsboro;
            this.tpMetadata.Controls.Add(this.btMeta);
            this.tpMetadata.Controls.Add(this.rtbMeta);
            this.tpMetadata.Controls.Add(this.pbMeta);
            this.tpMetadata.Location = new System.Drawing.Point(4, 22);
            this.tpMetadata.Name = "tpMetadata";
            this.tpMetadata.Size = new System.Drawing.Size(697, 403);
            this.tpMetadata.TabIndex = 4;
            this.tpMetadata.Text = "Metadata";
            // 
            // btMeta
            // 
            this.btMeta.Location = new System.Drawing.Point(608, 352);
            this.btMeta.Name = "btMeta";
            this.btMeta.Size = new System.Drawing.Size(75, 23);
            this.btMeta.TabIndex = 2;
            this.btMeta.Text = "Open..";
            this.btMeta.UseVisualStyleBackColor = true;
            this.btMeta.Click += new System.EventHandler(this.btMeta_Click);
            // 
            // rtbMeta
            // 
            this.rtbMeta.Location = new System.Drawing.Point(371, 4);
            this.rtbMeta.Name = "rtbMeta";
            this.rtbMeta.ReadOnly = true;
            this.rtbMeta.Size = new System.Drawing.Size(313, 341);
            this.rtbMeta.TabIndex = 1;
            this.rtbMeta.Text = "";
            // 
            // pbMeta
            // 
            this.pbMeta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbMeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbMeta.Location = new System.Drawing.Point(4, 4);
            this.pbMeta.Name = "pbMeta";
            this.pbMeta.Size = new System.Drawing.Size(360, 396);
            this.pbMeta.TabIndex = 0;
            this.pbMeta.TabStop = false;
            // 
            // tbCC
            // 
            this.tbCC.BackColor = System.Drawing.Color.LightGray;
            this.tbCC.Controls.Add(this.btChoose);
            this.tbCC.Controls.Add(this.rtbCC);
            this.tbCC.Controls.Add(this.pbCC2);
            this.tbCC.Controls.Add(this.pbCC1);
            this.tbCC.Location = new System.Drawing.Point(4, 22);
            this.tbCC.Name = "tbCC";
            this.tbCC.Size = new System.Drawing.Size(697, 403);
            this.tbCC.TabIndex = 5;
            this.tbCC.Text = "Check Correlation";
            // 
            // btChoose
            // 
            this.btChoose.Location = new System.Drawing.Point(607, 244);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(87, 51);
            this.btChoose.TabIndex = 3;
            this.btChoose.Text = "Choose..";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // rtbCC
            // 
            this.rtbCC.Location = new System.Drawing.Point(4, 244);
            this.rtbCC.Name = "rtbCC";
            this.rtbCC.Size = new System.Drawing.Size(596, 156);
            this.rtbCC.TabIndex = 2;
            this.rtbCC.Text = "";
            // 
            // pbCC2
            // 
            this.pbCC2.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.pbCC2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbCC2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCC2.Location = new System.Drawing.Point(356, 4);
            this.pbCC2.Name = "pbCC2";
            this.pbCC2.Size = new System.Drawing.Size(338, 233);
            this.pbCC2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCC2.TabIndex = 1;
            this.pbCC2.TabStop = false;
            // 
            // pbCC1
            // 
            this.pbCC1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pbCC1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbCC1.Location = new System.Drawing.Point(4, 4);
            this.pbCC1.Name = "pbCC1";
            this.pbCC1.Size = new System.Drawing.Size(338, 233);
            this.pbCC1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCC1.TabIndex = 0;
            this.pbCC1.TabStop = false;
            // 
            // tbDesc
            // 
            this.tbDesc.BackColor = System.Drawing.Color.Gainsboro;
            this.tbDesc.Controls.Add(this.tbH);
            this.tbDesc.Controls.Add(this.tbW);
            this.tbDesc.Controls.Add(this.lbH);
            this.tbDesc.Controls.Add(this.lbW);
            this.tbDesc.Controls.Add(this.tbFN);
            this.tbDesc.Controls.Add(this.lbFN);
            this.tbDesc.Controls.Add(this.pbDes);
            this.tbDesc.Location = new System.Drawing.Point(4, 22);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(697, 403);
            this.tbDesc.TabIndex = 6;
            this.tbDesc.Text = "Description ";
            // 
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(535, 433);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(166, 20);
            this.tbDate.TabIndex = 1;
            // 
            // btDate
            // 
            this.btDate.Location = new System.Drawing.Point(468, 429);
            this.btDate.Name = "btDate";
            this.btDate.Size = new System.Drawing.Size(61, 23);
            this.btDate.TabIndex = 2;
            this.btDate.Text = "Format";
            this.btDate.UseVisualStyleBackColor = true;
            this.btDate.Click += new System.EventHandler(this.btDate_Click);
            // 
            // pbDes
            // 
            this.pbDes.BackColor = System.Drawing.Color.Gainsboro;
            this.pbDes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbDes.Location = new System.Drawing.Point(5, 3);
            this.pbDes.Name = "pbDes";
            this.pbDes.Size = new System.Drawing.Size(290, 327);
            this.pbDes.TabIndex = 0;
            this.pbDes.TabStop = false;
            // 
            // lbFN
            // 
            this.lbFN.AutoSize = true;
            this.lbFN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbFN.Location = new System.Drawing.Point(6, 334);
            this.lbFN.Name = "lbFN";
            this.lbFN.Size = new System.Drawing.Size(54, 15);
            this.lbFN.TabIndex = 1;
            this.lbFN.Text = "File name";
            // 
            // tbFN
            // 
            this.tbFN.Location = new System.Drawing.Point(6, 352);
            this.tbFN.Name = "tbFN";
            this.tbFN.ReadOnly = true;
            this.tbFN.Size = new System.Drawing.Size(289, 20);
            this.tbFN.TabIndex = 2;
            // 
            // lbW
            // 
            this.lbW.AutoSize = true;
            this.lbW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbW.Location = new System.Drawing.Point(322, 14);
            this.lbW.Name = "lbW";
            this.lbW.Size = new System.Drawing.Size(37, 15);
            this.lbW.TabIndex = 3;
            this.lbW.Text = "Width";
            // 
            // lbH
            // 
            this.lbH.AutoSize = true;
            this.lbH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbH.Location = new System.Drawing.Point(485, 14);
            this.lbH.Name = "lbH";
            this.lbH.Size = new System.Drawing.Size(40, 15);
            this.lbH.TabIndex = 4;
            this.lbH.Text = "Height";
            // 
            // tbW
            // 
            this.tbW.Location = new System.Drawing.Point(322, 33);
            this.tbW.Name = "tbW";
            this.tbW.ReadOnly = true;
            this.tbW.Size = new System.Drawing.Size(100, 20);
            this.tbW.TabIndex = 5;
            // 
            // tbH
            // 
            this.tbH.Location = new System.Drawing.Point(485, 33);
            this.tbH.Name = "tbH";
            this.tbH.ReadOnly = true;
            this.tbH.Size = new System.Drawing.Size(100, 20);
            this.tbH.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 457);
            this.Controls.Add(this.btDate);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Program";
            this.tabControl1.ResumeLayout(false);
            this.tpEncrypt.ResumeLayout(false);
            this.tpEncrypt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEI)).EndInit();
            this.tpEmbed.ResumeLayout(false);
            this.tpEmbed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEMM)).EndInit();
            this.tpDecrypt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDI)).EndInit();
            this.tpExtract.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEM)).EndInit();
            this.tpMetadata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMeta)).EndInit();
            this.tbCC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCC1)).EndInit();
            this.tbDesc.ResumeLayout(false);
            this.tbDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpEncrypt;
        private System.Windows.Forms.TabPage tpDecrypt;
        private System.Windows.Forms.TabPage tpEmbed;
        private System.Windows.Forms.TabPage tpExtract;
        private System.Windows.Forms.Button btExtract;
        private System.Windows.Forms.RichTextBox rtbEM;
        private System.Windows.Forms.PictureBox pbEM;
        private System.Windows.Forms.Button btEmbed;
        private System.Windows.Forms.Button btOpenEMM;
        private System.Windows.Forms.RichTextBox rtbEMM;
        private System.Windows.Forms.PictureBox pbEMM;
        private System.Windows.Forms.Button btChooseDI;
        private System.Windows.Forms.PictureBox pbDI;
        private System.Windows.Forms.Button btChooseEI;
        private System.Windows.Forms.PictureBox pbEI;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label lbKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.TabPage tpMetadata;
        private System.Windows.Forms.Button btMeta;
        private System.Windows.Forms.RichTextBox rtbMeta;
        private System.Windows.Forms.PictureBox pbMeta;
        private System.Windows.Forms.Button btDate;
        private System.Windows.Forms.TabPage tbCC;
        private System.Windows.Forms.RichTextBox rtbCC;
        private System.Windows.Forms.PictureBox pbCC2;
        private System.Windows.Forms.PictureBox pbCC1;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TextBox tbMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbDesc;
        private System.Windows.Forms.TextBox tbH;
        private System.Windows.Forms.TextBox tbW;
        private System.Windows.Forms.Label lbH;
        private System.Windows.Forms.Label lbW;
        private System.Windows.Forms.TextBox tbFN;
        private System.Windows.Forms.Label lbFN;
        private System.Windows.Forms.PictureBox pbDes;
    }
}

