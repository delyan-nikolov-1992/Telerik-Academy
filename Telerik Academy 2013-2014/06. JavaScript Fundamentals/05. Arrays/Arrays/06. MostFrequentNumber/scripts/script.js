function onCheckMostFrequentBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        longestLength = 0,
        currentLength = 0,
        mostFrequentNumber,
        i,
        j;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);
    }

    for (i = 0; i < numbers.length; i++) {
        currentLength = 1;

        for (j = i + 1; j < numbers.length; j++) {
            if (numbers[j] === numbers[i]) {
                currentLength++;
            }
        }

        if (currentLength > longestLength) {
            longestLength = currentLength;
            mostFrequentNumber = numbers[i];
        }
    }

    jsConsole.writeLine(mostFrequentNumber + " (" + longestLength +
            ((longestLength !== 1) ? " times)" : " time)"));
}