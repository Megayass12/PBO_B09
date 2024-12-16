using COBA2.App.Model;
using Npgsql;
using System;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Drawing.Text;

namespace COBA2.App.Core
{
    internal class DatabaseWrapper // parents dari semua controller
    {
        // Properti credential database dan koneksinya
        private static readonly string DB_HOST = "localhost";
        private static readonly string DB_DATABASE = "coba";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "mega1234";
        private static readonly string DB_PORT = "5432";

        private static NpgsqlConnection connection;

        // Method open dan close Koneksi
        public static void openConnection() // konstruktor
        {
            connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}");
            connection.Open();
        }

        public static void closeConnection() // konstruktor
        {
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public static DataTable queryExecutor(string query, NpgsqlParameter[] parameters = null)
        {
            try
            {
                openConnection();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                        command.Prepare();
                    }

                    DataTable dataTable = new DataTable();
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public static long commandExecutor(string query, NpgsqlParameter[] parameters = null)
        {
            try
            {
                openConnection();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    command.Prepare();

                    // Periksa apakah hasilnya null sebelum melakukan casting
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt64(result) : 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        // Method untuk menambahkan user baru
        public static int InsertUser(string nama, string username, string email, string password, string no_hp, string alamat)
        {
            try
            {
                openConnection();
                string query = "INSERT INTO Users (Nama, Username, Email, Password, NoHp, Alamat) VALUES (@Nama, @Username, @Email, @Password, @NoHp, @Alamat)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nama", nama);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@NoHp", no_hp);
                    command.Parameters.AddWithValue("@Alamat", alamat);

                    int result = command.ExecuteNonQuery();
                    return result;
                }
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                throw new Exception("Username sudah terdaftar, coba username yang lain.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                closeConnection();
            }
        }

        public static DataTable GetProductData(int categoryId) 
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                string query = "SELECT * FROM produk WHERE id_kategori = @categoryId";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoryId", categoryId);
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }

                closeConnection();
            }
            catch (Exception ex)
            {
                closeConnection();
                throw new Exception("Error while fetching data: " + ex.Message);
            }
            return dt;
        }

        // KATALOG PUPUK
        public static DataTable GetPupukData()
        {
            return GetProductData(1); //polymorphism overload
        }

        // KATALOG BENIH
        public static DataTable GetBenihData()
        {
            return GetProductData(2); //polymorphism overload
        }

