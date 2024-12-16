using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    public class M_Katalog2 // enkapsulasi
    {
        [Key]
        public int id_produk { get; set; }

        [Required]
        public string nama_produk { get; set; }

        [Required]
        public decimal harga { get; set; }

        [Required]
        public string deskripsi_produk { get; set; }

        [Required]
        public int stok { get; set; }

        [ForeignKey("M_Kategori")]
        public string kategori_produk { get; set; }
    }
}
