using COBA2.App.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COBA2.View
{
    public partial class History : Form
    {
        private int userId; //simpan user id buat transaksi
        public History(int userId)
        {
            InitializeComponent();
            this.userId = userId; // user id dari form sebelume
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashCust frmDashCust = new FormDashCust(userId);
            frmDashCust.ShowDialog();
        }

        private void History_Load(object sender, EventArgs e)
        {
            LoadData(userId);
        }


        private void LoadData(int userId)
        {
            try
            {
                // Memanggil data transaksi dari DatabaseWrapper
                DatabaseWrapper dbWrapper = new DatabaseWrapper();
                DataTable transaksiData = dbWrapper.GetTransaksiDone(userId);

                // Mengecek apakah ada data transaksi
                if (transaksiData == null || transaksiData.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada transaksi yang ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Menampilkan data di DataGridView
                    dataGridView1.DataSource = transaksiData;

                    // Pengaturan DataGridView
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    if (dataGridView1.Columns["Status Transaksi"] != null) dataGridView1.Columns["Status Transaksi"].Visible = false;
                    // Memberi nama kolom yang lebih user-friendly (sesuaikan dengan nama kolom di DataTable)
                    if (dataGridView1.Columns.Contains("ID Transaksi"))
                        dataGridView1.Columns["ID Transaksi"].HeaderText = "ID Transaksi";

                    if (dataGridView1.Columns.Contains("Tanggal"))
                        dataGridView1.Columns["Tanggal"].HeaderText = "Tanggal";

                    if (dataGridView1.Columns.Contains("Total Harga"))
                        dataGridView1.Columns["Total Harga"].HeaderText = "Total Harga";

                    if (dataGridView1.Columns.Contains("Produk"))
                        dataGridView1.Columns["Produk"].HeaderText = "Produk";

                    if (dataGridView1.Columns.Contains("Kuantitas"))
                        dataGridView1.Columns["Kuantitas"].HeaderText = "Kuantitas";

                    if (dataGridView1.Columns.Contains("Harga Satuan"))
                        dataGridView1.Columns["Harga Satuan"].HeaderText = "Harga Satuan";

                    if (dataGridView1.Columns.Contains("Status Pesanan"))
                        dataGridView1.Columns["Status Pesanan"].HeaderText = "Status Pesanan";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat memuat data: " + ex.Message);
            }
        }
    }
}
