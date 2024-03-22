
public class Solution {

    private static final int NO_PRIMES_FOUND = 0;
    private static final int FIRST_PRIME_NUMBER = 2;
    private static final int REDUCTION_FOR_NON_INCLUSIVE_RANGE = 1;

    public int countPrimes(int inputValue) {
        return countPrimesWithSieveOfEratosthenes(inputValue);
    }

    private int countPrimesWithSieveOfEratosthenes(int inputValue) {
        if (inputValue < 2) {
            return NO_PRIMES_FOUND;
        }

        boolean[] visited = new boolean[inputValue];
        int maxFactor = (int) Math.sqrt(inputValue);
        int nonPrimeNumbers = FIRST_PRIME_NUMBER - 1;

        for (int factor = FIRST_PRIME_NUMBER; factor <= maxFactor; ++factor) {
            if (visited[factor]) {
                continue;
            }

            int currentValue = factor * factor;
            while (currentValue < inputValue) {
                if (!visited[currentValue]) {
                    visited[currentValue] = true;
                    ++nonPrimeNumbers;
                }
                currentValue += factor;
            }
        }
        return inputValue - nonPrimeNumbers - REDUCTION_FOR_NON_INCLUSIVE_RANGE;
    }
}
