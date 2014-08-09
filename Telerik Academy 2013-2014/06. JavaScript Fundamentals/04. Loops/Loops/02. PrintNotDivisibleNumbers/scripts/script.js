function onCheckPrintNumbersBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        i;

    for (i = 1; i <= number; i++) {
        if (!(i % 3 === 0 && i % 7 === 0)) {
            jsConsole.writeLine(i);
        }
    }
}