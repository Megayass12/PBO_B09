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
    internal class C_Login : DatabaseWrapper
    {
        private static string table = "Users";

        public static long login(string username, string password)
        {
            try
            {
                string query = $"SELECT COUNT(*) FROM {table} WHERE username = @username AND password = @password";
                NpgsqlParameter[] parameters =
                {
            new NpgsqlParameter("username", NpgsqlDbType.Varchar) { Value = username },
            new NpgsqlParameter("password", NpgsqlDbType.Varchar) { Value = password }
        };

                long result = commandExecutor(query, parameters);
                return result > 0 ? 1 : 0; // Return 1 if a match is found, otherwise return 0
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return 0;
            }
        }



    }
}
