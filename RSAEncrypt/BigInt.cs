using System;
using System.Numerics;
using System.Security.Cryptography;

namespace BigInt
{
    public class Program
    {
        public static BigInteger GenerateRandomBigInteger(int length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] data = new byte[length];
            rng.GetBytes(data);
            BigInteger result = new BigInteger(data);
            return result < 0 ? -result : result; // Make sure the number is positive
        }
        public static BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static BigInteger ModuloBigInteger(BigInteger dividend, BigInteger divisor)
        {
            if (divisor == 0)
            {
                throw new ArgumentException("Division by zero is not allowed.");
            }

            BigInteger remainder = BigInteger.Remainder(dividend, divisor);

            return remainder;
        }

        public static BigInteger ModularExponentiation(BigInteger a, BigInteger x, BigInteger p)
        {
            BigInteger result = 1;
            a = a % p;
            while (x > 0)
            {
                if (x % 2 == 1)
                    result = (result * a) % p;
                x = x >> 1;
                a = (a * a) % p;
            }
            return result;
        }

        public static bool MillerRabin(BigInteger n, int k)
        {
            if (n <= 1 || n == 4) return false;
            if (n <= 3) return true;

            BigInteger d = n - 1;
            while (d % 2 == 0)
                d /= 2;

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[n.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < k; i++)
            {
                do
                {
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= n - 2);

                if (ModularExponentiation(a, d, n) == 1 || ModularExponentiation(a, d, n) == n - 1)
                    continue;

                for (BigInteger r = d; r != n - 1; r *= 2)
                {
                    a = (a * a) % n;
                    if (a == 1) return false;
                    if (a == n - 1) break;
                }

                return false;
            }

            return true;
        }

        // Check if a number is prime number or not
        public static bool isPrime(BigInteger n)
        {
            // Number of checks
            int k = 10;

            // MillerRabin Algorithm
            return MillerRabin(n, k);
        }

        public static BigInteger GenerateRandomPrime(int length)
        {
            BigInteger prime;
            do
            {
                prime = GenerateRandomBigInteger(length);
            }
            while (!isPrime(prime));

            return prime;
        }

        public static BigInteger ModularInverse(BigInteger e, BigInteger u)
        {
            BigInteger x = 0, y = 0;
            BigInteger r = ExtendedGCD(e, u, ref x, ref y);

            if (r == 1)
            {
                x = (x % u + u) % u; // Ensure x is positive
                return x;
            }
            return -1; // Modular inverse doesn't exist
        }

        static BigInteger ExtendedGCD(BigInteger a, BigInteger b, ref BigInteger x, ref BigInteger y)
        {
            x = 1;
            y = 0;

            if (b == 0)
                return a;

            BigInteger new_x = 0;
            BigInteger new_y = 1;
            BigInteger new_r = b;
            BigInteger r = a;
            BigInteger quotient, tmp;

            while (new_r != 0)
            {
                quotient = r / new_r;

                tmp = r;
                r = new_r;
                new_r = tmp - quotient * new_r;

                tmp = x;
                x = new_x;
                new_x = tmp - quotient * new_x;

                tmp = y;
                y = new_y;
                new_y = tmp - quotient * new_y;
            }

            return r;
        }
    }    
}
