using COBA2.App.Context;
using COBA2.App.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COBA2.View
{

    public partial class Form_Keuangan_Admin : Form
    {
        private int userId = 9;
        private readonly C_Transaksi _controller;
        public Form_Keuangan_Admin(int userId)
        {
            InitializeComponent();
            _controller = new C_Transaksi();
            this.userId = userId;
        }
        private void Form_Keuangan_Admin_Load(object sender, EventArgs e)
        {
            int bulan = DateTime.Now.Month;
            int tahun = DateTime.Now.Year;

            comboBoxBulan.SelectedIndex = bulan - 1;
            textBoxTahun.Text = tahun.ToString();

            if (dataGridView1.Columns["id_transaksi"] != null)
                dataGridView1.Columns["id_transaksi"].HeaderText = "No";

            DisplayTransaksi(bulan, tahun);
        }
        private void DisplayTransaksi(int bulan, int tahun)
        {
            try
            {
                DataTable transaksiData = _controller.GetTransaksiPerBulanTahun(bulan, tahun);
                if (transaksiData != null)
                {
                    dataGridView1.DataSource = transaksiData;
                    if (dataGridView1.Columns["id_transaksi"] != null)
                        dataGridView1.Columns["id_transaksi"].HeaderText = "No";

                    if (dataGridView1.Columns["tanggal_transaksi"] != null)
                        dataGridView1.Columns["tanggal_transaksi"].HeaderText = "Tanggal";

                    if (dataGridView1.Columns["kuantitas"] != null)
                        dataGridView1.Columns["kuantitas"].HeaderText = "Kuantitas";

                    if (dataGridView1.Columns["nama_produk"] != null)
                        dataGridView1.Columns["nama_produk"].HeaderText = "Nama Produk";

                    if (dataGridView1.Columns["harga"] != null)
                        dataGridView1.Columns["harga"].HeaderText = "Harga";

                    if (dataGridView1.Columns["total_harga"] != null)
                        dataGridView1.Columns["total_harga"].HeaderText = "Total Harga";

                    if (dataGridView1.Columns["nama_status"] != null)
                        dataGridView1.Columns["nama_status"].HeaderText = "Status";
                }
                else
                {
                    MessageBox.Show("Tidak ada transaksi ditemukan untuk bulan dan tahun yang dipilih.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mengambil data transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxBulan_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBoxTahun_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                FormBerandaAdmin formBerandaAdmin = new FormBerandaAdmin(userId);
                this.Hide();
                formBerandaAdmin.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat membuka halaman transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            int bulan = comboBoxBulan.SelectedIndex + 1;
            if (int.TryParse(textBoxTahun.Text, out int tahun) && tahun >= 2000 && tahun <= 2100)
            {
                DisplayTransaksi(bulan, tahun);
            }
            else
            {
                MessageBox.Show("Tahun yang dimasukkan tidak valid. Silakan masukkan angka tahun antara 2000 dan 2100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Keuangan_Admin formTransaksi = new Form_Keuangan_Admin(userId);
                this.Hide();
                formTransaksi.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat membuka halaman transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    FormPesananAdmin formTransaksi = new FormPesananAdmin();
            //    this.Hide();
            //    formTransaksi.ShowDialog();
            //    this.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error saat membuka halaman transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnKatalog_Click(object sender, EventArgs e)
        {
            try
            {
                FormKatalogAdmin formKatalog = new FormKatalogAdmin();
                this.Hide();
                formKatalog.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat membuka halaman katalog: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile frmProfile = new FormProfile(userId);
            frmProfile.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Apakah Anda yakin ingin keluar?",        // Pesan popup
               "Konfirmasi Keluar",                     // Judul popup
               MessageBoxButtons.YesNo,                 // Tombol Yes dan No
               MessageBoxIcon.Question                  // Ikon pertanyaan
           );

            // Mengecek tombol yang dipilih pengguna
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Anda telah keluar!");
                this.Hide();
                FormLand frmLand = new FormLand();
                frmLand.ShowDialog();
            }
            else
            {
                MessageBox.Show("Aksi dibatalkan.");


            }
        }
    }
}
