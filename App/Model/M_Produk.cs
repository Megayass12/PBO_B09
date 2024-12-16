using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    public class M_Produk
    {
        public int id { get; set; }
        public string nama_produk { get; set; }
        public decimal harga { get; set; }
        public string deskripsi_produk { get; set; } // Kuantitas yang dipilih
        public int stok { get; set; }
        public int Quantity { get; set; }
        public int id_kategori { get; set; } = 0;

        public M_Produk(int Id, string Nama_produk, decimal Harga, string Deskripsi_produk, int Stok, int Id_kategori) 
        {
            id = Id;
            nama_produk = Nama_produk;
            harga = Harga;
            deskripsi_produk = Deskripsi_produk;
            stok = Stok;
            id_kategori = Id_kategori;
            Quantity = 0;
        
        }
    }
}
