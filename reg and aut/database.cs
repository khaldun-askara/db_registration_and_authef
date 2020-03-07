﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace reg_and_aut
{
    class database
    {
        private static readonly string sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = Database.Default.Name,
            Username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME"),
            Password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD"),
            AutoPrepareMinUsages = 2,
            MaxAutoPrepare = 10
        }.ConnectionString;

        public static bool IsLoginExists (string login)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"SELECT COUNT(*) FROM users WHERE lower(@currentLogin) = lower(login);"
                };
                sCommand.Parameters.AddWithValue("@currentLogin", login);
                return (long)sCommand.ExecuteScalar() > 0;
            }
        }

        public static void AddUser (string login, string password)
        {
            byte[] salt = login_and_password.GetSalt();
            string salt_str = Convert.ToBase64String(salt);
            string hash_str = Convert.ToBase64String(login_and_password.GetHash(password, salt));
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCommand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = $@"INSERT INTO users (login, password_hash, salt) VALUES (@login, @password_hash, @salt)"
                };
                sCommand.Parameters.AddWithValue("@login", login);
                sCommand.Parameters.AddWithValue("@password_hash", hash_str);
                sCommand.Parameters.AddWithValue("@salt", salt_str);
                sCommand.ExecuteNonQuery();
            }
        }
    }
}
