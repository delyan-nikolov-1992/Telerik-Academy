function onCalcTrapAreaBtnClick() {
    var firstSide = jsConsole.readFloat('#tb-first-side'),
        secondSide = jsConsole.readFloat('#tb-second-side'),
        height = jsConsole.readFloat('#tb-height'),
        area = ((firstSide + secondSide) / 2) * height;

    if (firstSide <= 0 || secondSide <= 0 || height <= 0) {
        jsConsole.writeLine("The trapezoid does not exist!");
    } else {
        jsConsole.writeLine("The trapezoid's area is: " + area);
    }
}