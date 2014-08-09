function onCheckOrderByDescendingBtnClick() {
    var firstNumber = jsConsole.readFloat('#tb-first-number'),
        secondNumber = jsConsole.readFloat('#tb-second-number'),
        thirdNumber = jsConsole.readFloat('#tb-third-number');

    if (firstNumber >= secondNumber) {
        if (firstNumber >= thirdNumber) {
            jsConsole.write(firstNumber + " ");

            if (secondNumber >= thirdNumber) {
                jsConsole.writeLine(secondNumber + " " + thirdNumber);
            } else {
                jsConsole.writeLine(thirdNumber + " " + secondNumber);
            }
        } else {
            jsConsole.writeLine(thirdNumber + " " + firstNumber + " " + secondNumber);
        }
    } else if (secondNumber >= thirdNumber) {
        jsConsole.write(secondNumber + " ");

        if (firstNumber >= thirdNumber) {
            jsConsole.writeLine(firstNumber + " " + thirdNumber);
        } else {
            jsConsole.writeLine(thirdNumber + " " + firstNumber);
        }
    } else {
        jsConsole.writeLine(thirdNumber + " " + secondNumber + " " + firstNumber);
    }
}