        public static DataTable GetKatalog()
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                string query = "SELECT * id, nama_produk, harga, deskripsi_produk, stok, id_kategori FROM product;";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }

                closeConnection();
            }

            catch (Exception ex)
            {
                closeConnection();
                throw new Exception("Error while fetching data: " + ex.Message);
            }
            return dt;
        }




        public static DataTable GetKatalogData()
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                string query = @"
            SELECT 
                p.Id_Produk,
                p.Nama_Produk,
                p.Harga,
                p.Deskripsi_Produk,
                p.Stok,
                kp.Nama_Kategori,
                sp.Nama_StatusProduk
            FROM 
                Produk p
            JOIN 
                Kategori_Produk kp ON p.Id_Kategori = kp.Id_Kategori
            JOIN 
                Status_Produk sp ON p.Id_StatusProduk = sp.Id_StatusProduk";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching katalog data: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }

        public static DataTable getProdukById(int produkId)
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                // Query dengan JOIN ke tabel kategori
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
    p.id_produk = @Id_Produk";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    // Menambahkan parameter Id_Produk
                    command.Parameters.AddWithValue("@Id_Produk", NpgsqlTypes.NpgsqlDbType.Integer, produkId);

                    // Eksekusi query dan isi ke DataTable
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching product data: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }


        // SIMPAN TRANSAKSI KE DB
        public static bool SimpanTransaksi(int userId, List<M_Produk> daftarProduk, decimal totalHarga)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=mega1234;Database=coba"))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine($"Debug: userId yang diterima = {userId}");

                    // Validasi apakah userId ada di tabel Users
                    string queryCekUser = "SELECT COUNT(*) FROM Users WHERE id = @userId";
                    NpgsqlCommand cmdCekUser = new NpgsqlCommand(queryCekUser, conn);
                    cmdCekUser.Parameters.AddWithValue("@userId", userId);

                    int userExists = Convert.ToInt32(cmdCekUser.ExecuteScalar());
                    if (userExists == 0)
                    {
                        throw new Exception("User ID tidak ditemukan. Pastikan User ID valid.");
                    }

                    // Simpan transaksi utama (header transaksi)
                    openConnection();
                    string queryTransaksi = "INSERT INTO transaksiku (user_id, total_harga, tanggal, status_id) VALUES (@userId, @totalHarga, @tanggal, @id_status) RETURNING id_transaksi";
                    NpgsqlCommand cmdTransaksi = new NpgsqlCommand(queryTransaksi, conn);
                    cmdTransaksi.Parameters.AddWithValue("@userId", userId);
                    cmdTransaksi.Parameters.AddWithValue("@totalHarga", totalHarga);
                    cmdTransaksi.Parameters.AddWithValue("@tanggal", DateTime.Now);
                    cmdTransaksi.Parameters.AddWithValue("@id_status", 4);


                    // Mengambil nilai id_transaksi yang dihasilkan oleh query RETURNING
                    int idTransaksi = (int)cmdTransaksi.ExecuteScalar();

                    // Simpan detail transaksi
                    foreach (var produk in daftarProduk)
                    {
                        string queryDetail = "INSERT INTO detail_transaksiku (transaksi_id, produk_id, kuantitas, harga_satuan) VALUES (@idTransaksi, @idProduk, @kuantitas, @hargaSatuan)";
                        NpgsqlCommand cmdDetail = new NpgsqlCommand(queryDetail, conn);
                        cmdDetail.Parameters.AddWithValue("@idTransaksi", idTransaksi);
                        cmdDetail.Parameters.AddWithValue("@idProduk", produk.id);
                        cmdDetail.Parameters.AddWithValue("@kuantitas", produk.Quantity);
                        cmdDetail.Parameters.AddWithValue("@hargaSatuan", produk.harga);
                        //cmdDetail.Parameters.AddWithValue("@id_status", 1);
                        cmdDetail.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyimpan transaksi: " + ex.Message);
                    return false;
                }
            }
        }


        // LIAT TRANSAKSI
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=mega1234;Database=coba";

        public DataTable GetTransaksiByUserId(int userId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    t.id_transaksi AS ""ID Transaksi"",
                    t.tanggal AS ""Tanggal"",
                    t.total_harga AS ""Total Harga"",
                    p.nama_produk AS ""Produk"",
                    dt.kuantitas AS ""Kuantitas"",
                    dt.harga_satuan AS ""Harga Satuan"",
                    st.nama_status AS ""Status Pesanan""
                FROM 
                    transaksiku t
               INNER JOIN detail_transaksiku dt ON t.id_transaksi = dt.transaksi_id
                INNER JOIN 
                    produk p ON dt.produk_id = p.id_produk
                INNER JOIN
                     status_transaksi st ON st.id_status = t.status_id
                WHERE 
                    t.user_id = @userId
                ORDER BY 
                    t.tanggal DESC";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                DataTable dt = new DataTable();
                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return dt;
            }
        }
        public static bool UpdateStatusPesanan(int transaksiId, int newStatus)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {
                    connection.Open();

                    string query = "UPDATE transaksi SET status_pesanan = @newStatus WHERE id_transaksi = @transaksiId";
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newStatus", newStatus);
                        command.Parameters.AddWithValue("@transaksiId", transaksiId);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true jika update berhasil
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
        }

        public int GetCurrentStatus(int transaksiId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_status FROM transaksi WHERE id_transaksi = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", transaksiId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        throw new Exception("Transaksi tidak ditemukan.");
                    }
                }
            }
        }

        public static DataTable GetTransaksiData()
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                string query = @"
            SELECT 
                t.id_transaksi,
                t.tanggal,
                dt.kuantitas,
                p.nama_produk,
                p.harga,
                (dt.Kuantitas * p.Harga) AS Total_Harga,
                kp.nama_kategori,
                sp.nama_statusproduk,
                st.nama_status
            FROM 
                transaksiku t
            JOIN 
                detail_transaksiku dt ON t.id_transaksi = dt.transaksi_id 
            JOIN
                produk p ON dt.produk_id = p.id_produk
            JOIN 
                kategori_produk kp ON p.id_Kategori = kp.id_Kategori
            JOIN 
                status_produk sp ON p.id_statusproduk = sp.id_statusproduk
            JOIN 
                status_transaksi st ON t.status_id = st.id_status";

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching transaction data: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
            return dt;
        }

        public static bool UpdateTransaksiStatus(int transaksiId, int newStatus)
        {
            try
            {
                openConnection();

                // Validasi dan update status transaksi
                string updateQuery = @"
            UPDATE transaksiku
            SET status_id = @newStatus
            WHERE id_transaksi = @transaksiId AND status_id = 3
            RETURNING id_transaksi";

                using (NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@newStatus", newStatus);
                    updateCommand.Parameters.AddWithValue("@transaksiId", transaksiId);

                    // Gunakan RETURNING untuk memastikan baris diperbarui
                    using (var reader = updateCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            throw new Exception("Status tidak dapat diubah. Pastikan status saat ini adalah 'Dikirim' (3).");
                        }
                    }
                }

                return true; // Status berhasil diubah
            }
            catch (Exception ex)
            {
                throw new Exception("Gagal memperbarui status transaksi: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }


        public DataTable GetTransaksiDone(int userId)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Query SQL dengan klausa WHERE yang benar
                string query = @"
                   SELECT 
                        t.id_transaksi AS ""ID Transaksi"",
                        t.tanggal AS ""Tanggal"",
                        t.total_harga AS ""Total Harga"",
                        t.status_id AS ""Status Transaksi"",
                        p.nama_produk AS ""Produk"",
                        dt.kuantitas AS ""Kuantitas"",
                        dt.harga_satuan AS ""Harga Satuan"",
                                                st.nama_status AS ""Status Pesanan""
                        FROM 
                            transaksiku t
                        INNER JOIN 
                            detail_transaksiku dt ON t.id_transaksi = dt.transaksi_id
                        INNER JOIN 
                            produk p ON dt.produk_id = p.id_produk
                        INNER JOIN 
                            status_transaksi st ON st.id_status = t.status_id
                        WHERE 
                            t.user_id = @userId AND t.status_id = 2";  // Pastikan 'status_pesanan' diganti ke 'status_id' jika cocok dengan database

                // Membuat command dan menambahkan parameter
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    // Membuat DataTable untuk menyimpan hasil query
                    DataTable dt = new DataTable();
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt); // Mengisi DataTable dengan data dari query
                    }

                    return dt; // Mengembalikan DataTable
                }

            }
        }
    }
}

