using COBA2.View;
using System;
using System.Windows.Forms;

namespace LandingPage
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLand()); // Pastikan nama form benar
        }
    }
}
