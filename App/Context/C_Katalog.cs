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
    public class C_Katalog
    {
        public static List<M_Produk> GetKatalog()
        {
            DataTable dataTable = DatabaseWrapper.GetKatalog();
            List<M_Produk> pupukList = new List<M_Produk>();

            foreach (DataRow row in dataTable.Rows)
            {
                pupukList.Add(new M_Produk(
            int.Parse(row["id"].ToString()),
            row["nama_produk"].ToString(),
            decimal.Parse(row["harga"].ToString()),
            row["deskripsi_produk"].ToString(),
            int.Parse(row["stok"].ToString()),
            int.Parse(row["id_kategori"].ToString())
        ));


            }
            return pupukList;
        }
    }
}
