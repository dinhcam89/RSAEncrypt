namespace RSAEncrypt
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_CipherText = new TextBox();
            tb_PlainText = new TextBox();
            bt_Decrypt = new Button();
            lb_RSA = new Label();
            tb_PrimeP = new TextBox();
            tb_PrimeQ = new TextBox();
            tb_uValue = new TextBox();
            lb_PrimeP = new Label();
            lb_PrimeQ = new Label();
            label1 = new Label();
            tb_nValue = new TextBox();
            label2 = new Label();
            tb_eValue = new TextBox();
            tb_dValue = new TextBox();
            label3 = new Label();
            label4 = new Label();
            bt_Encrypt = new Button();
            label5 = new Label();
            label6 = new Label();
            bt_GenerateP = new Button();
            bt_GenerateQ = new Button();
            bt_GenerateE = new Button();
            lb_WarningP = new Label();
            lb_WarningQ = new Label();
            bt_CalcN = new Button();
            bt_CalcU = new Button();
            lb_WarningE = new Label();
            bt_CalcD = new Button();
            lb_WarningD = new Label();
            tb_DecryptedText = new TextBox();
            label7 = new Label();
            bt_Clear = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // tb_CipherText
            // 
            tb_CipherText.Location = new Point(57, 352);
            tb_CipherText.Multiline = true;
            tb_CipherText.Name = "tb_CipherText";
            tb_CipherText.Size = new Size(492, 81);
            tb_CipherText.TabIndex = 0;
            // 
            // tb_PlainText
            // 
            tb_PlainText.Location = new Point(57, 240);
            tb_PlainText.Multiline = true;
            tb_PlainText.Name = "tb_PlainText";
            tb_PlainText.Size = new Size(492, 81);
            tb_PlainText.TabIndex = 2;
            // 
            // bt_Decrypt
            // 
            bt_Decrypt.Font = new Font("Anton", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            bt_Decrypt.Location = new Point(668, 379);
            bt_Decrypt.Name = "bt_Decrypt";
            bt_Decrypt.Size = new Size(115, 56);
            bt_Decrypt.TabIndex = 3;
            bt_Decrypt.Text = "Decrypt";
            bt_Decrypt.UseVisualStyleBackColor = true;
            bt_Decrypt.Click += bt_Decrypt_Click;
            // 
            // lb_RSA
            // 
            lb_RSA.AutoSize = true;
            lb_RSA.Font = new Font("Anton", 21.7499981F, FontStyle.Regular, GraphicsUnit.Point);
            lb_RSA.Location = new Point(12, 9);
            lb_RSA.Name = "lb_RSA";
            lb_RSA.Size = new Size(189, 44);
            lb_RSA.TabIndex = 4;
            lb_RSA.Text = "RSA Encryption";
            // 
            // tb_PrimeP
            // 
            tb_PrimeP.Location = new Point(80, 50);
            tb_PrimeP.Name = "tb_PrimeP";
            tb_PrimeP.Size = new Size(220, 23);
            tb_PrimeP.TabIndex = 5;
            tb_PrimeP.TextChanged += tb_PrimeP_TextChanged;
            // 
            // tb_PrimeQ
            // 
            tb_PrimeQ.Location = new Point(579, 50);
            tb_PrimeQ.Name = "tb_PrimeQ";
            tb_PrimeQ.Size = new Size(220, 23);
            tb_PrimeQ.TabIndex = 6;
            tb_PrimeQ.TextChanged += tb_PrimeQ_TextChanged;
            // 
            // tb_uValue
            // 
            tb_uValue.Location = new Point(80, 145);
            tb_uValue.Name = "tb_uValue";
            tb_uValue.ReadOnly = true;
            tb_uValue.Size = new Size(220, 23);
            tb_uValue.TabIndex = 7;
            // 
            // lb_PrimeP
            // 
            lb_PrimeP.AutoSize = true;
            lb_PrimeP.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            lb_PrimeP.ForeColor = Color.FromArgb(0, 0, 192);
            lb_PrimeP.Location = new Point(15, 50);
            lb_PrimeP.Name = "lb_PrimeP";
            lb_PrimeP.Size = new Size(59, 23);
            lb_PrimeP.TabIndex = 8;
            lb_PrimeP.Text = "Prime P:";
            // 
            // lb_PrimeQ
            // 
            lb_PrimeQ.AutoSize = true;
            lb_PrimeQ.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            lb_PrimeQ.ForeColor = Color.FromArgb(0, 0, 192);
            lb_PrimeQ.Location = new Point(514, 51);
            lb_PrimeQ.Name = "lb_PrimeQ";
            lb_PrimeQ.Size = new Size(59, 23);
            lb_PrimeQ.TabIndex = 9;
            lb_PrimeQ.Text = "Prime Q:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(0, 0, 192);
            label1.Location = new Point(31, 145);
            label1.Name = "label1";
            label1.Size = new Size(41, 23);
            label1.TabIndex = 10;
            label1.Text = "φ(n):";
            // 
            // tb_nValue
            // 
            tb_nValue.Location = new Point(80, 98);
            tb_nValue.Name = "tb_nValue";
            tb_nValue.ReadOnly = true;
            tb_nValue.Size = new Size(220, 23);
            tb_nValue.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(47, 98);
            label2.Name = "label2";
            label2.Size = new Size(21, 23);
            label2.TabIndex = 12;
            label2.Text = "n:";
            // 
            // tb_eValue
            // 
            tb_eValue.Location = new Point(579, 101);
            tb_eValue.Name = "tb_eValue";
            tb_eValue.Size = new Size(220, 23);
            tb_eValue.TabIndex = 13;
            tb_eValue.TextChanged += tb_eValue_TextChanged;
            // 
            // tb_dValue
            // 
            tb_dValue.Location = new Point(579, 148);
            tb_dValue.Name = "tb_dValue";
            tb_dValue.Size = new Size(220, 23);
            tb_dValue.TabIndex = 14;
            tb_dValue.TextChanged += tb_dValue_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(486, 101);
            label3.Name = "label3";
            label3.Size = new Size(87, 23);
            label3.TabIndex = 15;
            label3.Text = "Public key e:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(0, 0, 192);
            label4.Location = new Point(481, 148);
            label4.Name = "label4";
            label4.Size = new Size(92, 23);
            label4.TabIndex = 16;
            label4.Text = "Private key d:";
            // 
            // bt_Encrypt
            // 
            bt_Encrypt.Font = new Font("Anton", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            bt_Encrypt.Location = new Point(668, 292);
            bt_Encrypt.Name = "bt_Encrypt";
            bt_Encrypt.Size = new Size(115, 57);
            bt_Encrypt.TabIndex = 17;
            bt_Encrypt.Text = "Encrypt";
            bt_Encrypt.UseVisualStyleBackColor = true;
            bt_Encrypt.Click += bt_Encrypt_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(25, 214);
            label5.Name = "label5";
            label5.Size = new Size(64, 23);
            label5.TabIndex = 18;
            label5.Text = "PlainText";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(25, 326);
            label6.Name = "label6";
            label6.Size = new Size(73, 23);
            label6.TabIndex = 19;
            label6.Text = "CipherText";
            // 
            // bt_GenerateP
            // 
            bt_GenerateP.BackColor = Color.Transparent;
            bt_GenerateP.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            bt_GenerateP.ForeColor = Color.FromArgb(192, 64, 0);
            bt_GenerateP.Location = new Point(306, 50);
            bt_GenerateP.Name = "bt_GenerateP";
            bt_GenerateP.Size = new Size(64, 24);
            bt_GenerateP.TabIndex = 20;
            bt_GenerateP.Text = "Generate";
            bt_GenerateP.UseVisualStyleBackColor = false;
            bt_GenerateP.Click += bt_GenerateP_Click;
            // 
            // bt_GenerateQ
            // 
            bt_GenerateQ.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            bt_GenerateQ.ForeColor = Color.FromArgb(192, 64, 0);
            bt_GenerateQ.Location = new Point(805, 50);
            bt_GenerateQ.Name = "bt_GenerateQ";
            bt_GenerateQ.Size = new Size(64, 24);
            bt_GenerateQ.TabIndex = 21;
            bt_GenerateQ.Text = "Generate";
            bt_GenerateQ.UseVisualStyleBackColor = true;
            bt_GenerateQ.Click += bt_GenerateQ_Click;
            // 
            // bt_GenerateE
            // 
            bt_GenerateE.BackColor = Color.Transparent;
            bt_GenerateE.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            bt_GenerateE.ForeColor = Color.FromArgb(192, 64, 0);
            bt_GenerateE.Location = new Point(805, 100);
            bt_GenerateE.Name = "bt_GenerateE";
            bt_GenerateE.Size = new Size(64, 24);
            bt_GenerateE.TabIndex = 22;
            bt_GenerateE.Text = "Generate";
            bt_GenerateE.UseVisualStyleBackColor = false;
            bt_GenerateE.Click += bt_GenerateE_Click;
            // 
            // lb_WarningP
            // 
            lb_WarningP.AutoSize = true;
            lb_WarningP.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            lb_WarningP.ForeColor = Color.Red;
            lb_WarningP.Location = new Point(80, 24);
            lb_WarningP.Name = "lb_WarningP";
            lb_WarningP.Size = new Size(0, 15);
            lb_WarningP.TabIndex = 23;
            // 
            // lb_WarningQ
            // 
            lb_WarningQ.AutoSize = true;
            lb_WarningQ.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            lb_WarningQ.ForeColor = Color.Red;
            lb_WarningQ.Location = new Point(579, 24);
            lb_WarningQ.Name = "lb_WarningQ";
            lb_WarningQ.Size = new Size(0, 15);
            lb_WarningQ.TabIndex = 24;
            // 
            // bt_CalcN
            // 
            bt_CalcN.BackColor = Color.Transparent;
            bt_CalcN.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            bt_CalcN.ForeColor = Color.FromArgb(192, 64, 0);
            bt_CalcN.Location = new Point(306, 98);
            bt_CalcN.Name = "bt_CalcN";
            bt_CalcN.Size = new Size(64, 23);
            bt_CalcN.TabIndex = 25;
            bt_CalcN.Text = "Cal";
            bt_CalcN.UseVisualStyleBackColor = false;
            bt_CalcN.Click += bt_CalcN_Click;
            // 
            // bt_CalcU
            // 
            bt_CalcU.BackColor = Color.Transparent;
            bt_CalcU.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            bt_CalcU.ForeColor = Color.FromArgb(192, 64, 0);
            bt_CalcU.Location = new Point(306, 145);
            bt_CalcU.Name = "bt_CalcU";
            bt_CalcU.Size = new Size(64, 23);
            bt_CalcU.TabIndex = 26;
            bt_CalcU.Text = "Cal";
            bt_CalcU.UseVisualStyleBackColor = false;
            bt_CalcU.Click += bt_CalcU_Click;
            // 
            // lb_WarningE
            // 
            lb_WarningE.AutoSize = true;
            lb_WarningE.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            lb_WarningE.ForeColor = Color.FromArgb(0, 0, 192);
            lb_WarningE.Location = new Point(579, 79);
            lb_WarningE.Name = "lb_WarningE";
            lb_WarningE.Size = new Size(0, 19);
            lb_WarningE.TabIndex = 27;
            // 
            // bt_CalcD
            // 
            bt_CalcD.BackColor = Color.Transparent;
            bt_CalcD.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            bt_CalcD.ForeColor = Color.FromArgb(192, 64, 0);
            bt_CalcD.Location = new Point(805, 147);
            bt_CalcD.Name = "bt_CalcD";
            bt_CalcD.Size = new Size(64, 24);
            bt_CalcD.TabIndex = 28;
            bt_CalcD.Text = "Cal";
            bt_CalcD.UseVisualStyleBackColor = false;
            bt_CalcD.Click += bt_CalcD_Click;
            // 
            // lb_WarningD
            // 
            lb_WarningD.AutoSize = true;
            lb_WarningD.Font = new Font("Anton", 9.749999F, FontStyle.Italic, GraphicsUnit.Point);
            lb_WarningD.ForeColor = Color.FromArgb(0, 0, 192);
            lb_WarningD.Location = new Point(579, 126);
            lb_WarningD.Name = "lb_WarningD";
            lb_WarningD.Size = new Size(0, 19);
            lb_WarningD.TabIndex = 29;
            // 
            // tb_DecryptedText
            // 
            tb_DecryptedText.Location = new Point(57, 462);
            tb_DecryptedText.Multiline = true;
            tb_DecryptedText.Name = "tb_DecryptedText";
            tb_DecryptedText.Size = new Size(492, 81);
            tb_DecryptedText.TabIndex = 30;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Anton", 11.249999F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(25, 436);
            label7.Name = "label7";
            label7.Size = new Size(94, 23);
            label7.TabIndex = 31;
            label7.Text = "DecryptedText";
            // 
            // bt_Clear
            // 
            bt_Clear.Font = new Font("Anton", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            bt_Clear.Location = new Point(668, 461);
            bt_Clear.Name = "bt_Clear";
            bt_Clear.Size = new Size(115, 46);
            bt_Clear.TabIndex = 32;
            bt_Clear.Text = "Clear";
            bt_Clear.UseVisualStyleBackColor = true;
            bt_Clear.Click += bt_Clear_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 68);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(918, 617);
            tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tb_PrimeP);
            tabPage1.Controls.Add(lb_WarningQ);
            tabPage1.Controls.Add(lb_WarningD);
            tabPage1.Controls.Add(bt_GenerateQ);
            tabPage1.Controls.Add(lb_PrimeQ);
            tabPage1.Controls.Add(bt_Clear);
            tabPage1.Controls.Add(tb_PrimeQ);
            tabPage1.Controls.Add(bt_CalcD);
            tabPage1.Controls.Add(lb_PrimeP);
            tabPage1.Controls.Add(lb_WarningE);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(bt_CalcU);
            tabPage1.Controls.Add(bt_GenerateP);
            tabPage1.Controls.Add(bt_CalcN);
            tabPage1.Controls.Add(tb_DecryptedText);
            tabPage1.Controls.Add(lb_WarningP);
            tabPage1.Controls.Add(bt_GenerateE);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(tb_CipherText);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(tb_PlainText);
            tabPage1.Controls.Add(tb_dValue);
            tabPage1.Controls.Add(bt_Decrypt);
            tabPage1.Controls.Add(tb_eValue);
            tabPage1.Controls.Add(bt_Encrypt);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(tb_nValue);
            tabPage1.Controls.Add(tb_uValue);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(910, 589);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "RSA";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(977, 589);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Play Fair";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 694);
            Controls.Add(tabControl1);
            Controls.Add(lb_RSA);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MainForm";
            Text = "RSA Encryptor";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_CipherText;
        private TextBox tb_PlainText;
        private Button bt_Decrypt;
        private Label lb_RSA;
        private TextBox tb_PrimeP;
        private TextBox tb_PrimeQ;
        private TextBox tb_uValue;
        private Label lb_PrimeP;
        private Label lb_PrimeQ;
        private Label label1;
        private TextBox tb_nValue;
        private Label label2;
        private TextBox tb_eValue;
        private TextBox tb_dValue;
        private Label label3;
        private Label label4;
        private Button bt_Encrypt;
        private Label label5;
        private Label label6;
        private Button bt_GenerateP;
        private Button bt_GenerateQ;
        private Button bt_GenerateE;
        private Label lb_WarningP;
        private Label lb_WarningQ;
        private Button bt_CalcN;
        private Button bt_CalcU;
        private Label lb_WarningE;
        private Button bt_CalcD;
        private Label lb_WarningD;
        private TextBox tb_DecryptedText;
        private Label label7;
        private Button bt_Clear;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}