using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem
{
    static public class EncryptData
    {
        static public string EncryptPassword(User user, SecureData secureData)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(secureData.encryptKey);
                aes.IV = new byte[16];
                using MemoryStream memoryStream = new MemoryStream();
                using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                byte[] bytesPassword = Encoding.UTF8.GetBytes(user.Password);

                cryptoStream.Write(bytesPassword, 0, bytesPassword.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());

            }
        }
        static public string DecryptPassword(User user, SecureData secureData)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(secureData.encryptKey);
                aes.IV = new byte[16];
                using MemoryStream memoryStream = new MemoryStream();
                using CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                byte[] bytesPassword = Encoding.UTF8.GetBytes(user.Password);

                cryptoStream.Write(bytesPassword, 0, bytesPassword.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        static public string Hashing(string password, SecureData secureData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
