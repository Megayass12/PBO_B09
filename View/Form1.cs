using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COBA2.App.Model;
using COBA2.App.Context;
using COBA2.View;


namespace COBA2
{
    public partial class Form1 : Form
    {
        private string username;
        private string password;
        private int userId;
        public Form1()
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Masukkan username dan password terlebih dahulu");
            }
            else
            {
                int userId = C_Login.login(username, password);
                if (userId > 0)
                {
                    MessageBox.Show("Login Berhasil");
                    if (userId == 9 && username == "mega12" && password == "1234")
                    {
                        this.Hide();
                        FormBerandaAdmin frmDashAdm = new FormBerandaAdmin(userId);
                        frmDashAdm.ShowDialog();
                        


                    }
                    else
                    {
                        this.Hide();
                        FormDashCust frmDashCust = new FormDashCust(userId); // Kirim userId
                        frmDashCust.ShowDialog(); 
                    }
                }
                else
                {
                    MessageBox.Show("Username atau password salah!");
                }
            }
        }
                

                private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
