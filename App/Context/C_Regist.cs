using COBA2.App.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Context
{
    internal class C_Regist : DatabaseWrapper // inheritance
    {
        private static string table = "Users";
        public static int RegisterUser(string nama, string username, string email, string password, string no_hp, string alamat)
        {
            string query = $"INSERT INTO {table} (Nama, Username, Email, Password, NoHp, Alamat) VALUES (@Nama, @Username, @Email, @Password, @NoHp, @Alamat)";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Nama", nama),
                new NpgsqlParameter("@Username", username),
                new NpgsqlParameter("@Email", email),
                new NpgsqlParameter("@Password", password),
                new NpgsqlParameter("@NoHp", no_hp),
                new NpgsqlParameter("@Alamat", alamat)
            };

            // Cast the long to int explicitly
            return (int)commandExecutor(query, parameters);
        }
    }
}
