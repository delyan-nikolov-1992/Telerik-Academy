function onCheckCompareArraysBtnClick() {
    var firstArray = jsConsole.read('#tb-first-array'),
        secondArray = jsConsole.read('#tb-second-array'),
        i;

    if (firstArray.length === secondArray.length) {
        for (i = 0; i < firstArray.length; i++) {
            if (firstArray[i] > secondArray[i]) {
                jsConsole.writeLine(firstArray[i] + " > " + secondArray[i]);
            } else if (firstArray[i] < secondArray[i]) {
                jsConsole.writeLine(firstArray[i] + " < " + secondArray[i]);
            } else {
                jsConsole.writeLine(firstArray[i] + " = " + secondArray[i]);
            }
        }
    } else {
        jsConsole.writeLine("The two arrays must have equal lengths!");
    }
}