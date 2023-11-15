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
            var primes = GeneratePrimeNumbers(maxValue);
            if (primes.Length == 0)
            {
                Console.WriteLine("No primes");
            }
            else
            {
                foreach (var number in primes)
                {
                    Console.WriteLine(number);
                }
            }
        }

        // From the book "Agile Principles, Patterns and Practices in C#", by Robert C. Martin
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];
            }

            // declarations
            int s = maxValue + 1; // size of array
            bool[] f = new bool[s]; // flags for prime numbers
            int i;

            // initialize array to true
            for (i = 0; i < s; ++i)
                f[i] = true;

            // get rid of known non-primes 0 and 1
            f[0] = f[1] = false;

            // sieve up to square root of maxValue 
            int j;
            for (i = 2; i < Math.Sqrt(s) + 1; ++i)
            {
                if (f[i]) // if i is uncrossed, cross its multiples (multiples are not primes)
                {
                    for (j = 2 * i; j < s; j += i)
                        f[j] = false; // multiple is not a prime
                }
            }

            // how many primes?
            int count = 0;
            for (i = 0; i < s; ++i)
            {
                if (f[i])
                    ++count;
            }

            int[] primes = new int[count];

            // move primes into the result
            for (i = 0, j = 0; i < s; ++i)
            {
                if (f[i])
                    primes[j++] = i;
            }
            return primes; // return the primes
        }
    }
}
