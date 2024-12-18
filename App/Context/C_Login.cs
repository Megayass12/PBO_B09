using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COBA2.App.Core;
using COBA2.App.Model;

namespace COBA2.App.Context
{
    internal class C_Login : DatabaseWrapper //inheritance
    {
        private int userId;
        private static string table = "Users";


        public static int login(string username, string password)
        {
            string query = "SELECT id FROM users WHERE username = @username AND password = @password";
            NpgsqlParameter[] parameters = {
        new NpgsqlParameter("@username", username),
        new NpgsqlParameter("@password", password)
    };

            DataTable result = DatabaseWrapper.queryExecutor(query, parameters);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["id"]); // Ambil userId
            }

            return 0; // Jika login gagal
        }
    }
}
