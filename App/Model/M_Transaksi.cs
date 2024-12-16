using COBA2.App.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    public class M_Transaksi
    {
        [Key]
        public int id_transaksi { get; set; }
        [Required]
        public string tanggal { get; set; }
        [Required]
        public decimal kuantitas { get; set; }
        [ForeignKey("M_Katalog")]
        public int id_produk { get; set; }
        [ForeignKey("M_StatusTransaksi")]
        public int status_id { get; set; }

        public M_StatusTransaksi StatusTransaksi { get; set; }

        public M_Katalog2 Katalog { get; set; }
        
    }
}