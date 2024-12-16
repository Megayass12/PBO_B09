using System;
using System.Data;
using System.Windows.Forms;
using COBA2.App.Context;
using COBA2.App.Core;
using Npgsql;
using COBA2.App.Model; // Pastikan namespace yang benar untuk kelas Prediksi

namespace COBA2.View
{
    public partial class FormPrediksi : Form
    {
        private int userId;
        private DatabaseWrapper dataWrapper;
        public FormPrediksi(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            LoadTanamanData();
            LoadPupukData();

    
        }
        private void LoadTanamanData()
        {
            try
            {
                using (var conn = new NpgsqlConnection($"Host=localhost;Username=postgres;Password=mega1234;Database=coba;Port=5432"))
                {
                    string query = "SELECT DISTINCT tanaman_id FROM prediksi";
                    using (var da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comboBox1.DataSource = dt;
                        comboBox1.DisplayMember = "tanaman_id";
                        comboBox1.ValueMember = "tanaman_id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tanaman data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load data pupuk ke comboBox2
        private void LoadPupukData()
        {
            try
            {
                using (var conn = new NpgsqlConnection($"Host=localhost;Username=postgres;Password=mega1234;Database=coba;Port=5432"))
                {
                    string query = "SELECT DISTINCT pupuk_id FROM prediksi";
                    using (var da = new NpgsqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comboBox2.DataSource = dt;
                        comboBox2.DisplayMember = "pupuk_id";
                        comboBox2.ValueMember = "pupuk_id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pupuk data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fungsi untuk mendapatkan kebutuhan pupuk dari tabel prediksi
        private double GetKebutuhanPupukDariDatabase(int tanamanId, int pupukId)
        {
            try
            {
                using (var conn = new NpgsqlConnection($"Host=localhost;Username=postgres;Password=mega1234;Database=coba;Port=5432"))
                {
                    conn.Open();
                    string query = "SELECT nilai FROM prediksi WHERE tanaman_id = @tanamanId AND pupuk_id = @pupukId";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tanamanId", tanamanId);
                        cmd.Parameters.AddWithValue("@pupukId", pupukId);

                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int nilai))
                        {
                            return nilai;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kesalahan saat mengakses database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1; // Jika data tidak ditemukan
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Validasi input
                if (comboBox1.SelectedValue == null || comboBox2.SelectedValue == null)
                {
                    MessageBox.Show("Silakan pilih Tanaman dan Jenis Pupuk terlebih dahulu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(textBox1.Text, out double luasLahan) || luasLahan <= 0)
                {
                    MessageBox.Show("Masukkan nilai Luas Lahan yang valid dalam hektare.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasi input jarak tanam
                if (!double.TryParse(textBox2.Text, out double jarakTanam) || jarakTanam <= 0)
                {
                    MessageBox.Show("Masukkan nilai Jarak Tanam yang valid dalam meter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox3.Text, out int jumlahBibitPerLubang) || jumlahBibitPerLubang <= 0)
                {
                    MessageBox.Show("Masukkan jumlah bibit per lubang yang valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int tanamanId = Convert.ToInt32(comboBox1.SelectedValue);
                int pupukId = Convert.ToInt32(comboBox2.SelectedValue);

                // Ambil kebutuhan pupuk dari database
                double kebutuhanPerHektar = GetKebutuhanPupukDariDatabase(tanamanId, pupukId);

                if (kebutuhanPerHektar == -1)
                {
                    MessageBox.Show("Data prediksi tidak ditemukan untuk kombinasi Tanaman dan Jenis Pupuk tersebut.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hitung total kebutuhan pupuk
                double totalKebutuhan = kebutuhanPerHektar * luasLahan;

                // Hitung jumlah bibit per hektare
                double jumlahBibitPerHektar = (luasLahan * 10000) / (jarakTanam * jarakTanam) * jumlahBibitPerLubang;

                // Tampilkan hasil
                MessageBox.Show($"Total kebutuhan pupuk: {totalKebutuhan} kg\nJumlah bibit per hektar: {jumlahBibitPerHektar} bibit", "Hasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Gagal memproses prediksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashCust frmDashCust = new FormDashCust(userId);
            frmDashCust.ShowDialog();
        }

        private void FormPrediksi_Load(object sender, EventArgs e)
        {
            // Load data untuk ComboBox Komoditas
            List<M_TanamanPrediksi> tanamanList = C_TanamanPrediksi.GetAll();
            comboBox1.DataSource = tanamanList;
            comboBox1.DisplayMember = "tanaman";
            comboBox1.ValueMember = "id";

            // Load data untuk ComboBox Jenis Pupuk
            List<M_PupukPrediksi> pupukList = C_PupukPrediksi.GetAll();
            comboBox2.DataSource = pupukList;
            comboBox2.DisplayMember = "pupuk";
            comboBox2.ValueMember = "id";
        }
    }
}