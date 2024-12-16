using COBA2.App.Context;
using COBA2.App.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COBA2.View
{
    public partial class FormEditProfil : Form
    {
        public int userId;
        public FormEditProfil(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            this.Load += new EventHandler(FormEditProfil_Load);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormEditProfil_Load(object sender, EventArgs e)
        {
            DataTable customerData = C_Profile.GetUsersById(userId);
            if (customerData.Rows.Count > 0)
            {
                DataRow row = customerData.Rows[0];
                txtBoxNama.Text = row["nama"].ToString();
                txtBoxEmail.Text = row["email"].ToString();
                txtBoxUser.Text = row["username"].ToString();
                txtBoxPw.Text = row["password"].ToString();
                txtBoxHp.Text = row["nohp"].ToString();
                textBox1.Text = row["alamat"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxNama.Text) || string.IsNullOrEmpty(txtBoxEmail.Text) ||
                string.IsNullOrEmpty(txtBoxUser.Text) || string.IsNullOrEmpty(txtBoxPw.Text) ||
                string.IsNullOrEmpty(txtBoxHp.Text) || string.IsNullOrEmpty(txtboxAlamat.Text))
            {
                MessageBox.Show("Harap isi semua data", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            M_Profile profile = new M_Profile
            {
                id = userId,
                nama = txtBoxNama.Text,
                email = txtBoxEmail.Text,
                username = txtBoxUser.Text,
                password = txtBoxPw.Text,
                nohp = txtBoxHp.Text,
                alamat = txtboxAlamat.Text,

            };

            try
            {
                C_Profile.UpdateUsers(profile);
                MessageBox.Show("Profil berhasil diperbarui");
                this.Hide();
                FormProfile formProfile = new FormProfile(userId);
                formProfile.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Apakah Anda Yakin Ingin Kembali?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if ( result == DialogResult.Yes)
            {
                this.Hide();
                FormProfile formProfile = new FormProfile(userId);
                formProfile.Show();
            }
        }
    }
}
