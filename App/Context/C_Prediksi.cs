using COBA2.App.Core;
using COBA2.App.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Context
{
    internal class C_Prediksi : DatabaseWrapper //inheritance
    {
        private static string table = "prediksi";
        public static M_Prediksi GetNilaiById(int idTanaman, int idPupuk)
        {
            string query = @"
                SELECT 
                    p.id,
                    p.tanaman_id,
                    p.pupuk_id,
                    p.nilai
                FROM 
                    prediksi p
                WHERE 
                    p.tanaman_id = @tanaman_id AND p.pupuk_id = @pupuk_id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@tanaman_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = idTanaman },
                new NpgsqlParameter("@pupuk_id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = idPupuk }
            };

            DataTable result = DatabaseWrapper.queryExecutor(query, parameters);

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                return new M_Prediksi
                {
                    id = Convert.ToInt32(row["id"]),
                    tanaman_id = Convert.ToInt32(row["tanaman_id"]),
                    pupuk_id = Convert.ToInt32(row["pupuk_id"]),
                    nilai = Convert.ToInt32(row["nilai"])
                };
            }
            else
            {
                // Return null or a default object
                return null;
            }
        }
    }
}