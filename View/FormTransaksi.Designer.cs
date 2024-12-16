namespace COBA2.View
{
    partial class FormTransaksi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransaksi));
            pnlTransaksi = new Panel();
            dataGridView1 = new DataGridView();
            lblHeader = new Label();
            pictureBox1 = new PictureBox();
            pnlTransaksi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlTransaksi
            // 
            pnlTransaksi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlTransaksi.BackColor = Color.FromArgb(76, 111, 87);
            pnlTransaksi.Controls.Add(dataGridView1);
            pnlTransaksi.Location = new Point(42, 71);
            pnlTransaksi.Name = "pnlTransaksi";
            pnlTransaksi.Size = new Size(719, 305);
            pnlTransaksi.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(26, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(673, 230);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(359, 26);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(102, 30);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Transaksi";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 44);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // FormTransaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(193, 244, 151);
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(lblHeader);
            Controls.Add(pnlTransaksi);
            Name = "FormTransaksi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTransaksi";
            WindowState = FormWindowState.Maximized;
            Load += FormTransaksi_Load;
            pnlTransaksi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTransaksi;
        private Label lblHeader;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
    }
}