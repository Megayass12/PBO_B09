using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class FormBerandaAdmin : Form
    {
        private int userId = 9;
        private int transaksiId;
        public FormBerandaAdmin(int userId)
        {
            InitializeComponent();
            MessageBox.Show($"UserId di Load : {this.userId}");

        }

        private void h_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile frmProfile = new FormProfile(userId);
            frmProfile.ShowDialog();
        }

        private void FormBerandaAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBerandaAdmin formBerandaAdmin = new FormBerandaAdmin(userId);
            formBerandaAdmin.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FormPesananAdmin formPesananAdmin = new FormPesananAdmin(transaksiId);
                this.Hide();
                formPesananAdmin.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat membuka halaman transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form_Keuangan_Admin form_Keuangan_Admin = new Form_Keuangan_Admin(userId);
            form_Keuangan_Admin.ShowDialog();
        }
    }
}
