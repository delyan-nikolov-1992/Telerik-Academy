function onCheckReverseDigitsBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        reversedNumber = 0;

    while (number > 0) {
        reversedNumber = reversedNumber * 10 + number % 10;
        number = parseInt(number / 10);
    }

    jsConsole.writeLine(reversedNumber);
}