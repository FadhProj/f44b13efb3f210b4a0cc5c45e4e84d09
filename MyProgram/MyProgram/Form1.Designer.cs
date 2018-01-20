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
            this.btChooseEI = new System.Windows.Forms.Button();
            this.pbEI = new System.Windows.Forms.PictureBox();
            this.tpEmbed = new System.Windows.Forms.TabPage();
            this.btEmbed = new System.Windows.Forms.Button();
            this.btOpenEMM = new System.Windows.Forms.Button();
            this.rtbEMM = new System.Windows.Forms.RichTextBox();
            this.pbEMM = new System.Windows.Forms.PictureBox();
            this.tpDecrypt = new System.Windows.Forms.TabPage();
            this.btChooseDI = new System.Windows.Forms.Button();
            this.pbDI = new System.Windows.Forms.PictureBox();
            this.tpExtract = new System.Windows.Forms.TabPage();
            this.btExtract = new System.Windows.Forms.Button();
            this.btOpenEM = new System.Windows.Forms.Button();
            this.rtbEM = new System.Windows.Forms.RichTextBox();
            this.pbEM = new System.Windows.Forms.PictureBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.lbKey = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpEncrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEI)).BeginInit();
            this.tpEmbed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEMM)).BeginInit();
            this.tpDecrypt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDI)).BeginInit();
            this.tpExtract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEM)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpEncrypt);
            this.tabControl1.Controls.Add(this.tpEmbed);
            this.tabControl1.Controls.Add(this.tpDecrypt);
            this.tabControl1.Controls.Add(this.tpExtract);
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(702, 429);
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
            this.tpEncrypt.Size = new System.Drawing.Size(694, 403);
            this.tpEncrypt.TabIndex = 0;
            this.tpEncrypt.Text = "Encrypt Image";
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
            this.tpEmbed.Controls.Add(this.btEmbed);
            this.tpEmbed.Controls.Add(this.btOpenEMM);
            this.tpEmbed.Controls.Add(this.rtbEMM);
            this.tpEmbed.Controls.Add(this.pbEMM);
            this.tpEmbed.Location = new System.Drawing.Point(4, 22);
            this.tpEmbed.Name = "tpEmbed";
            this.tpEmbed.Size = new System.Drawing.Size(694, 420);
            this.tpEmbed.TabIndex = 3;
            this.tpEmbed.Text = "Embending Message";
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
            // 
            // rtbEMM
            // 
            this.rtbEMM.Location = new System.Drawing.Point(415, 4);
            this.rtbEMM.Name = "rtbEMM";
            this.rtbEMM.Size = new System.Drawing.Size(275, 366);
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
            this.tpDecrypt.Size = new System.Drawing.Size(694, 420);
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
            this.tpExtract.Controls.Add(this.btOpenEM);
            this.tpExtract.Controls.Add(this.rtbEM);
            this.tpExtract.Controls.Add(this.pbEM);
            this.tpExtract.Location = new System.Drawing.Point(4, 22);
            this.tpExtract.Name = "tpExtract";
            this.tpExtract.Size = new System.Drawing.Size(694, 420);
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
            // 
            // btOpenEM
            // 
            this.btOpenEM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btOpenEM.Location = new System.Drawing.Point(333, 377);
            this.btOpenEM.Name = "btOpenEM";
            this.btOpenEM.Size = new System.Drawing.Size(75, 23);
            this.btOpenEM.TabIndex = 2;
            this.btOpenEM.Text = "Open File ...";
            this.btOpenEM.UseVisualStyleBackColor = false;
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
            // tbDate
            // 
            this.tbDate.Location = new System.Drawing.Point(535, 433);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(166, 20);
            this.tbDate.TabIndex = 1;
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(41, 379);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(188, 20);
            this.tbKey.TabIndex = 5;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 457);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Program";
            this.tabControl1.ResumeLayout(false);
            this.tpEncrypt.ResumeLayout(false);
            this.tpEncrypt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEI)).EndInit();
            this.tpEmbed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEMM)).EndInit();
            this.tpDecrypt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDI)).EndInit();
            this.tpExtract.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbEM)).EndInit();
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
        private System.Windows.Forms.Button btOpenEM;
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
    }
}

