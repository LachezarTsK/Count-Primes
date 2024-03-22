
using System;

public class Solution
{
    private static readonly int NO_PRIMES_FOUND = 0;
    private static readonly int FIRST_PRIME_NUMBER = 2;
    private static readonly int REDUCTION_FOR_NON_INCLUSIVE_RANGE = 1;

    public int CountPrimes(int inputValue)
    {
        return CountPrimesWithSieveOfEratosthenes(inputValue);
    }


    private int CountPrimesWithSieveOfEratosthenes(int inputValue)
    {
        if (inputValue < 2)
        {
            return NO_PRIMES_FOUND;
        }

        bool[] visited = new bool[inputValue + 1];
        int maxFactor = (int)Math.Sqrt(inputValue);
        int nonPrimeNumbers = FIRST_PRIME_NUMBER - 1;

        for (int factor = FIRST_PRIME_NUMBER; factor <= maxFactor; ++factor)
        {
            if (visited[factor])
            {
                continue;
            }

            int currentValue = factor * factor;
            while (currentValue < inputValue)
            {
                if (!visited[currentValue])
                {
                    visited[currentValue] = true;
                    ++nonPrimeNumbers;
                }
                currentValue += factor;
            }
        }
        return inputValue - nonPrimeNumbers - REDUCTION_FOR_NON_INCLUSIVE_RANGE;
    }
}
