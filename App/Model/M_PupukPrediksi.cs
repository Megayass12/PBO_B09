using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    internal class M_PupukPrediksi
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string pupuk { get; set; }
    }
}
