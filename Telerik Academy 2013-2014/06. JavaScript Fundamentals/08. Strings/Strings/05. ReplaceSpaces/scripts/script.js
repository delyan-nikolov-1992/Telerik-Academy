function onCheckReplaceSpacesBtnClick() {
    var text = jsConsole.read('#tb-text'),
        changedText = "",
        i;

    for (i = 0; i < text.length; i++) {
        if (text[i] === " ") {
            changedText += "&nbsp;";
        } else {
            changedText += text[i];
        }
    }

    jsConsole.writeLine(changedText);
}