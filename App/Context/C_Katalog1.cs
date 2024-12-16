using COBA2.App.Core;
using COBA2.App.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace COBA2.App.Context
{
    internal class C_Katalog1 : DatabaseWrapper // inheritance dari datawrapper
    {
        private static string table = "produk";

        public static void AddKatalog(M_Katalog2 katalogBaru)
        {
            string query = $@"
                INSERT INTO {table} (nama_produk, harga, deskripsi_produk, stok, id_kategori, id_statusproduk) 
                VALUES (@namaProduk, @harga, @deskripsi, @stok, @kategori, 1)";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@namaProduk", katalogBaru.nama_produk),
                new NpgsqlParameter("@harga", katalogBaru.harga),
                new NpgsqlParameter("@deskripsi", katalogBaru.deskripsi_produk),
                new NpgsqlParameter("@stok", katalogBaru.stok),
                new NpgsqlParameter("@kategori",int.Parse(katalogBaru.kategori_produk))
            };

            commandExecutor(query, parameters);
        }

        public static void UpdateKatalog(M_Katalog2 katalogBaru)
        {
            string query = @"
            UPDATE public.produk
            SET
                nama_produk = @namaProduk,
                harga = @harga,
                deskripsi_produk = @deskripsiProduk,
                stok = @stok,
                id_kategori = @kategoriProduk
            WHERE
                id_produk = @idProduk";

                NpgsqlParameter[] parameters =
                {
                    new NpgsqlParameter("@namaProduk", katalogBaru.nama_produk),
                    new NpgsqlParameter("@harga", katalogBaru.harga),
                    new NpgsqlParameter("@deskripsiProduk", katalogBaru.deskripsi_produk),
                    new NpgsqlParameter("@stok", katalogBaru.stok),
                    new NpgsqlParameter("@kategoriProduk", int.Parse(katalogBaru.kategori_produk)),
                    new NpgsqlParameter("@idProduk", katalogBaru.id_produk)
                };

            DatabaseWrapper.queryExecutor(query, parameters);
        }

           
            public static M_Katalog2 GetKatalogById(int idProduk)
        {
            // Query dengan JOIN
            string query = @"
        SELECT 
            p.nama_produk,
            p.harga,
            p.deskripsi_produk,
            p.stok,
            c.nama_kategori AS kategori_produk
        FROM 
            public.produk p
        JOIN 
            public.kategori_produk c
        ON 
            p.id_kategori = c.id_kategori
        WHERE 
            p.id_produk = @idProduk";

            // Parameter untuk query
            NpgsqlParameter[] parameters =
            {
        new NpgsqlParameter("@idProduk", idProduk)
    };

            DataTable dt = new DataTable();

            try
            {
                // Eksekusi query dan isi data ke dalam DataTable
                dt = queryExecutor(query, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching catalog data: " + ex.Message);
            }

            // Konversi DataTable menjadi objek M_Katalog
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new M_Katalog2
                {
                    id_produk = idProduk,
                    nama_produk = row["nama_produk"].ToString(),
                    harga = Convert.ToDecimal(row["harga"]),
                    deskripsi_produk = row["deskripsi_produk"].ToString(),
                    stok = Convert.ToInt32(row["stok"]),
                    kategori_produk = row["kategori_produk"].ToString()
                };
            }
            else
            {
                return null; // Data tidak ditemukan
            }
                try
                {
                    // Eksekusi query untuk melakukan update
                    commandExecutor(query, parameters);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while updating catalog data: " + ex.Message);
                }
            }
        }
    }