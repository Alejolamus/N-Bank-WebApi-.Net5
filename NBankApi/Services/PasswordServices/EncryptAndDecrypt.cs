using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace NBankApi.Services.PasswordServices
{
    public class EncryptAndDecrypt
    {
        byte[] Key = Encoding.UTF8.GetBytes("jWnZq4tW!z%C*F-JaNdRgUKXp2s5u8x");
        byte[] Iv = Encoding.UTF8.GetBytes("q369z$q31*_t6?z$");
        public string Encrypt(string password)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = Iv;
                ICryptoTransform encrytor = aes.CreateEncryptor();
                MemoryStream msEncript = new MemoryStream();
                CryptoStream csEncrypt = new CryptoStream(msEncript, encrytor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(password);
                }
                return Convert.ToBase64String(msEncript.ToArray());

            }
        }
        public string Decrypt(string textEncrypt)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = Iv;
                ICryptoTransform decrytor = aes.CreateDecryptor();
                byte[] textEncryptByte = Convert.FromBase64String(textEncrypt);
                MemoryStream msEncript = new MemoryStream(textEncryptByte);
                CryptoStream csEncrypt = new CryptoStream(msEncript, decrytor, CryptoStreamMode.Read);
                StreamReader srDecrypt = new StreamReader(csEncrypt);
                return srDecrypt.ReadToEnd();
            }
        }
    }
}