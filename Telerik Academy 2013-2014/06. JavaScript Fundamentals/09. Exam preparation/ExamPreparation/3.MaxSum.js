// 01. Max Sum from JavaScript - 1 April 2013 - Evening

function Solve(input) {
    var maxSum = Number.NEGATIVE_INFINITY,
        subsequence,
        currentSum,
		i,
        j;

    input = input.map(Number);

    for (i = 1; i < input.length; i++) {
        for (j = i + 1; j <= input.length; j++) {
            subsequence = input.slice(i, j);
            currentSum = sumValues(subsequence);

            if (currentSum > maxSum) {
                maxSum = currentSum;
            }
        }
    }

    function sumValues(numbers) {
        var result = 0,
            i;

        for (i = 0; i < numbers.length; i++) {
            result += numbers[i];
        }

        return result;
    }

    return maxSum;
}