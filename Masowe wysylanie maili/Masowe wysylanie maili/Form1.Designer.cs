namespace Masowe_wysylanie_maili
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Dodaj = new System.Windows.Forms.Button();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.listBoxAdresy = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSMTP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxTemat = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonWyslij = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.listBoxZalaczn = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNadawca = new System.Windows.Forms.TextBox();
            this.labelWyslano = new System.Windows.Forms.Label();
            this.labelNieWyslano = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Dodaj);
            this.groupBox1.Controls.Add(this.textBoxAdres);
            this.groupBox1.Controls.Add(this.listBoxAdresy);
            this.groupBox1.Location = new System.Drawing.Point(32, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 488);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adresat";
            // 
            // button_Dodaj
            // 
            this.button_Dodaj.Location = new System.Drawing.Point(60, 459);
            this.button_Dodaj.Name = "button_Dodaj";
            this.button_Dodaj.Size = new System.Drawing.Size(75, 23);
            this.button_Dodaj.TabIndex = 2;
            this.button_Dodaj.Text = "Dodaj";
            this.button_Dodaj.UseVisualStyleBackColor = true;
            this.button_Dodaj.Click += new System.EventHandler(this.Dodaj_click);
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(6, 433);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(187, 20);
            this.textBoxAdres.TabIndex = 1;
            // 
            // listBoxAdresy
            // 
            this.listBoxAdresy.FormattingEnabled = true;
            this.listBoxAdresy.Location = new System.Drawing.Point(7, 16);
            this.listBoxAdresy.Name = "listBoxAdresy";
            this.listBoxAdresy.Size = new System.Drawing.Size(187, 407);
            this.listBoxAdresy.TabIndex = 0;
            this.listBoxAdresy.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Serwer SMTP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(259, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Temat:";
            // 
            // textBoxSMTP
            // 
            this.textBoxSMTP.Location = new System.Drawing.Point(261, 29);
            this.textBoxSMTP.Name = "textBoxSMTP";
            this.textBoxSMTP.Size = new System.Drawing.Size(207, 20);
            this.textBoxSMTP.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hasło:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(300, 59);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(168, 20);
            this.textBoxLogin.TabIndex = 8;
            // 
            // textBoxTemat
            // 
            this.textBoxTemat.Location = new System.Drawing.Point(262, 188);
            this.textBoxTemat.Name = "textBoxTemat";
            this.textBoxTemat.Size = new System.Drawing.Size(207, 20);
            this.textBoxTemat.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(414, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BUTTONBROWSER_CLICK);
            // 
            // buttonWyslij
            // 
            this.buttonWyslij.Location = new System.Drawing.Point(331, 472);
            this.buttonWyslij.Name = "buttonWyslij";
            this.buttonWyslij.Size = new System.Drawing.Size(75, 23);
            this.buttonWyslij.TabIndex = 3;
            this.buttonWyslij.Text = "Wyślij";
            this.buttonWyslij.UseVisualStyleBackColor = true;
            this.buttonWyslij.Click += new System.EventHandler(this.ButtonWylisj_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(300, 88);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '*';
            this.maskedTextBox1.Size = new System.Drawing.Size(168, 20);
            this.maskedTextBox1.TabIndex = 12;
            // 
            // listBoxZalaczn
            // 
            this.listBoxZalaczn.FormattingEnabled = true;
            this.listBoxZalaczn.HorizontalScrollbar = true;
            this.listBoxZalaczn.Location = new System.Drawing.Point(261, 221);
            this.listBoxZalaczn.Name = "listBoxZalaczn";
            this.listBoxZalaczn.Size = new System.Drawing.Size(145, 108);
            this.listBoxZalaczn.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(261, 348);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 118);
            this.textBox1.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Nadawca:";
            // 
            // textBoxNadawca
            // 
            this.textBoxNadawca.Location = new System.Drawing.Point(261, 147);
            this.textBoxNadawca.Name = "textBoxNadawca";
            this.textBoxNadawca.Size = new System.Drawing.Size(207, 20);
            this.textBoxNadawca.TabIndex = 16;
            // 
            // labelWyslano
            // 
            this.labelWyslano.AutoSize = true;
            this.labelWyslano.Location = new System.Drawing.Point(89, 507);
            this.labelWyslano.Name = "labelWyslano";
            this.labelWyslano.Size = new System.Drawing.Size(56, 13);
            this.labelWyslano.TabIndex = 17;
            this.labelWyslano.Text = "Wysłano: ";
            // 
            // labelNieWyslano
            // 
            this.labelNieWyslano.AutoSize = true;
            this.labelNieWyslano.Location = new System.Drawing.Point(264, 507);
            this.labelNieWyslano.Name = "labelNieWyslano";
            this.labelNieWyslano.Size = new System.Drawing.Size(72, 13);
            this.labelNieWyslano.TabIndex = 21;
            this.labelNieWyslano.Text = "Nie wysłano: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 526);
            this.Controls.Add(this.labelNieWyslano);
            this.Controls.Add(this.labelWyslano);
            this.Controls.Add(this.textBoxNadawca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxZalaczn);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.buttonWyslij);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxTemat);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSMTP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "MailSMTPbyHylus";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Dodaj;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.ListBox listBoxAdresy;
        private System.Windows.Forms.TextBox textBoxSMTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxTemat;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonWyslij;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.ListBox listBoxZalaczn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNadawca;
        private System.Windows.Forms.Label labelWyslano;
        private System.Windows.Forms.Label labelNieWyslano;
    }
}

