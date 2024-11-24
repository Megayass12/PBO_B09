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
    public partial class FormDashCust : Form
    {
        FormCustD dashboard;
        public FormDashCust()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new FormCustD();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }
        }
        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormKatalogC formKatalogC = new FormKatalogC();
            formKatalogC.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormDashCust_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void btnPrediction_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrediksi frmPrediksi = new FormPrediksi();
            frmPrediksi.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfile frmProfile = new FormProfile();
            frmProfile.ShowDialog();
        }
    }
}
