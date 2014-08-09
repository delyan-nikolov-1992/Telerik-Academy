function onCheckPrintNumbersBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        i;

    for (i = 1; i <= number; i++) {
        jsConsole.writeLine(i);
    }
}