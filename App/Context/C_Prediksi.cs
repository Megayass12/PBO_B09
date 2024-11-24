using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Context
{
    public static class KomoditasContext
    {
        public static List<string> GetKomoditas()
        {
            return new List<string> { "Padi", "Jagung", "Jeruk", "Tomat" };
        }
    }
}
