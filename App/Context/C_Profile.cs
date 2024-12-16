using COBA2.App.Core;
using COBA2.App.Model;
using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Data;

namespace COBA2.App.Context
{
    public class C_Profile
    {
        public static string table = "users";

        // Mengambil data pengguna berdasarkan ID
        public static DataTable GetUsersById(int userId)
        {
            string query = @"
                SELECT 
                    u.id,
                    u.nama,
                    u.username,
                    u.email,
                    u.password,
                    u.nohp,
                    u.alamat
                FROM 
                    users u
                WHERE 
                    u.id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@id", NpgsqlTypes.NpgsqlDbType.Integer) { Value = userId }
            };

            // Eksekusi query dan kembalikan hasil
            DataTable dataUsers = DatabaseWrapper.queryExecutor(query, parameters);
            return dataUsers;
        }

        // Mengupdate data pengguna
        public static void UpdateUsers(M_Profile user)
        {
            string query = $@"
                UPDATE {table} 
                SET 
                    nama = @nama, 
                    email = @email, 
                    username = @username, 
                    password = @password, 
                    nohp = @nohp ,
                    alamat = @alamat
                WHERE 
                    id = @id";

            NpgsqlParameter[] parameters =
            {
                new NpgsqlParameter("@nama", user.nama),
                new NpgsqlParameter("@email", user.email),
                new NpgsqlParameter("@username", user.username),
                new NpgsqlParameter("@password", user.password),
                new NpgsqlParameter("@nohp", user.nohp),
                new NpgsqlParameter("@alamat", user.alamat),
                new NpgsqlParameter("@id", user.id)
            };

            DatabaseWrapper.commandExecutor(query, parameters);
        }
    }
}
