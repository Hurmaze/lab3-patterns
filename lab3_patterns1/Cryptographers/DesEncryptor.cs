using lab3_patterns1.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace lab3_patterns1.Cryptographers
{
    public class DesEncryptor : ICryptographer
    {
        private byte[] Key;
        private byte[] IV;

        public string Encrypt(string plainText)
        {
            using (DES des = DES.Create())
            {
                Key = des.Key;
                IV = des.IV;
            }

            DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();

            byte[] inputByteArray = Encoding.UTF8.GetBytes(plainText);

            MemoryStream Objmst = new MemoryStream();

            CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

            Objcs.Write(inputByteArray, 0, inputByteArray.Length);

            Objcs.FlushFinalBlock();

            return Convert.ToBase64String(Objmst.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider();

            byte[] inputByteArray = Convert.FromBase64String(cipherText);

            MemoryStream Objmst = new MemoryStream();

            CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateDecryptor(Key, IV), CryptoStreamMode.Write);

            Objcs.Write(inputByteArray, 0, inputByteArray.Length);

            Objcs.FlushFinalBlock();

            Encoding encoding = Encoding.UTF8;

            return encoding.GetString(Objmst.ToArray());
        }
    }
}
