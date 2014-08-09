function onCheckPointWithinCircleAndOutOfRectangleBtnClick() {
    var xCoord = jsConsole.readFloat('#tb-x-coord'),
        yCoord = jsConsole.readFloat('#tb-y-coord');

    if (pointWithinCircle(xCoord, yCoord)) {
        if (pointOutOfRectangle(xCoord, yCoord)) {
            jsConsole.writeLine("The point is within circle K( (1,1), 3) and " +
            "out of rectangle R(top=1, left=-1, width=6, height=2).");
        } else {
            jsConsole.writeLine("The point is only within circle K( (1,1), 3).");
        }
    } else if (pointOutOfRectangle(xCoord, yCoord)) {
        jsConsole.writeLine("The point is only out of rectangle R(top=1, left=-1, width=6, height=2).");
    } else {
        jsConsole.writeLine("The point does not fulfill the conditions!");
    }
}

function pointWithinCircle(xCoord, yCoord) {
    if ((xCoord - 1) * (xCoord - 1) + (yCoord - 1) * (yCoord - 1) < 9) {
        return true;
    }

    return false;
}

function pointOutOfRectangle(xCoord, yCoord) {
    if (xCoord < -1 || xCoord > 5 || yCoord > 1 || yCoord < -1) {
        return true;
    }

    return false;
}