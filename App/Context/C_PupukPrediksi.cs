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
    internal class C_PupukPrediksi
    {
        private static string table = "pupuk_prediksi";
        public static List<M_PupukPrediksi> GetAll()
        {
            string query = @"
                SELECT 
                    p.id,
                    p.pupuk
                FROM 
                    pupuk_prediksi p";

            DataTable result = DatabaseWrapper.queryExecutor(query);
            List<M_PupukPrediksi> pupukList = new List<M_PupukPrediksi>();

            foreach (DataRow row in result.Rows)
            {
                pupukList.Add(new M_PupukPrediksi
                {
                    id = Convert.ToInt32(row["id"]),
                    pupuk = row["pupuk"].ToString(),
                });
            }

            return pupukList;
        }
    }
}
