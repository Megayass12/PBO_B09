using COBA2.App.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                string nama = textBox1.Text;
                string username = textBox2.Text;
                string email = textBox3.Text;
                string password = textBox4.Text;
                string no_hp = textBox5.Text;
                string alamat = textBox6.Text;

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
    }
}
