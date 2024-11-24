using System;
using System.Windows.Forms;
using COBA2.App.Model; // Pastikan namespace yang benar untuk kelas Prediksi

namespace COBA2.View
{
    public partial class FormPrediksi : Form
    {
        public FormPrediksi()
        {
            InitializeComponent();

            // Menambahkan item ke comboBox1 dan comboBox2
            comboBox1.Items.AddRange(new string[] { "Padi", "Jagung", "Jeruk", "Tomat" });
            comboBox2.Items.AddRange(new string[] { "Phonska", "Urea", "NPK" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil input dari pengguna
                double luasLahan = double.Parse(textBox1.Text); // Input dalam meter persegi
                string komoditas = comboBox1.SelectedItem?.ToString();
                string jenisPupuk = comboBox2.SelectedItem?.ToString();

                // Validasi input
                if (komoditas == null || jenisPupuk == null)
                {
                    MessageBox.Show("Harap pilih komoditas dan jenis pupuk.");
                    return;
                }

                // Hitung prediksi jumlah pupuk
                var prediksi = new Prediksi(luasLahan, komoditas, jenisPupuk);
                double hasil = prediksi.HitungPrediksi();

                // Tampilkan hasil
                MessageBox.Show($"Jumlah pupuk yang dibutuhkan: {hasil} kg", "Prediksi");
            }
            catch (FormatException)
            {
                MessageBox.Show("Harap masukkan angka valid untuk luas lahan.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashCust frmDashCust = new FormDashCust();
            frmDashCust.ShowDialog();
        }
    }
}