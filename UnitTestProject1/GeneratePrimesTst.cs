using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GeneratePrimesTst
    {
        //[TestMethod]
        public void TestPrimes()
        {
            int[] nullArray = new PrimeGenerator().GeneratePrimes(0);
            Assert.AreEqual(0, nullArray.Length);
            
            int[] minArray = new PrimeGenerator().GeneratePrimes(2);
            Assert.AreEqual(1, minArray.Length);
            Assert.AreEqual(2, minArray[0]);

            int[] threeArray = new PrimeGenerator().GeneratePrimes(3);
            Assert.AreEqual(2, threeArray.Length);
            Assert.AreEqual(2, threeArray[0]);
            Assert.AreEqual(3, threeArray[1]);

            int[] centArray = new PrimeGenerator().GeneratePrimes(100);
            Assert.AreEqual(25, centArray.Length);
            Assert.AreEqual(97, centArray[24]);
        }
        //[TestMethod]
        public void TestExhaustive()
        {
            for (int i = 2; i < 500; i++)
            {
                VerifyPrimeList(new PrimeGenerator().GeneratePrimes(i));
            }
        }

        private void VerifyPrimeList(int[] list)
        {
            foreach (int i in list)
            {
                VerifyPrime(i);
            }
        }

        private void VerifyPrime(int n)
        {
            for (int factor = 2; factor < n; factor++)
            {
                Assert.IsTrue(n % factor != 0);
            }
        }
    }
}
