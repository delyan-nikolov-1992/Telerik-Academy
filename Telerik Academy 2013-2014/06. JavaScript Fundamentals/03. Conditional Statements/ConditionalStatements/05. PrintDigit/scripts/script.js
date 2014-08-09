function onCheckPrintDigitBtnClick() {
    var digit = jsConsole.readInteger('#tb-digit');

    switch (digit) {
        case 0:
            jsConsole.writeLine("Zero");
            break;
        case 1:
            jsConsole.writeLine("One");
            break;
        case 2:
            jsConsole.writeLine("Two");
            break;
        case 3:
            jsConsole.writeLine("Three");
            break;
        case 4:
            jsConsole.writeLine("Four");
            break;
        case 5:
            jsConsole.writeLine("Five");
            break;
        case 6:
            jsConsole.writeLine("Six");
            break;
        case 7:
            jsConsole.writeLine("Seven");
            break;
        case 8:
            jsConsole.writeLine("Eight");
            break;
        case 9:
            jsConsole.writeLine("Nine");
            break;
        default:
            jsConsole.writeLine("There is no such digit!");
            break;
    }
}