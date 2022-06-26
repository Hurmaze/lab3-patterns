using lab3_patterns1.Factories;
using lab3_patterns1.Interfaces;
using System;
using System.Collections.Generic;

namespace ORPZ_Lab3_CreationalPatterns
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string teststring = "Hello world!";
            List<CryptographerFactory> creators = new List<CryptographerFactory>();

            creators.Add(new AesEncryptorCreator());
            creators.Add(new DesCryptographerFactory());

            Console.WriteLine("Factories");
            foreach (var creator in creators)
                Client(creator, teststring);
        }

        public static void Client(CryptographerFactory creator, string text)
        {
            ICryptographer cryptographer;
            cryptographer = creator.GetCryptographer();

            Console.WriteLine($"Encryption algorithm: {cryptographer.GetType().Name}");
            string encrypted = cryptographer.Encrypt(text);
            Console.WriteLine($"Encryption {encrypted}");

            string decrypthed = cryptographer.Decrypt(encrypted);
            Console.WriteLine($"Decrypted  {decrypthed}\n");

        }
    }
}
