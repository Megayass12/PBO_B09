using COBA2.App.Context;
using COBA2.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COBA2
{
    public partial class FormRegist : Form
    {
        private string nama;
        private string username;
        private string email;
        private string password;
        private string no_hp;
        private string alamat;
        public FormRegist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string nama = textBox1.Text.Trim();
                string username = textBox2.Text.Trim();
                string email = textBox3.Text.Trim();
                string password = textBox4.Text.Trim();
                string no_hp = textBox5.Text.Trim();
                string alamat = textBox6.Text.Trim();

                if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(no_hp) || string.IsNullOrWhiteSpace(alamat))
                {
                    MessageBox.Show("Lengkapi data terlebih dahulu.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
                {
                    MessageBox.Show("Email harus menggunakan format @gmail.com.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 4 || password.Length > 8)
                {
                    MessageBox.Show("Password harus memiliki panjang antara 4 hingga 8 karakter.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(no_hp, "^\\d+$"))
                {
                    MessageBox.Show("Nomor HP harus berupa angka.", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(no_hp) || string.IsNullOrEmpty(alamat)) { MessageBox.Show("Lengkapi data terlebih dahulu"); }
                else
                    try
                    {
                        int result = C_Regist.RegisterUser(nama, username, email, password, no_hp, alamat);
                        if (result == 0)
                        {
                            MessageBox.Show("Registrasi berhasil");
                            // Contoh: Membuka form lain atau melakukan tindakan setelah registrasi berhasil
                            Form1 _1Form = new Form1();
                            _1Form.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Gagal memasukkan data ke database");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                    }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLand formLand = new FormLand();
            formLand.Show();
        }
    }
}
