function onCheckReverseStringBtnClick() {
    var text = jsConsole.read('#tb-text'),
        reversedText = "",
        i;

    for (i = text.length - 1; i >= 0; i--) {
        reversedText += text[i];
    }

    jsConsole.writeLine("The reversed text: " + reversedText);
}