using System;
using System.Security.Cryptography;
using System.Text;

namespace Checkpoint4_V2
{
    public static class Password
    {
        public static string Encrypt(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 hasher = SHA256.Create();
            byte[] encryptedPasswordBytes = hasher.ComputeHash(passwordBytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < encryptedPasswordBytes.Length; i++)
            {
                builder.Append(encryptedPasswordBytes[i].ToString("x2"));
            }
            String encryptedPassword = builder.ToString();
            return encryptedPassword;
        }
    }
}
