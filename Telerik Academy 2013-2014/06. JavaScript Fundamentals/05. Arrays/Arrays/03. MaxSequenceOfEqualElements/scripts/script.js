function onCheckMaxSequenceBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        currentLength,
        longestLength,
        number,
        i;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);
    }

    number = numbers[0];
    longestLength = currentLength = 1;

    for (i = 1; i < numbers.length; i++) {
        if (numbers[i] === numbers[i - 1]) {
            currentLength++;
        } else {
            currentLength = 1;
        }

        if (currentLength > longestLength) {
            longestLength = currentLength;
            number = numbers[i];
        }
    }

    for (i = 1; i <= longestLength; i++) {
        jsConsole.write(number);

        if (i !== longestLength) {
            jsConsole.write(", ");
        } else {
            jsConsole.writeLine("");
        }
    }
}