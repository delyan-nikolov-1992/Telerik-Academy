function onCheckPointWithinCircleBtnClick() {
    var xCoord = jsConsole.readFloat('#tb-x-coord'),
        yCoord = jsConsole.readFloat('#tb-y-coord');

    if (xCoord * xCoord + yCoord * yCoord < 25) {
        jsConsole.writeLine("The point is within the circle K(O, 5)!");
    } else {
        jsConsole.writeLine("The point is not within the circle K(O, 5)!");
    }
}