namespace COBA2.View
{
    partial class FormProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfile));
            panel1 = new Panel();
            panel2 = new Panel();
            btnRefresh = new Button();
            txtboxAlamat = new Label();
            textBox1 = new TextBox();
            btnEdit = new Button();
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
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(159, 191, 154);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(txtboxAlamat);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(btnEdit);
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
            panel1.Location = new Point(39, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(718, 392);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnRefresh);
            panel2.Location = new Point(232, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(71, 36);
            panel2.TabIndex = 13;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(159, 191, 154);
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(-31, -22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(139, 79);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
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
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(405, 23);
            textBox1.TabIndex = 11;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(104, 167, 124);
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.Location = new Point(594, 362);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblNoHP
            // 
            lblNoHP.AutoSize = true;
            lblNoHP.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNoHP.ForeColor = Color.FromArgb(45, 90, 61);
            lblNoHP.Location = new Point(243, 250);
            lblNoHP.Name = "lblNoHP";
            lblNoHP.Size = new Size(58, 20);
            lblNoHP.TabIndex = 5;
            lblNoHP.Text = "No. Hp";
            lblNoHP.Click += lblNoHP_Click;
            // 
            // txtBoxHp
            // 
            txtBoxHp.Location = new Point(243, 273);
            txtBoxHp.Name = "txtBoxHp";
            txtBoxHp.ReadOnly = true;
            txtBoxHp.Size = new Size(405, 23);
            txtBoxHp.TabIndex = 4;
            txtBoxHp.TextChanged += textBox5_TextChanged;
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
            txtBoxPw.ReadOnly = true;
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
            txtBoxUser.ReadOnly = true;
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
            txtBoxEmail.ReadOnly = true;
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
            txtBoxNama.ReadOnly = true;
            txtBoxNama.Size = new Size(405, 23);
            txtBoxNama.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 48);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FormProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(76, 111, 87);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "FormProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormProfile";
            WindowState = FormWindowState.Maximized;
            Load += FormProfile_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlProfil;
        private TextBox txtBoxNama;
        private Label lblNama;
        private Label lblNoHP;
        private TextBox txtBoxHp;
        private Label lblPw;
        private TextBox txtBoxPw;
        private Label lblusername;
        private TextBox txtBoxUser;
        private Label lblemail;
        private TextBox txtBoxEmail;
        private Button btnEdit;
        private Label txtboxAlamat;
        private TextBox textBox1;
        private Panel panel2;
        private Button btnRefresh;
        private PictureBox pictureBox1;
    }
}