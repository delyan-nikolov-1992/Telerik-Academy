function onCheckGreaterNumberBtnClick() {
    var firstNumber = jsConsole.readInteger('#tb-first-number'),
        secondNumber = jsConsole.readInteger('#tb-second-number'),
        thirdNumber;

    if (firstNumber > secondNumber) {
        thirdNumber = firstNumber;
        firstNumber = secondNumber;
        secondNumber = thirdNumber;
    }

    jsConsole.writeLine("First number: " + firstNumber);
    jsConsole.writeLine("Second number: " + secondNumber);
}