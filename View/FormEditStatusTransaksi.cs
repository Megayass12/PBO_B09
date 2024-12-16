using COBA2.App.Model;
using COBA2.App.Context;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;

namespace COBA2.View
{
    public partial class FormEditStatusTransaksi : Form
    {
        private int transaksiId;
        public FormEditStatusTransaksi()
        {
            InitializeComponent();
        }

        private void FormEditStatusTransaksi_Load(object sender, EventArgs e)
        {
            DataTable StatusTransaksi = new DataTable();
            StatusTransaksi.Columns.Add("id_status", typeof(int));
            StatusTransaksi.Columns.Add("nama_status", typeof(string));
            StatusTransaksi.Rows.Add(1, "Dikirim");
            //StatusTransaksi.Rows.Add(2, "dikirim");
            //StatusTransaksi.Rows.Add(3, "selesai");

            comboBoxStatusTransaksi.DataSource = StatusTransaksi;
            comboBoxStatusTransaksi.DisplayMember = "nama_status";
            comboBoxStatusTransaksi.ValueMember = "nama_status";
            comboBoxStatusTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;

            if (comboBoxStatusTransaksi.Items.Count > 0)
            {
                comboBoxStatusTransaksi.SelectedIndex = 0;
            }
        }
        private void LoadTransaksiData()
        {
            DataTable transaksiData = C_Transaksi.All();
            comboBoxStatusTransaksi.DisplayMember = "nama_status";
            comboBoxStatusTransaksi.ValueMember = "id_status";
            comboBoxStatusTransaksi.DataSource = transaksiData;
            comboBoxStatusTransaksi.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonUpdateStatus_Click(object sender, EventArgs e)
        {
            
            try
            {
                int transaksiId = int.Parse(textBoxIdTransaksi.Text);
                string newStatus = comboBoxStatusTransaksi.SelectedValue.ToString();

                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Silakan pilih status transaksi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                TransaksiModel.UpdateStatusTransaksi(transaksiId, newStatus);

                MessageBox.Show("Status transaksi berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var parentForm = Application.OpenForms["FormPesananAdmin"] as FormPesananAdmin;
                if (parentForm != null)
                {
                    parentForm.LoadTransaksiData();
                }

                this.Close();

                LoadTransaksiData();

                // Membuka FormPesananAdmin dengan transaksiId yang relevan
                FormPesananAdmin formPesananAdmin = new FormPesananAdmin(transaksiId);
                formPesananAdmin.Show();

                // Menutup form saat ini (misalnya, form yang sedang menampilkan status transaksi)
                this.Close();

                //FormPesananAdmin formPesananAdmin = new FormPesananAdmin(transaksiId);
                //this.Close();
                //LoadTransaksiData();
                //formPesananAdmin.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memperbarui status transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            //try
            //{
            //    int transaksiId = int.Parse(textBoxIdTransaksi.Text);
            //    string newStatus = comboBoxStatusTransaksi.SelectedValue.ToString();

            //    if (string.IsNullOrEmpty(newStatus))
            //    {
            //        MessageBox.Show("Silakan pilih status transaksi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //    TransaksiModel.UpdateStatusTransaksi(transaksiId, newStatus);

            //    MessageBox.Show("Status transaksi berhasil diupdate.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    C_Transaksi.GetTransaksiData();
            //    this.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Gagal memperbarui status transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }
        public void PopulateForm(M_Transaksi transaksi)
        {
            LoadTransaksiData();

            textBoxIdTransaksi.Text = transaksi.id_transaksi.ToString();
            textBoxTanggal.Text = transaksi.tanggal.ToString();
            textBoxKuantitas.Text = transaksi.kuantitas.ToString();
            textBoxNamaProduk.Text = transaksi.Katalog.nama_produk;
            textBoxHarga.Text = transaksi.Katalog.harga.ToString();
            textBoxTotalHarga.Text = (transaksi.Katalog.harga * transaksi.kuantitas).ToString();
            //textBoxKategori.Text = transaksi.Katalog.kategori_produk;
            textBoxStatusProduk.Text = transaksi.StatusTransaksi.nama_status;

            comboBoxStatusTransaksi.SelectedValue = transaksi.StatusTransaksi.nama_status;

            textBoxTanggal.Enabled = false;
            textBoxKuantitas.Enabled = false;
            textBoxNamaProduk.Enabled = false;
            textBoxHarga.Enabled = false;
            textBoxTotalHarga.Enabled = false;
            //textBoxKategori.Enabled = false;
            textBoxStatusProduk.Enabled = false;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void comboBoxStatusTransaksi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTanggal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxIdTransaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxStatusProduk_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
