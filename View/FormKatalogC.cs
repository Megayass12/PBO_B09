using COBA2.App.Core;
using System;
using System.Data;
using System.Windows.Forms;

namespace COBA2.View
{
    public partial class FormKatalogC : Form
    {
        public FormKatalogC()
        {
            InitializeComponent();
            AddNoColumns();
            LoadPupukData();
            AddAddLessColumns();
        }

        private void FormKatalogC_Load(object sender, EventArgs e)
        {
            LoadPupukData();
        }

        private void AddNoColumns()
        {
            // Cek apakah kolom "nomor" sudah ada
            if (dataGridView1.Columns["nomor"] == null)
            {
                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "No",
                    Name = "nomor",
                    DisplayIndex = 0 // Pastikan kolom ini di urutan pertama
                };
                dataGridView1.Columns.Add(nomorColumn);
            }
        }

        private void ResetCustomColumns()
        {
            // Hapus kolom custom jika ada
            if (dataGridView1.Columns["nomor"] != null)
                dataGridView1.Columns.Remove("nomor");
            if (dataGridView1.Columns["Tambah"] != null)
                dataGridView1.Columns.Remove("Tambah");
            if (dataGridView1.Columns["Kurang"] != null)
                dataGridView1.Columns.Remove("Kurang");
        }

        private void AddAddLessColumns()
        {
            // Cek apakah kolom "Tambah" sudah ada
            if (dataGridView1.Columns["Tambah"] == null)
            {
                DataGridViewButtonColumn tambahButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Tambah",
                    HeaderText = "Tambah",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    DisplayIndex = 4 // Tambahkan di urutan akhir
                };
                dataGridView1.Columns.Add(tambahButtonColumn);
            }

            // Cek apakah kolom "Kurang" sudah ada
            if (dataGridView1.Columns["Kurang"] == null)
            {
                DataGridViewButtonColumn kurangButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Kurang",
                    HeaderText = "Kurang",
                    Text = "-",
                    UseColumnTextForButtonValue = true,
                    DisplayIndex = 5 // Tambahkan di urutan akhir
                };
                dataGridView1.Columns.Add(kurangButtonColumn);
            }
        }

        private void LoadPupukData()
        {
            try
            {
                ResetCustomColumns();
                // Pastikan DatabaseWrapper diimplementasikan dengan benar
                DataTable pupukData = DatabaseWrapper.GetPupukData();

                dataGridView1.DataSource = pupukData; // Menampilkan data di DataGridView

                if (dataGridView1.Columns["id_pupuk"] != null) dataGridView1.Columns["id_pupuk"].Visible = false;
                if (dataGridView1.Columns["id"] != null) dataGridView1.Columns["id"].Visible = false;
                if (dataGridView1.Columns["merek"] != null)
                    dataGridView1.Columns["merek"].HeaderText = "Merek";
                if (dataGridView1.Columns["harga"] != null)
                    dataGridView1.Columns["harga"].HeaderText = "Harga";

                AddNoColumns();
                AddAddLessColumns();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!dataGridView1.Rows[i].IsNewRow) // Abaikan baris kosong tambahan
                    {
                        dataGridView1.Rows[i].Cells["nomor"].Value = (i + 1).ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashCust frmDashCust = new FormDashCust();
            frmDashCust.ShowDialog();
        }


        private void LoadBenihData()
        {
            try
            {
                // Hapus kolom kustom sebelum memuat data baru
                ResetCustomColumns();
                // Pastikan DatabaseWrapper diimplementasikan dengan benar
                DataTable BenihData = DatabaseWrapper.GetBenihData();

                dataGridView1.DataSource = BenihData; // Menampilkan data di DataGridView

                if (dataGridView1.Columns["id_pupuk"] != null) dataGridView1.Columns["id_pupuk"].Visible = false;
                if (dataGridView1.Columns["id"] != null) dataGridView1.Columns["id"].Visible = false;
                if (dataGridView1.Columns["merek"] != null)
                    dataGridView1.Columns["merek"].HeaderText = "Merek";
                if (dataGridView1.Columns["harga"] != null)
                    dataGridView1.Columns["harga"].HeaderText = "Harga";

                AddNoColumns();
                AddAddLessColumns();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (!dataGridView1.Rows[i].IsNewRow) // Abaikan baris kosong tambahan
                    {
                        dataGridView1.Rows[i].Cells["nomor"].Value = (i + 1).ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadPupukData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadBenihData();

        }
        
    }
}