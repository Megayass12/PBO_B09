namespace COBA2.View
{
    partial class FormEditStatusTransaksi
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
            comboBoxStatusTransaksi = new ComboBox();
            buttonUpdateStatus = new Button();
            buttonCancel = new Button();
            textBoxTanggal = new TextBox();
            textBoxKuantitas = new TextBox();
            textBoxNamaProduk = new TextBox();
            textBoxHarga = new TextBox();
            textBoxTotalHarga = new TextBox();
            textBoxStatusProduk = new TextBox();
            labelTanggal = new Label();
            labelKuantitas = new Label();
            labelNama_Produk = new Label();
            textBoxIdTransaksi = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // comboBoxStatusTransaksi
            // 
            comboBoxStatusTransaksi.FormattingEnabled = true;
            comboBoxStatusTransaksi.Location = new Point(179, 204);
            comboBoxStatusTransaksi.Margin = new Padding(3, 2, 3, 2);
            comboBoxStatusTransaksi.Name = "comboBoxStatusTransaksi";
            comboBoxStatusTransaksi.Size = new Size(120, 23);
            comboBoxStatusTransaksi.TabIndex = 0;
            comboBoxStatusTransaksi.SelectedIndexChanged += comboBoxStatusTransaksi_SelectedIndexChanged;
            // 
            // buttonUpdateStatus
            // 
            buttonUpdateStatus.Location = new Point(357, 257);
            buttonUpdateStatus.Margin = new Padding(3, 2, 3, 2);
            buttonUpdateStatus.Name = "buttonUpdateStatus";
            buttonUpdateStatus.Size = new Size(82, 22);
            buttonUpdateStatus.TabIndex = 1;
            buttonUpdateStatus.Text = "Update";
            buttonUpdateStatus.UseVisualStyleBackColor = true;
            buttonUpdateStatus.Click += buttonUpdateStatus_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(252, 257);
            buttonCancel.Margin = new Padding(3, 2, 3, 2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(87, 22);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxTanggal
            // 
            textBoxTanggal.Location = new Point(179, 56);
            textBoxTanggal.Margin = new Padding(3, 2, 3, 2);
            textBoxTanggal.Name = "textBoxTanggal";
            textBoxTanggal.Size = new Size(196, 23);
            textBoxTanggal.TabIndex = 3;
            textBoxTanggal.TextChanged += textBoxTanggal_TextChanged;
            // 
            // textBoxKuantitas
            // 
            textBoxKuantitas.Location = new Point(179, 80);
            textBoxKuantitas.Margin = new Padding(3, 2, 3, 2);
            textBoxKuantitas.Name = "textBoxKuantitas";
            textBoxKuantitas.Size = new Size(196, 23);
            textBoxKuantitas.TabIndex = 4;
            // 
            // textBoxNamaProduk
            // 
            textBoxNamaProduk.Location = new Point(179, 105);
            textBoxNamaProduk.Margin = new Padding(3, 2, 3, 2);
            textBoxNamaProduk.Name = "textBoxNamaProduk";
            textBoxNamaProduk.Size = new Size(196, 23);
            textBoxNamaProduk.TabIndex = 5;
            // 
            // textBoxHarga
            // 
            textBoxHarga.Location = new Point(179, 130);
            textBoxHarga.Margin = new Padding(3, 2, 3, 2);
            textBoxHarga.Name = "textBoxHarga";
            textBoxHarga.Size = new Size(196, 23);
            textBoxHarga.TabIndex = 6;
            // 
            // textBoxTotalHarga
            // 
            textBoxTotalHarga.Location = new Point(179, 154);
            textBoxTotalHarga.Margin = new Padding(3, 2, 3, 2);
            textBoxTotalHarga.Name = "textBoxTotalHarga";
            textBoxTotalHarga.Size = new Size(196, 23);
            textBoxTotalHarga.TabIndex = 7;
            // 
            // textBoxStatusProduk
            // 
            textBoxStatusProduk.Location = new Point(179, 179);
            textBoxStatusProduk.Margin = new Padding(3, 2, 3, 2);
            textBoxStatusProduk.Name = "textBoxStatusProduk";
            textBoxStatusProduk.Size = new Size(196, 23);
            textBoxStatusProduk.TabIndex = 9;
            textBoxStatusProduk.TextChanged += textBoxStatusProduk_TextChanged;
            // 
            // labelTanggal
            // 
            labelTanggal.AutoSize = true;
            labelTanggal.Location = new Point(67, 61);
            labelTanggal.Name = "labelTanggal";
            labelTanggal.Size = new Size(48, 15);
            labelTanggal.TabIndex = 10;
            labelTanggal.Text = "Tanggal";
            labelTanggal.Click += label1_Click;
            // 
            // labelKuantitas
            // 
            labelKuantitas.AutoSize = true;
            labelKuantitas.Location = new Point(67, 86);
            labelKuantitas.Name = "labelKuantitas";
            labelKuantitas.Size = new Size(56, 15);
            labelKuantitas.TabIndex = 11;
            labelKuantitas.Text = "Kuantitas";
            // 
            // labelNama_Produk
            // 
            labelNama_Produk.AutoSize = true;
            labelNama_Produk.Location = new Point(67, 110);
            labelNama_Produk.Name = "labelNama_Produk";
            labelNama_Produk.Size = new Size(80, 15);
            labelNama_Produk.TabIndex = 12;
            labelNama_Produk.Text = "Nama Produk";
            // 
            // textBoxIdTransaksi
            // 
            textBoxIdTransaksi.Location = new Point(179, 31);
            textBoxIdTransaksi.Margin = new Padding(3, 2, 3, 2);
            textBoxIdTransaksi.Name = "textBoxIdTransaksi";
            textBoxIdTransaksi.Size = new Size(196, 23);
            textBoxIdTransaksi.TabIndex = 13;
            textBoxIdTransaksi.TextChanged += textBoxIdTransaksi_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 36);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 14;
            label1.Text = "ID Transaksi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 135);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 15;
            label2.Text = "Harga";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 160);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 16;
            label3.Text = "Total Tanggal";
            label3.Click += label3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 182);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 18;
            label5.Text = "Status Transaksi";
            // 
            // FormEditStatusTransaksi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(193, 244, 151);
            ClientSize = new Size(534, 338);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxIdTransaksi);
            Controls.Add(labelNama_Produk);
            Controls.Add(labelKuantitas);
            Controls.Add(labelTanggal);
            Controls.Add(textBoxStatusProduk);
            Controls.Add(textBoxTotalHarga);
            Controls.Add(textBoxHarga);
            Controls.Add(textBoxNamaProduk);
            Controls.Add(textBoxKuantitas);
            Controls.Add(textBoxTanggal);
            Controls.Add(buttonCancel);
            Controls.Add(buttonUpdateStatus);
            Controls.Add(comboBoxStatusTransaksi);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormEditStatusTransaksi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormEditStatusTransaksi";
            WindowState = FormWindowState.Maximized;
            Load += FormEditStatusTransaksi_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxStatusTransaksi;
        private Button buttonUpdateStatus;
        private Button buttonCancel;
        private TextBox textBoxTanggal;
        private TextBox textBoxKuantitas;
        private TextBox textBoxNamaProduk;
        private TextBox textBoxHarga;
        private TextBox textBoxTotalHarga;
        private TextBox textBoxStatusProduk;
        private Label labelTanggal;
        private Label labelKuantitas;
        private Label labelNama_Produk;
        private TextBox textBoxIdTransaksi;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
    }
}