function onDivideBySevenAndFiveBtnClick() {
    var number = jsConsole.readInteger('#tb-number');

    if (number % 7 === 0 && number % 5 === 0) {
        jsConsole.writeLine(number + " can be divided by seven and five in the same time");
    } else {
        jsConsole.writeLine(number + " can not be divided by seven and five in the same time");
    }
}