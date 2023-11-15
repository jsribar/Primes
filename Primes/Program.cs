using System;

namespace Vsite.Pood
{
    static public class Primes
    {
        static void Main(string[] args)
        {
            OutputPrimes(0);
            OutputPrimes(1);
            OutputPrimes(2);
            OutputPrimes(10);
            OutputPrimes(100);
        }

        static void OutputPrimes(int maxValue)
        {
            Console.WriteLine("Prime numbers up to {0}:", maxValue);
            Console.ReadKey(true);
            var primeNumbers = GeneratePrimeNumbers(maxValue);
            if (primeNumbers.Length == 0)
            {
                Console.WriteLine("No primes");
            }
            else
            {
                foreach (var number in primeNumbers)
                {
                    Console.WriteLine(number);
                }
            }
        }

        private static int s; // size of array
        private static bool[] f; // flags for prime numbers
        private static int[] primes;

        // From the book "Agile Principles, Patterns and Practices in C#", by Robert C. Martin
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];
            }

            GenerateSieve(maxValue);

            Sieve();

            CollectPrimes();

            return primes; // return the primes
        }

        private static void CollectPrimes()
        {
            int count = 0;
            for (int i = 0; i < s; ++i)
            {
                if (f[i])
                    ++count;
            }

            primes = new int[count];

            // move primes into the result
            for (int i = 0, j = 0; i < s; ++i)
            {
                if (f[i])
                    primes[j++] = i;
            }
        }

        private static void Sieve()
        {
            for (int i = 2; i < Math.Sqrt(s) + 1; ++i)
            {
                if (f[i]) // if i is uncrossed, cross its multiples (multiples are not primes)
                {
                    for (int j = 2 * i; j < s; j += i)
                        f[j] = false; // multiple is not a prime
                }
            }
        }

        private static void GenerateSieve(int maxValue)
        {
            s = maxValue + 1;
            f = new bool[s];

            // initialize array to true
            for (int i = 0; i < s; ++i)
                f[i] = true;

            // get rid of known non-primes 0 and 1
            f[0] = f[1] = false;
        }
    }
}
