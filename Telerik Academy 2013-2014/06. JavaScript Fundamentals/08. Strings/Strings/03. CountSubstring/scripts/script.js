function onCheckCountSubstringBtnClick() {
    var text = jsConsole.read('#tb-text').toLowerCase(),
        substring = jsConsole.read('#tb-substring').toLowerCase(),
        counter = 0,
        i;

    for (i = 0; i < text.length; i++) {
        if (text.substr(i, substring.length) === substring) {
            counter++;
            i += substring.length - 1;
        }
    }

    jsConsole.writeLine("The result is " + counter);
}