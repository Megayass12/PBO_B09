using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
   public class M_StatusTransaksi
    {
        [Key]
        public int id_status { get; set; }
        [Required]
        public string nama_status { get; set; }
    }
}
