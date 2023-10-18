using Vsite.Pood;

namespace UnitTests
{
    [TestClass]
    public class TestGeneratePrimeNumbers
    {
        [TestMethod]
        public void ForArgument0ReturnEmptyArray()
        {
            Assert.AreEqual(0, Primes.GeneratePrimeNumbers(0).Length);
        }

        [TestMethod]
        public void ForArgument1ReturnEmptyArray()
        {
            Assert.AreEqual(0, Primes.GeneratePrimeNumbers(1).Length);
        }

        [TestMethod]
        public void ForArgument10ReturnArrayOf4Numbers()
        {
            Assert.AreEqual(4, Primes.GeneratePrimeNumbers(10).Length);
            Assert.AreEqual(2, Primes.GeneratePrimeNumbers(10)[0]);
            Assert.AreEqual(3, Primes.GeneratePrimeNumbers(10)[1]);
            Assert.AreEqual(5, Primes.GeneratePrimeNumbers(10)[2]);
            Assert.AreEqual(7, Primes.GeneratePrimeNumbers(10)[3]);
        }

        [TestMethod]
        public void ForArgument100ReturnArrayOf4Numbers()
        {
            Assert.AreEqual(25, Primes.GeneratePrimeNumbers(100).Length);
            Assert.AreEqual(97, Primes.GeneratePrimeNumbers(100)[24]);
        }
    }
}