function onCalcRectAreaBtnClick() {
    var width = jsConsole.readFloat('#tb-width'),
        height = jsConsole.readFloat('#tb-height'),
        area = width * height;

    if (width <= 0 || height <= 0) {
        jsConsole.writeLine("The rectangle does not exist!");
    } else {
        jsConsole.writeLine("The rectangle's area is: " + area);
    }
}