function onCheckMaxSequenceBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        currentLength,
        longestLength,
        firstNumber,
        i;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);
    }

    firstNumber = numbers[0];
    longestLength = currentLength = 1;

    for (i = 1; i < numbers.length; i++) {
        if (numbers[i] - 1 === numbers[i - 1]) {
            currentLength++;
        } else {
            currentLength = 1;
        }

        if (currentLength > longestLength) {
            longestLength = currentLength;
            firstNumber = numbers[i] - currentLength + 1;
        }
    }

    for (i = 0; i < longestLength; i++) {
        jsConsole.write(firstNumber + i);

        if (i !== longestLength - 1) {
            jsConsole.write(", ");
        } else {
            jsConsole.writeLine("");
        }
    }
}