using System;
namespace lab3_patterns1.Interfaces
{
    public interface ICryptographer
    {
        string Encrypt(string plainText);
        string Decrypt(string cipheredText);
    }
}
