using COBA2.App.Core;
using COBA2.App.Model;
using COBA2.App.Context;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace COBA2.View
{
    public partial class FormKatalogAdmin : Form
    {
        private int userId;
        private int produkId;

        public FormKatalogAdmin()
        {
            InitializeComponent();
            LoadData(); // Load data produk pada awal form
        }

        private void FormKatalogAdmin_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AddNoColumns()
        {
            if (dataGridView1.Columns["nomor"] == null)
            {
                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "No",
                    Name = "nomor",
                    ReadOnly = true,
                    DisplayIndex = 0 // Posisi kolom pertama
                };
                dataGridView1.Columns.Insert(0, nomorColumn);
            }
        }

        private void LoadData()
        {
            try
            {

                dataGridView1.DataSource = DatabaseWrapper.GetKatalogData();

                // Menyembunyikan kolom ID produk
                if (dataGridView1.Columns["id_produk"] != null)
                    dataGridView1.Columns["id_produk"].HeaderText = "No";
                if (dataGridView1.Columns["id_kategori"] != null)
                    dataGridView1.Columns["id_kategori"].Visible = false;
                if (dataGridView1.Columns["id_statusproduk"] != null)
                    dataGridView1.Columns["id_statusproduk"].Visible = false;

                // Mengatur header kolom
                if (dataGridView1.Columns["nama_produk"] != null)
                    dataGridView1.Columns["nama_produk"].HeaderText = "Nama Produk";
                if (dataGridView1.Columns["harga"] != null)
                    dataGridView1.Columns["harga"].HeaderText = "Harga";
                if (dataGridView1.Columns["deskripsi_produk"] != null)
                    dataGridView1.Columns["deskripsi_produk"].HeaderText = "Deskripsi";
                if (dataGridView1.Columns["stok"] != null)
                    dataGridView1.Columns["stok"].HeaderText = "Stok";
                if (dataGridView1.Columns["nama_kategori"] != null)
                    dataGridView1.Columns["nama_kategori"].HeaderText = "Kategori";

                if (dataGridView1.Columns.Contains("Update"))
                {
                    dataGridView1.Columns.Remove("Update");
                }

                // Menambahkan kolom tombol Update
                DataGridViewButtonColumn updateButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Update",
                    HeaderText = "Update",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(updateButtonColumn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data produk: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Menampilkan form untuk menambahkan produk baru
                Add_Produk__Katalog_ addKatalogForm = new Add_Produk__Katalog_(produkId); // Asumsikan form untuk menambah data sudah dibuat
                addKatalogForm.ShowDialog();
                LoadData(); // Refresh data setelah menambahkan produk
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat membuka form tambah produk: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dataGridView1.Columns["Update"].Index)
            {
                try
                {
                    int produkId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_produk"].Value);
                    DataTable produkData = DatabaseWrapper.getProdukById(produkId);

                    if (produkData.Rows.Count > 0)
                    {
                        DataRow row = produkData.Rows[0];
                        M_Katalog2 produk = new M_Katalog2
                        {
                            id_produk = produkId,
                            nama_produk = row["nama_produk"].ToString(),
                            harga = Convert.ToDecimal(row["harga"]),
                            deskripsi_produk = row["deskripsi_produk"].ToString(),
                            stok = Convert.ToInt32(row["harga"]),
                            kategori_produk = row["kategori_produk"].ToString()
                        };

                        this.Hide();
                        Add_Produk__Katalog_ addKatalogForm = new Add_Produk__Katalog_(produkId);
                        addKatalogForm.PopulateForm(produk);
                        if (addKatalogForm.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                        this.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("s: " + ex.Message);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormKatalogAdmin_Load_1(object sender, EventArgs e)
        {

        }

        private void h_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBerandaAdmin formBerandaAdmin = new FormBerandaAdmin(userId);
            formBerandaAdmin.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile frmProfile = new FormProfile(userId);
            frmProfile.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Keuangan_Admin form_Keuangan_Admin = new Form_Keuangan_Admin(userId);
            form_Keuangan_Admin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKatalogAdmin formKatalogAdmin = new FormKatalogAdmin();
            formKatalogAdmin.ShowDialog();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
} 