
#include <cmath>
#include <vector>
using namespace std;

class Solution {

    static const int NO_PRIMES_FOUND = 0;0
    static const int FIRST_PRIME_NUMBER = 2;
    static const int REDUCTION_FOR_NON_INCLUSIVE_RANGE = 1;

public:
    int countPrimes(int inputValue) const {
        return countPrimesWithSieveOfEratosthenes(inputValue);
    }

private:
    int countPrimesWithSieveOfEratosthenes(int inputValue) const {
        if (inputValue < 2) {
            return NO_PRIMES_FOUND;
        }

        vector<bool> visited(inputValue + 1);
        int maxFactor = sqrt(inputValue);
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
};
