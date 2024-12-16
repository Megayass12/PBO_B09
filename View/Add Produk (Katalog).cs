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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace COBA2.View
{
    public partial class Add_Produk__Katalog_ : Form
    {
        private int produkId { get; set; }

        public bool IsEditMode { get; set; } = false; // Mode Add/Edit
        

        public Add_Produk__Katalog_(int produkId)
        {
            InitializeComponent();
            UpdateButtonText(); // Sesuaikan teks tombol
            LoadKategoriData(); // Load kategori ke ComboBox
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Logika ketika tombol Cancel ditekan
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e) // Tombol Add/Update
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Input tidak valid. Mohon lengkapi semua data dengan benar.");
                return;
            }


            // Ambil data dari input
            string namaProduk = textBox1.Text; // Nama produk
            decimal harga = decimal.Parse(textBox2.Text); // Harga
            string deskripsi = textBox3.Text; // Deskripsi produk
            int stok = int.Parse(textBox4.Text); // Stok
            var selectedKategori = (KeyValuePair<string, string>)comboBox1.SelectedItem;
            string kategoriId = selectedKategori.Key;
            //string kategori = comboBox1.Text; // Kategori

            // Simpan data ke database
            if (IsEditMode) // Mode Edit
            {
                M_Katalog2 katalog = new M_Katalog2
                {
                    id_produk = produkId,
                    nama_produk = namaProduk,
                    harga = harga,
                    deskripsi_produk = deskripsi,
                    stok = stok,
                    kategori_produk = kategoriId
                };

                C_Katalog1.UpdateKatalog(katalog);
                FormKatalogAdmin formKatalogAdmin = new FormKatalogAdmin();
                MessageBox.Show("produk berhasil diperbarui");
            }
            else // Mode Add
            {
                M_Katalog2 katalogBaru = new M_Katalog2
                {
                    nama_produk = namaProduk,
                    harga = harga,
                    deskripsi_produk = deskripsi,
                    stok = stok,
                    kategori_produk = kategoriId
                };

                C_Katalog1.AddKatalog(katalogBaru);

                MessageBox.Show("Produk baru berhasil ditambahkan.");
            }

            ClearFields(); // Bersihkan input
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
        public void PopulateForm(M_Katalog2 produk)
        {
            // Memuat data kategori ke comboBox jika ada
            LoadKategoriData();

            // Mengisi form dengan data produk yang ada
            textBox1.Text = produk.nama_produk;
            textBox2.Text = produk.harga.ToString("N2"); // Format harga
            textBox3.Text = produk.deskripsi_produk;
            textBox4.Text = produk.stok.ToString();
            comboBox1.Text = produk.kategori_produk; // Pilih kategori sesuai data produk

            // Menandai bahwa ini adalah mode edit
            IsEditMode = true;

            // Menyimpan ID produk yang sedang diedit (opsional jika diperlukan)
            produkId = produk.id_produk;

            // Memperbarui teks tombol sesuai mode
            UpdateButtonText();
        }

        private void LoadKategoriData()
        {
            comboBox1.Items.Clear();

            // Tambahkan kategori sebagai KeyValuePair
            comboBox1.Items.Add(new KeyValuePair<string, string>("1", "Pupuk"));
            comboBox1.Items.Add(new KeyValuePair<string, string>("2", "Benih"));

            // Tampilkan hanya nilai string (Nama) di ComboBox
            comboBox1.DisplayMember = "Value"; // Menampilkan nama kategori
            comboBox1.ValueMember = "Key";     // Menyimpan id kategori
        }

        private bool ValidateInput()
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                !decimal.TryParse(textBox2.Text, out _) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                !int.TryParse(textBox4.Text, out _) ||
                comboBox1.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void UpdateButtonText()
        {
            button2.Text = IsEditMode ? "Update" : "Add";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}