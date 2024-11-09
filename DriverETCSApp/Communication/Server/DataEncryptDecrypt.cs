using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DriverETCSApp.Communication.Server
{
    public class DataEncryptDecrypt
    {
        private byte[] Key;
        private byte[] IV;

        public DataEncryptDecrypt(byte[] key, byte[] iv) 
        {
            Key = key;
            IV = iv;
        }

        public byte[] Encrypt(string text)
        {
            byte[] encryptedText;
            using (var AES = Aes.Create())
            {
                AES.Key = Key;
                AES.IV = IV;

                ICryptoTransform encryptor = AES.CreateEncryptor(Key, IV);

                using (MemoryStream memorySteam = new MemoryStream())
                {
                    using (CryptoStream cryptoSream = new CryptoStream(memorySteam, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoSream))
                        {
                            streamWriter.Write(text);
                        }
                        encryptedText = memorySteam.ToArray();
                    }
                }
            }
            return encryptedText;
        }

        public string Decrypt(byte[] encryptedText)
        {
            string text;
            using (var AES = Aes.Create())
            {
                AES.Key = Key;
                AES.IV = IV;

                ICryptoTransform encryptor = AES.CreateDecryptor(Key, IV);

                using (MemoryStream memorySteam = new MemoryStream(encryptedText))
                {
                    using (CryptoStream cryptoSream = new CryptoStream(memorySteam, encryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamWriter = new StreamReader(cryptoSream))
                        {
                            text = streamWriter.ReadToEnd();
                        }
                    }
                }
            }
            return text;
        }
    }
}
