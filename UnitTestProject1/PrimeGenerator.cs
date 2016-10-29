using System;

namespace UnitTestProject1
{
/**
 * Refactorings:
 * <p/>
 * Extract Fields.
 * Extract Methods: initArrayOfIntegers, crossOutMultiples, putUncrossedIntegerIntoResult
 * Inline s with isPrime.length
 * Rename isPrime to isCrossed
 * Ensure for loop starts from 2
 * Extract Methods: crossOutMultipleOf, numberOfUncrossedIntegers, notCrossed
 * Rename methods to: uncrossIntegersUpTo
 *
 * @author jacky
 */

	public class PrimeGenerator
	{
		public int[] GeneratePrimes(int maxValue)
        {
		    if (maxValue < 2)
		    {
		        return new int[0]; 
		    }
		    else
		    {
		        //得到数据长度 数组
		        var isPrime = GetIsPrimes(maxValue);
		        SieveValue(isPrime);
		        return GetPrimes(isPrime);
		    }
        }
        /// <summary>
        /// 初始化一个数据长度 数组
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private static bool[] GetIsPrimes(int maxValue)
        {
            bool[] isPrime = new bool[maxValue + 1];

            // initialize array to true
            for (int i = 0; i < isPrime.Length; i++)
            {
                isPrime[i] = true;
            }

            // get rid of known non-primes
            isPrime[0] = isPrime[1] = false;
            return isPrime;
        }

        private static void SieveValue(bool[] isPrime)
	    {
            // sieve 筛选标识符合的数据到数组中 
	        for (int i = 2; i < Math.Sqrt(isPrime.Length) + 1; i++)
	        {
	            for (int j = 2*i; j < isPrime.Length; j += i)
	            {
	                isPrime[j] = false; // multiple is not prime
	            }
	        }
	    }

	    private static int[] GetPrimes(bool[] isPrime)
	    {
            // how many primes are there?
	        //得到所有是素数的 数量
	        int count = 0;
	        for (int i = 0; i < isPrime.Length; i++)
	        {
	            if (isPrime[i])
	                count++; // bump count
	        }
	        int[] primes = new int[count];
	        // move the primes into the result
	        //把素数拿到一个新的数组中 并且返回
	        for (int i = 0, j = 0; i < isPrime.Length; i++)
	        {
	            if (isPrime[i])
	                primes[j++] = i;
	        }
	        return primes;
	    }

	}
}

