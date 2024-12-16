using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    internal class M_Kategori
    {
        [Key]
        public int id_kategori { get; set; }

        [Required]
        public string nama_kategori { get; set; }
        public static List<M_Kategori> GetKategori()
        {
            return new List<M_Kategori>
            {
                new M_Kategori { id_kategori = 1, nama_kategori = "Pupuk" },
                new M_Kategori { id_kategori = 2, nama_kategori = "Benih" },
            };
        }
    }
}
