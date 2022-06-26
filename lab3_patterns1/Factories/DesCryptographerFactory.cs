using lab3_patterns1.Interfaces;
using ORPZ_Lab3_CreationalPatterns;
using System;
namespace lab3_patterns1.Factories
{
    public class DesCryptographerFactory : CryptographerFactory
    {
        public DesCryptographerFactory()
        {
        }

        public override ICryptographer GetCryptographer()
        {
            return new DesEncryptor();
        }
    }
}
