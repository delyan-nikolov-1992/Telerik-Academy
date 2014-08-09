function onCheckShowSignBtnClick() {
    var firstNumber = jsConsole.readFloat('#tb-first-number'),
        secondNumber = jsConsole.readFloat('#tb-second-number'),
        thirdNumber = jsConsole.readFloat('#tb-third-number');

    if (firstNumber === 0 || secondNumber === 0 || thirdNumber === 0) {
        jsConsole.writeLine("The product of these numbers is 0.");
    } else if (firstNumber > 0) {
        if ((secondNumber > 0 && thirdNumber > 0) || (secondNumber < 0 && thirdNumber < 0)) {
            jsConsole.writeLine("The sign of the product of these numbers is '+'.");
        } else {
            jsConsole.writeLine("The sign of the product of these numbers is '-'.");
        }
    } else {
        if ((secondNumber > 0 && thirdNumber > 0) || (secondNumber < 0 && thirdNumber < 0)) {
            jsConsole.writeLine("The sign of the product of these numbers is '-'.");
        } else {
            jsConsole.writeLine("The sign of the product of these numbers is '+'.");
        }
    }
}