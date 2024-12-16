using COBA2.App.Core;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
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
    public partial class FormTransaksi : Form
    {
        private int userId; //simpan user id buat transaksi

        public FormTransaksi(int userId)
        {
            InitializeComponent();
            this.userId = userId; // user id dari form sebelume

        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Gunakan DatabaseWrapper untuk mengambil data transaksi
                DatabaseWrapper dbWrapper = new DatabaseWrapper();
                DataTable transaksiData = dbWrapper.GetTransaksiByUserId(userId);

                // Bind data ke DataGridView
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = transaksiData;

                // Periksa apakah kolom "Pesanan" sudah ada, jika tidak tambahkan sebagai ComboBox
                if (!dataGridView1.Columns.Contains("Pesanan"))
                {
                    DataGridViewButtonColumn pesananColumn = new DataGridViewButtonColumn
                    {
                        Name = "Pesanan",
                        HeaderText = "Status Transaksi",
                        Text = "Update",
                        DataPropertyName = "Status Pesanan",
                        UseColumnTextForButtonValue = true,
                    };

                    dataGridView1.Columns.Add(pesananColumn);
                }

                // Loop through each row and set the Pesanan column value based on "Status Pesanan"
                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    if (!row.IsNewRow && row.Cells["Status Pesanan"].Value != null)
                //    {
                //        string statusValue = row.Cells["Status Pesanan"].Value.ToString();

                //        // Set nilai untuk combo box
                //        if (statusValue == "1")
                //        {
                //            row.Cells["Pesanan"].Value = 1;
                //        }
                //        else if (statusValue == "2")
                //        {
                //            row.Cells["Pesanan"].Value = 2;
                //        }
                //        else if (statusValue == "3")
                //        {
                //            row.Cells["Pesanan"].Value = 3;
                //        }
                //        else
                //        {
                //            row.Cells["Pesanan"].Value = 0;
                //        }
                //    }
                //}

                if (dataGridView1.Columns.Contains("Status Pesanan"))
                {
                    dataGridView1.Columns["Status Pesanan"].Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashCust frmDashCust = new FormDashCust(userId);
            frmDashCust.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Pesanan")
            {
                // Ambil data transaksi dari baris yang diklik
                try
                {
                    // Ambil ID Transaksi dari baris yang diklik
                    int transaksiId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID Transaksi"].Value);


                    // Update status transaksi menjadi "Selesai" (status 3)
                    DatabaseWrapper dbWrapper = new DatabaseWrapper();



                    bool updateSuccess = DatabaseWrapper.UpdateTransaksiStatus(transaksiId, 2);

                    if (updateSuccess)
                    {
                        MessageBox.Show("Status transaksi berhasil diperbarui");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Gagal memperbarui status transaksi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //if (e.ColumnIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Pesanan")
            //{
            //    // Ambil data transaksi dari baris yang diklik
            //    try
            //    {
            //        // Ambil ID Transaksi dari baris yang diklik
            //        int transaksiId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID Transaksi"].Value);

            //        // Ambil status transaksi saat ini dari database
            //        DatabaseWrapper dbWrapper = new DatabaseWrapper();
            //        int currentStatus = dbWrapper.GetCurrentStatus(transaksiId);

            //        // Tentukan status baru berdasarkan status saat ini
            //        int newStatus;

            //        switch (currentStatus)
            //        {
            //            case 1:
            //                newStatus = 2; // Belum Diterima → Sudah Diterima
            //                break;
            //            case 2:
            //                newStatus = 3; // Sudah Diterima → Dikirim
            //                break;
            //            case 3:
            //                newStatus = 1; // Dikirim → Belum Diterima
            //                break;
            //            default:
            //                throw new Exception("Status transaksi tidak valid.");
            //        }
            //    }
            //    catch 
            //    { 

            //    }


            //}
        }
    }
}
       


                 


