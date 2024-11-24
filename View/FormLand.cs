using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COBA2.App.Core;
using static COBA2.App.Core.UiWrapper;

namespace COBA2.View
{
    public partial class FormLand : Form
    {
        public FormLand()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 _1Form = new Form1();
            _1Form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRegist formRegist = new FormRegist();
            formRegist.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
