using COBA2.App.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    internal class LaporanBulananModel
    {
        public DataTable GetByMonth(int bulan, int tahun)
        {
            string query = @"
            SELECT 
                ROW_NUMBER() OVER (ORDER BY t.Tanggal_Transaksi) AS Nomor,
                t.Tanggal_Transaksi AS ""Tanggal"",
                p.Nama_Produk AS ""Nama Produk"",
                t.Kuantitas AS ""Jumlah"",
                (t.Kuantitas * p.Harga) AS ""Total"",
                st.Nama_Status AS ""Status""
            FROM transaksi t
            JOIN produk p ON t.id_produk = p.id_produk
            JOIN status_transaksi st ON t.id_status = st.id_status
            WHERE EXTRACT(MONTH FROM t.Tanggal_Transaksi) = @Bulan
              AND EXTRACT(YEAR FROM t.Tanggal_Transaksi) = @Tahun";

            try
            {
                // Buat parameter untuk query
                var parameters = new Npgsql.NpgsqlParameter[]
                {
                    new Npgsql.NpgsqlParameter("@Bulan", bulan),
                    new Npgsql.NpgsqlParameter("@Tahun", tahun)
                };

                // Panggil queryExecutor dengan query dan parameter
                return DatabaseWrapper.queryExecutor(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching monthly report data: " + ex.Message);
            }
        }
    }
}