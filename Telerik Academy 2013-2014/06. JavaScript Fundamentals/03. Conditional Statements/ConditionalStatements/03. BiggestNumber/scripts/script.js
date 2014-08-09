function onCheckBiggestNumberBtnClick() {
    var firstNumber = jsConsole.readInteger('#tb-first-number'),
        secondNumber = jsConsole.readInteger('#tb-second-number'),
        thirdNumber = jsConsole.readInteger('#tb-third-number');

    if (firstNumber >= secondNumber) {
        if (firstNumber >= thirdNumber) {
            jsConsole.writeLine("The biggest number is " + firstNumber);
        } else {
            jsConsole.writeLine("The biggest number is " + thirdNumber);
        }
    } else if (secondNumber >= thirdNumber) {
        jsConsole.writeLine("The biggest number is " + secondNumber);
    } else {
        jsConsole.writeLine("The biggest number is " + thirdNumber);
    }
}