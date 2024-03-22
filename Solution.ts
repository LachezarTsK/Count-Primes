
function countPrimes(inputValue: number): number {
    this.NO_PRIMES_FOUND = 0;
    return countPrimesWithSieveOfEratosthenes(inputValue);
};


function countPrimesWithSieveOfEratosthenes(inputValue: number): number {
    if (inputValue < 2) {
        return this.NO_PRIMES_FOUND;
    }

    const FIRST_PRIME_NUMBER = 2;
    const REDUCTION_FOR_NON_INCLUSIVE_RANGE = 1;

    const visited = new Array(inputValue + 1).fill(false);
    const maxFactor = Math.floor(Math.sqrt(inputValue));
    let nonPrimeNumbers = FIRST_PRIME_NUMBER - 1;

    for (let factor = FIRST_PRIME_NUMBER; factor <= maxFactor; ++factor) {
        if (visited[factor]) {
            continue;
        }

        let currentValue = factor * factor;
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
