namespace COBA2.View
{
    partial class FormEditProfil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditProfil));
            panel1 = new Panel();
            panel2 = new Panel();
            btnBack = new Button();
            txtboxAlamat = new Label();
            textBox1 = new TextBox();
            btnSave = new Button();
            lblNoHP = new Label();
            txtBoxHp = new TextBox();
            lblPw = new Label();
            txtBoxPw = new TextBox();
            lblusername = new Label();
            txtBoxUser = new TextBox();
            lblemail = new Label();
            txtBoxEmail = new TextBox();
            lblNama = new Label();
            pnlProfil = new Panel();
            txtBoxNama = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(159, 191, 154);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtboxAlamat);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(lblNoHP);
            panel1.Controls.Add(txtBoxHp);
            panel1.Controls.Add(lblPw);
            panel1.Controls.Add(txtBoxPw);
            panel1.Controls.Add(lblusername);
            panel1.Controls.Add(txtBoxUser);
            panel1.Controls.Add(lblemail);
            panel1.Controls.Add(txtBoxEmail);
            panel1.Controls.Add(lblNama);
            panel1.Controls.Add(pnlProfil);
            panel1.Controls.Add(txtBoxNama);
            panel1.Location = new Point(41, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(718, 392);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnBack);
            panel2.Location = new Point(232, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(71, 36);
            panel2.TabIndex = 13;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(159, 191, 154);
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(-31, -22);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(139, 79);
            btnBack.TabIndex = 14;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // txtboxAlamat
            // 
            txtboxAlamat.AutoSize = true;
            txtboxAlamat.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtboxAlamat.ForeColor = Color.FromArgb(45, 90, 61);
            txtboxAlamat.Location = new Point(243, 310);
            txtboxAlamat.Name = "txtboxAlamat";
            txtboxAlamat.Size = new Size(60, 20);
            txtboxAlamat.TabIndex = 12;
            txtboxAlamat.Text = "Alamat";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(243, 333);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(405, 23);
            textBox1.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(104, 167, 124);
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(594, 362);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // lblNoHP
            // 
            lblNoHP.AutoSize = true;
            lblNoHP.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoHP.ForeColor = Color.FromArgb(45, 90, 61);
            lblNoHP.Location = new Point(243, 250);
            lblNoHP.Name = "lblNoHP";
            lblNoHP.Size = new Size(115, 20);
            lblNoHP.TabIndex = 5;
            lblNoHP.Text = "Phone Number";
            // 
            // txtBoxHp
            // 
            txtBoxHp.Location = new Point(243, 273);
            txtBoxHp.Name = "txtBoxHp";
            txtBoxHp.Size = new Size(405, 23);
            txtBoxHp.TabIndex = 4;
            // 
            // lblPw
            // 
            lblPw.AutoSize = true;
            lblPw.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPw.ForeColor = Color.FromArgb(45, 90, 61);
            lblPw.Location = new Point(243, 198);
            lblPw.Name = "lblPw";
            lblPw.Size = new Size(76, 20);
            lblPw.TabIndex = 9;
            lblPw.Text = "Password";
            // 
            // txtBoxPw
            // 
            txtBoxPw.Location = new Point(243, 221);
            txtBoxPw.Name = "txtBoxPw";
            txtBoxPw.Size = new Size(405, 23);
            txtBoxPw.TabIndex = 8;
            // 
            // lblusername
            // 
            lblusername.AutoSize = true;
            lblusername.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblusername.ForeColor = Color.FromArgb(45, 90, 61);
            lblusername.Location = new Point(243, 140);
            lblusername.Name = "lblusername";
            lblusername.Size = new Size(80, 20);
            lblusername.TabIndex = 7;
            lblusername.Text = "Username";
            // 
            // txtBoxUser
            // 
            txtBoxUser.Location = new Point(243, 163);
            txtBoxUser.Name = "txtBoxUser";
            txtBoxUser.Size = new Size(405, 23);
            txtBoxUser.TabIndex = 6;
            // 
            // lblemail
            // 
            lblemail.AutoSize = true;
            lblemail.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblemail.ForeColor = Color.FromArgb(45, 90, 61);
            lblemail.Location = new Point(243, 91);
            lblemail.Name = "lblemail";
            lblemail.Size = new Size(47, 20);
            lblemail.TabIndex = 5;
            lblemail.Text = "Email";
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Location = new Point(243, 114);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(405, 23);
            txtBoxEmail.TabIndex = 4;
            // 
            // lblNama
            // 
            lblNama.AutoSize = true;
            lblNama.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNama.ForeColor = Color.FromArgb(45, 90, 61);
            lblNama.Location = new Point(243, 42);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(51, 20);
            lblNama.TabIndex = 3;
            lblNama.Text = "Nama";
            // 
            // pnlProfil
            // 
            pnlProfil.BackgroundImage = (Image)resources.GetObject("pnlProfil.BackgroundImage");
            pnlProfil.Location = new Point(21, 13);
            pnlProfil.Name = "pnlProfil";
            pnlProfil.Size = new Size(163, 163);
            pnlProfil.TabIndex = 2;
            // 
            // txtBoxNama
            // 
            txtBoxNama.Location = new Point(243, 65);
            txtBoxNama.Name = "txtBoxNama";
            txtBoxNama.Size = new Size(405, 23);
            txtBoxNama.TabIndex = 1;
            // 
            // FormEditProfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 111, 87);
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "FormEditProfil";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEditProfil";
            WindowState = FormWindowState.Maximized;
            Load += FormEditProfil_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnBack;
        private Label txtboxAlamat;
        private TextBox textBox1;
        private Button btnSave;
        private Label lblNoHP;
        private TextBox txtBoxHp;
        private Label lblPw;
        private TextBox txtBoxPw;
        private Label lblusername;
        private TextBox txtBoxUser;
        private Label lblemail;
        private TextBox txtBoxEmail;
        private Label lblNama;
        private Panel pnlProfil;
        private TextBox txtBoxNama;
    }
}