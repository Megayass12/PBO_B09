using COBA2.App.Core;
using COBA2.App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Context
{
    internal class C_LaporanBulanan : DatabaseWrapper
    {
        private readonly LaporanBulananModel _model; //enkapsulasi

        public C_LaporanBulanan() // konstruktor 
        {
            _model = new LaporanBulananModel(); // penerapan enkapsulasi
        }

        public DataTable GetByMonth(int bulan, int tahun)
        {
            try
            {
                return _model.GetByMonth(bulan, tahun);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
