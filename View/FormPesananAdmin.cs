using COBA2.App.Context;
using COBA2.App.Core;
using COBA2.App.Model;
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
    public partial class FormPesananAdmin : Form
    {
        private int userId =9;
        private int transaksiId;
        public FormPesananAdmin(int transaksiId)
        {
            InitializeComponent();
            LoadTransaksiData();
            

        }


        private void FormPesananAdmin_Load(object sender, EventArgs e)
        {
            LoadTransaksiData();

        }

        private void AddNoColumns()
        {
            if (dataGridView1.Columns["nomor"] == null)
            {
                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "No",
                    Name = "nomor",
                    DisplayIndex = 0
                };
                dataGridView1.Columns.Add(nomorColumn);
            }
        }

        private void ResetCustomColumns()
        {
            if (dataGridView1.Columns["nomor"] != null)
                dataGridView1.Columns.Remove("nomor");
        }

        public void LoadTransaksiData()
        {
            try
            {
                ResetCustomColumns();

                dataGridView1.DataSource = DatabaseWrapper.GetTransaksiData();

                if (dataGridView1.Columns["id_transaksi"] != null)
                    dataGridView1.Columns["id_transaksi"].HeaderText = "No";


                if (dataGridView1.Columns["tanggal"] != null)
                    dataGridView1.Columns["tanggal"].HeaderText = "Tanggal";
                if (dataGridView1.Columns["kuantitas"] != null)
                    dataGridView1.Columns["kuantitas"].HeaderText = "Kuantitas";
                if (dataGridView1.Columns["nama_produk"] != null)
                    dataGridView1.Columns["nama_produk"].HeaderText = "Nama Produk";
                if (dataGridView1.Columns["harga"] != null)
                    dataGridView1.Columns["harga"].HeaderText = "Harga";
                if (dataGridView1.Columns["total_harga"] != null)
                    dataGridView1.Columns["total_harga"].HeaderText = "Total Harga";
                if (dataGridView1.Columns["nama_kategori"] != null)
                    dataGridView1.Columns["nama_kategori"].HeaderText = "Kategori";
                if (dataGridView1.Columns["nama_statusproduk"] != null)
                    dataGridView1.Columns["nama_statusproduk"].HeaderText = "Status Produk";
                if (dataGridView1.Columns["nama_status"] != null)
                    dataGridView1.Columns["nama_status"].HeaderText = "Status";

                if (dataGridView1.Columns.Contains("Update"))
                {
                    dataGridView1.Columns.Remove("Update");
                }

                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Update",
                    HeaderText = "Update",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(updateButtonColumn);

                dataGridView1.DataError += dataGridView1_DataError;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Terjadi error saat mengisi DataGridView: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
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

        private void buttonReload_Click(object sender, EventArgs e)
        {
            LoadTransaksiData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void h_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index)
            {
                try
                {
                    int transaksiId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_transaksi"].Value);
                    DataTable transaksiData = C_Transaksi.getTransaksiById(transaksiId);

                    if (transaksiData.Rows.Count > 0)
                    {
                        DataRow row = transaksiData.Rows[0];
                        M_Transaksi transaksi = new M_Transaksi
                        {
                            id_transaksi = transaksiId,
                            status_id = Convert.ToInt32(row["id_status"]),
                            tanggal = row["tanggal"].ToString(),
                            kuantitas = Convert.ToInt32(row["kuantitas"]),

                            Katalog = new M_Katalog2
                            {
                                id_produk = Convert.ToInt32(row["id_produk"]),
                                nama_produk = row["nama_produk"].ToString(),
                                harga = Convert.ToDecimal(row["harga"]),
                            },
                            StatusTransaksi = new M_StatusTransaksi
                            {
                                id_status = Convert.ToInt32(row["id_status"]),
                                nama_status = row["nama_status"].ToString()
                            }
                        };


                        this.Hide();


                        FormEditStatusTransaksi editForm = new FormEditStatusTransaksi();
                        editForm.PopulateForm(transaksi);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadTransaksiData();
                        }

                        this.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPesananAdmin formPesananAdmin = new FormPesananAdmin(userId);
            formPesananAdmin.ShowDialog();



        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile formProfile = new FormProfile(userId);
            formProfile.ShowDialog();
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
