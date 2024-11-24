using Npgsql;
using System;
using System.Data;

namespace COBA2.App.Core
{
    internal class DatabaseWrapper
    {
        // Properti credential database dan koneksinya
        private static readonly string DB_HOST = "localhost";
        private static readonly string DB_DATABASE = "coba";
        private static readonly string DB_USERNAME = "postgres";
        private static readonly string DB_PASSWORD = "mega1234";
        private static readonly string DB_PORT = "5432";

        private static NpgsqlConnection connection;

        // Method open dan close Koneksi
        public static void openConnection()
        {
            connection = new NpgsqlConnection($"Host={DB_HOST};Username={DB_USERNAME};Password={DB_PASSWORD};Database={DB_DATABASE};Port={DB_PORT}");
            connection.Open();
        }

        public static void closeConnection()
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
        public static int InsertUser(string nama, string username, string email, string password, string no_hp)
        {
            try
            {
                openConnection();
                string query = "INSERT INTO Users (Nama, Username, Email, Password, NoHp) VALUES (@Nama, @Username, @Email, @Password, @NoHp)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nama", nama);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@NoHp", no_hp);

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
        public static DataTable GetPupukData()
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                string query = "SELECT * FROM pupuk";

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
        public static DataTable GetBenihData()
        {
            DataTable dt = new DataTable();
            try
            {
                openConnection();
                string query = "SELECT * FROM benih";

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
    }
}
