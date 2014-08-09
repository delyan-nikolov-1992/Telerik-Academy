function onCheckThirdDigitBtnClick() {
    var number = jsConsole.readInteger('#tb-number') / 100,
        digit = parseInt(number % 10);

    if (digit === 7) {
        jsConsole.writeLine("true");
    } else {
        jsConsole.writeLine("false");
    }
}