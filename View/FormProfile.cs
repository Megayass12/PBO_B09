using COBA2.App.Context;
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
    public partial class FormProfile : Form
    {
        private int userId;
        public FormProfile(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            this.Load += new EventHandler(FormProfile_Load);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        //{

        //}

        private void FormProfile_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dataUsers = C_Profile.GetUsersById(userId);

                // Debugging: Check if dataUsers is null
                if (dataUsers == null)
                {
                    MessageBox.Show("Data pengguna tidak ditemukan: dataUsers is null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Debugging: Check if dataUsers has rows
                if (dataUsers.Rows.Count == 0)
                {
                    MessageBox.Show("Data pengguna tidak ditemukan: No rows in dataUsers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = dataUsers.Rows[0];
                txtBoxNama.Text = row["nama"].ToString();
                txtBoxEmail.Text = row["email"].ToString();
                txtBoxUser.Text = row["username"].ToString();
                txtBoxPw.Text = row["password"].ToString();
                txtBoxHp.Text = row["nohp"].ToString();
                textBox1.Text = row["alamat"].ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormEditProfil editProfil = new FormEditProfil(userId);
            var result = editProfil.ShowDialog();
            if (result == DialogResult.OK)
            {
                FormProfile_Load(sender, e);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                FormProfile_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat refresh : {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (userId == 9)
            {
                this.Hide();
                FormBerandaAdmin formBerandaAdmin = new FormBerandaAdmin(userId);
                formBerandaAdmin.ShowDialog();
            }
            else
            {
                this.Hide();
                FormDashCust frmDashCust = new FormDashCust(userId);
                frmDashCust.ShowDialog();
            }
        }

        private void lblNoHP_Click(object sender, EventArgs e)
        {

        }
    }
}
