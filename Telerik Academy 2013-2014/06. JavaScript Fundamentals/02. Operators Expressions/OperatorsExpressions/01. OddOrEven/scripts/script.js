function onCheckOddOrEvenBtnClick() {
    var number = jsConsole.readInteger('#tb-number');

    if (number % 2) {
        jsConsole.writeLine(number + " is odd");
    } else {
        jsConsole.writeLine(number + " is even");
    }
}