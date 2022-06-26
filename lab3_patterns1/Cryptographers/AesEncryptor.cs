using lab3_patterns1.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace lab3_patterns1.Cryptographers
{
    public class AesEncryptor : ICryptographer
    {
        private byte[] Key;

        public string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                Key = aes.Key;
            }
            RijndaelManaged objrij = new RijndaelManaged();

            objrij.Mode = CipherMode.CBC;

            objrij.Padding = PaddingMode.PKCS7;

            objrij.KeySize = 0x80;

            objrij.BlockSize = 0x80;

            byte[] EncryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = Key.Length;

            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }

            Array.Copy(Key, EncryptionkeyBytes, len);

            objrij.Key = EncryptionkeyBytes;

            objrij.IV = EncryptionkeyBytes;

            ICryptoTransform objtransform = objrij.CreateEncryptor();

            byte[] textDataByte = Encoding.UTF8.GetBytes(plainText);

            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        public string Decrypt(string cipherText)
        {
            RijndaelManaged objrij = new RijndaelManaged();

            objrij.Mode = CipherMode.CBC;

            objrij.Padding = PaddingMode.PKCS7;

            objrij.KeySize = 0x80;

            objrij.BlockSize = 0x80;

            byte[] encryptedTextByte = Convert.FromBase64String(cipherText);

            byte[] EncryptionkeyBytes = new byte[0x10];

            int len = Key.Length;

            if (len > EncryptionkeyBytes.Length)
            {
                len = EncryptionkeyBytes.Length;
            }

            Array.Copy(Key, EncryptionkeyBytes, len);

            objrij.Key = EncryptionkeyBytes;

            objrij.IV = EncryptionkeyBytes;

            byte[] TextByte = objrij.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);

            return Encoding.UTF8.GetString(TextByte);
        }
    }
}
