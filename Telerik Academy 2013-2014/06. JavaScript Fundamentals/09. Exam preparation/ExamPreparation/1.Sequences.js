// 01. Sequences from JavaScript - 1 April 2013 - Morning

function Solve(input) {
	var result = 1,
		i;

	input = input.map(Number);

	for (i = 2; i < input.length; i++) {

		if (input[i - 1] > input[i]) {
			result++;
		}
	}

	return result;
}