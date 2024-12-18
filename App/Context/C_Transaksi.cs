using COBA2.App.Core;
using COBA2.App.Model;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace COBA2.App.Context
{
    internal class C_Transaksi : DatabaseWrapper 
    {
        private readonly TransaksiModel _model; 

        public C_Transaksi() 
        {
            _model = new TransaksiModel(); 
        }

        public static DataTable All()
        {
            try
            {
                return TransaksiModel.All();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }


        public DataTable GetTransaksiPerBulanTahun(int bulan, int tahun) // method
        {
            string query = @"
            SELECT 
                t.id_transaksi,
                t.tanggal,
                p.nama_produk ,
                dt.kuantitas,
                (dt.kuantitas * p.harga) AS total_harga,
                st.nama_status AS status
            FROM transaksiku t
            JOIN detail_transaksiku dt ON t.id_transaksi = dt.transaksi_id
            JOIN produk p ON dt.produk_id = p.id_produk
            JOIN status_transaksi st ON t.status_id = st.id_status
            WHERE EXTRACT(MONTH FROM t.tanggal) = @bulan
            AND EXTRACT(YEAR FROM t.tanggal) = @tahun
            ORDER BY t.tanggal DESC;
            ";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@bulan", bulan),
                new NpgsqlParameter("@tahun", tahun)
            };
            return DatabaseWrapper.queryExecutor(query, parameters);
        }
        public static void UpdateTransaksi(M_Transaksi transaksi)
        {
            string query = "" +
                "UPDATE transaksiku " +
                "SET " +
                "id_status = @newStatus " +
                "WHERE id_transaksi = @id_transaksi";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@newStatus", transaksi.status_id),
                new NpgsqlParameter("@id_transaksi", transaksi.id_transaksi)
            };
            commandExecutor(query, parameters);
       
        }

        internal static DataTable getTransaksiById(int transaksiId)
        {
            string query = @"
            SELECT
                t.id_transaksi,
                t.tanggal,
                p.id_produk,
                p.nama_produk,
                p.harga,
                dt.kuantitas,
                (dt.kuantitas * p.harga) AS total_harga,
                st.nama_status,
                st.id_status
            FROM transaksiku t
            JOIN detail_transaksiku dt ON t.id_transaksi = dt.transaksi_id
            JOIN produk p ON dt.produk_id = p.id_produk
            JOIN status_transaksi st ON t.status_id = st.id_status
            WHERE t.id_transaksi = @transaksiId
            ";
                NpgsqlParameter[] parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@transaksiId", transaksiId)
                };
            ;
            return DatabaseWrapper.queryExecutor(query, parameters);
        }
    }
    internal class TransaksiModel
    {
        public static DataTable All()
        {
            string query = @"
                SELECT 
                    ROW_NUMBER() OVER (ORDER BY t.tanggal) AS Nomor,
                    t.tanggal,
                    p.nama_produk,
                    dt.kuantitas,
                    (dt.kuantitas * p.harga) AS total_harga,
                    st.nama_status
                FROM transaksiku t
                JOIN detail_transaksiku dt ON t.id_transaksi = dt.transaksi_id
                JOIN produk p ON dt.produk_id = p.id_produk
                JOIN status_transaksi st ON t.status_id = st.id_status";
            return DatabaseWrapper.queryExecutor(query);
        }

        public static void UpdateStatusTransaksi(int id_transaksi, string newStatus)
        {
            try
            {
                string validateQuery = @"
                    SELECT COUNT(1) 
                    FROM status_transaksi 
                    WHERE nama_status = @newStatus";
                NpgsqlParameter[] validateParams = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@newStatus", newStatus)
                };
                int statusExists = Convert.ToInt32(DatabaseWrapper.commandExecutor(validateQuery, validateParams));

                if (statusExists == 0)
                {
                    throw new Exception($"Status '{newStatus}' tidak ditemukan di tabel status_transaksi.");
                }

                string updateQuery = @"
                    UPDATE transaksiku
                    SET status_id = (
                        SELECT id_status 
                        FROM status_transaksi 
                        WHERE nama_status = @newStatus
                    )
                    WHERE id_transaksi = @id_transaksi";
                NpgsqlParameter[] updateParams = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@newStatus", newStatus),
                    new NpgsqlParameter("@id_transaksi", id_transaksi)
                };

                DatabaseWrapper.commandExecutor(updateQuery, updateParams);
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memperbarui status transaksi: " + ex.Message);
            }
        }
    }
}