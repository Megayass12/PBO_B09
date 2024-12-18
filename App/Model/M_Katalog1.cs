using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    public class M_Katalog1
    {
        public int Id { get; set; }
        public string nama_produk { get; set; }
        public decimal harga { get; set; }
        public string deskripsi_produk { get; set; } // Kuantitas yang dipilih
        public int stok { get; set; }
    }
}
