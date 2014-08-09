function onCheckPrintLastDigitBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        lastDigit = number % 10,
        digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    jsConsole.writeLine(digits[lastDigit]);
}