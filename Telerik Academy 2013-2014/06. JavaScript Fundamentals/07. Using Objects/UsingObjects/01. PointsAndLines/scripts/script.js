function onCheckCalcDistanceBtnClick() {
    var firstXCoord = jsConsole.readInteger('#tb-first-x-coord'),
        firstYCoord = jsConsole.readInteger('#tb-first-y-coord'),
        secondXCoord = jsConsole.readInteger('#tb-second-x-coord'),
        secondYCoord = jsConsole.readInteger('#tb-second-y-coord'),
        firstPoint = createPoint(firstXCoord, firstYCoord),
        secondPoint = createPoint(secondXCoord, secondYCoord),
        distance = calculateDistance(firstPoint, secondPoint);

    jsConsole.writeLine("The distance between these points is: " + distance);
}

function onCheckIsTriangleBtnClick() {
    var // first line initialization
        firstLineFirstXCoord = jsConsole.readInteger('#tb-first-line-first-x-coord'),
        firstLineFirstYCoord = jsConsole.readInteger('#tb-first-line-first-y-coord'),
        firstLineSecondXCoord = jsConsole.readInteger('#tb-first-line-second-x-coord'),
        firstLineSecondYCoord = jsConsole.readInteger('#tb-first-line-second-y-coord'),
        firstLineFirstPoint = createPoint(firstLineFirstXCoord, firstLineFirstYCoord),
        firstLineSecondPoint = createPoint(firstLineSecondXCoord, firstLineSecondYCoord),
        firstLine = createLine(firstLineFirstPoint, firstLineSecondPoint),
        // second line initialization
        secondLineFirstXCoord = jsConsole.readInteger('#tb-second-line-first-x-coord'),
        secondLineFirstYCoord = jsConsole.readInteger('#tb-second-line-first-y-coord'),
        secondLineSecondXCoord = jsConsole.readInteger('#tb-second-line-second-x-coord'),
        secondLineSecondYCoord = jsConsole.readInteger('#tb-second-line-second-y-coord'),
        secondLineFirstPoint = createPoint(secondLineFirstXCoord, secondLineFirstYCoord),
        secondLineSecondPoint = createPoint(secondLineSecondXCoord, secondLineSecondYCoord),
        secondLine = createLine(secondLineFirstPoint, secondLineSecondPoint),
        // third line initialization
        thirdLineFirstXCoord = jsConsole.readInteger('#tb-third-line-first-x-coord'),
        thirdLineFirstYCoord = jsConsole.readInteger('#tb-third-line-first-y-coord'),
        thirdLineSecondXCoord = jsConsole.readInteger('#tb-third-line-second-x-coord'),
        thirdLineSecondYCoord = jsConsole.readInteger('#tb-third-line-second-y-coord'),
        thirdLineFirstPoint = createPoint(thirdLineFirstXCoord, thirdLineFirstYCoord),
        thirdLineSecondPoint = createPoint(thirdLineSecondXCoord, thirdLineSecondYCoord),
        thirdLine = createLine(thirdLineFirstPoint, thirdLineSecondPoint),
        // checks whether the three lines can form a triangle
        result = isTriangle(firstLine, secondLine, thirdLine);

    jsConsole.writeLine("Is triangle? " + result);
}

function createPoint(xCoord, yCoord) {
    var point = {
        xCoord: xCoord,
        yCoord: yCoord
    };

    return point;
}

function createLine(firstPoint, secondPoint) {
    var line = {
        firstPoint: firstPoint,
        secondPoint: secondPoint
    };

    return line;
}

function calculateDistance(firstPoint, secondPoint) {
    var distance = Math.sqrt((secondPoint.xCoord - firstPoint.xCoord) * (secondPoint.xCoord - firstPoint.xCoord) +
                             (secondPoint.yCoord - firstPoint.yCoord) * (secondPoint.yCoord - firstPoint.yCoord));

    return distance;
}

function isTriangle(firstLine, secondLine, thirdLine) {
    var firstDistance = calculateDistance(firstLine.firstPoint, firstLine.secondPoint),
        secondDistance = calculateDistance(secondLine.firstPoint, secondLine.secondPoint),
        thirdDistance = calculateDistance(thirdLine.firstPoint, thirdLine.secondPoint);

    if (firstDistance + secondDistance > thirdDistance &&
            firstDistance + thirdDistance > secondDistance &&
            secondDistance + thirdDistance > firstDistance) {
        return true;
    }

    return false;
}