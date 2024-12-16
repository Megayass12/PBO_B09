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
    internal class C_TanamanPrediksi : DatabaseWrapper //inheritance
    {
        private static string table = "tanaman_prediksi";
        public static List<M_TanamanPrediksi> GetAll()
        {
            string query = @"
                SELECT 
                    t.id,
                    t.tanaman
                FROM 
                    tanaman_prediksi t";

            DataTable result = DatabaseWrapper.queryExecutor(query);
            List<M_TanamanPrediksi> tanamanList = new List<M_TanamanPrediksi>();

            foreach (DataRow row in result.Rows)
            {
                tanamanList.Add(new M_TanamanPrediksi
                {
                    id = Convert.ToInt32(row["id"]),
                    tanaman = row["tanaman"].ToString(),
                });
            }

            return tanamanList;
        }
    }
}
