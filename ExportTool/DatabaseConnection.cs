using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using MySqlConnector;

namespace ExportTool
{
    public class DatabaseConnection
    {
        private static readonly byte[] Key = new byte[] { 0x45, 0x78, 0x70, 0x6f, 0x72, 0x74, 0x54, 0x6f, 0x6f, 0x6c, 0x45, 0x6e, 0x63, 0x72, 0x79, 0x70, 0x74, 0x69, 0x6f, 0x6e, 0x4b, 0x65, 0x79, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };
        private static readonly byte[] IV = new byte[] { 0x45, 0x78, 0x70, 0x6f, 0x72, 0x74, 0x54, 0x6f, 0x6f, 0x6c, 0x49, 0x56, 0x31, 0x32, 0x33, 0x34 };

        public string Name { get; set; }
        public string EncryptedServer { get; set; }
        public string EncryptedDatabase { get; set; }
        public string EncryptedUsername { get; set; }
        public string EncryptedPassword { get; set; }
        public string EncryptedPort { get; set; }
        public DatabaseType Type { get; set; }

        [ScriptIgnore]
        public string Server
        {
            get { return Decrypt(EncryptedServer); }
            set { EncryptedServer = Encrypt(value); }
        }

        [ScriptIgnore]
        public string Database
        {
            get { return Decrypt(EncryptedDatabase); }
            set { EncryptedDatabase = Encrypt(value); }
        }

        [ScriptIgnore]
        public string Username
        {
            get { return Decrypt(EncryptedUsername); }
            set { EncryptedUsername = Encrypt(value); }
        }

        [ScriptIgnore]
        public string Password
        {
            get { return Decrypt(EncryptedPassword); }
            set { EncryptedPassword = Encrypt(value); }
        }

        [ScriptIgnore]
        public string Port
        {
            get { return Decrypt(EncryptedPort); }
            set { EncryptedPort = Encrypt(value); }
        }

        public enum DatabaseType
        {
            SqlServer,
            MySql
        }

        public IDbConnection CreateConnection()
        {
            if (Type == DatabaseType.SqlServer)
            {
                string server = Server;
                if (!string.IsNullOrEmpty(Port) && int.TryParse(Port, out int port))
                {
                    server = $"{Server},{port}";
                }
                return new SqlConnection($"Server={server};Database={Database};User Id={Username};Password={Password};");
            }
            else
            {
                string connectionString = $"Server={Server};Database={Database};User={Username};Password={Password};";
                if (!string.IsNullOrEmpty(Port) && int.TryParse(Port, out int port))
                {
                    connectionString += $"Port={port};";
                }
                return new MySqlConnection(connectionString);
            }
        }

        public object CreateDataAdapter(IDbCommand cmd)
        {
            if (Type == DatabaseType.SqlServer)
            {
                return new SqlDataAdapter((SqlCommand)cmd);
            }
            else
            {
                return new MySqlDataAdapter((MySqlCommand)cmd);
            }
        }

        private static string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        private static string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            using (var aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Type})";
        }
    }
}
