using lab3_patterns1.Interfaces;
using System;
namespace lab3_patterns1.Factories
{
    public abstract class CryptographerFactory
    {
        public abstract ICryptographer GetCryptographer();

        public CryptographerFactory()
        {
        }
    }
}
