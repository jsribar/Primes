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

        private static bool[] crossed; // flags for prime numbers
        private static int[] primes;

        // From the book "Agile Principles, Patterns and Practices in C#", by Robert C. Martin
        public static int[] GeneratePrimeNumbers(int maxValue)
        {
            if (maxValue < 2)
            {
                return new int[0];
            }

            GenerateArrayOfFlags(maxValue);

            CrossOutMultiples();

            CollectUnCrossedIntegers();

            return primes; // return the primes
        }

        private static void CollectUnCrossedIntegers()
        {
            int count = 0;
            for (int i = 2; i < crossed.Length; ++i)
            {
                if (!crossed[i])
                {
                    ++count;
                }
            }

            primes = new int[count];

            // move primes into the result
            for (int i = 2, j = 0; i < crossed.Length; ++i)
            {
                if (!crossed[i])
                {
                    primes[j++] = i;
                }
            }
        }

        private static void CrossOutMultiples()
        {
            for (int i = 2; i < Math.Sqrt(crossed.Length) + 1; ++i)
            {
                if (!crossed[i]) // if i is uncrossed, cross its multiples (multiples are not primes)
                {
                    for (int j = 2 * i; j < crossed.Length; j += i)
                    {
                        crossed[j] = true; // multiple is not a prime
                    }
                }
            }
        }

        private static void GenerateArrayOfFlags(int maxValue)
        {
            crossed = new bool[maxValue + 1];

            for (int i = 2; i < crossed.Length; ++i)
            {
                crossed[i] = false;
            }
        }
    }
}
