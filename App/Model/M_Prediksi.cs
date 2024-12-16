using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    internal class M_Prediksi
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int tanaman_id { get; set; }
        [Required]
        public int pupuk_id { get; set; }
        [Required]
        public int nilai { get; set; }
    }
}
