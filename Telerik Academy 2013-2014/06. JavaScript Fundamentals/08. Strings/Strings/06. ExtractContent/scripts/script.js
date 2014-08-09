function onCheckExtractContentBtnClick() {
    var text = jsConsole.read('#tb-html'),
        changedText = "",
        i;

    for (i = 0; i < text.length; i++) {
        if (text[i] === '>') {
            i++;

            while (true) {
                if (i === text.length || text[i] === '<') {
                    break;
                }

                changedText += text[i];
                i++;
            }
        }
    }

    jsConsole.writeLine(changedText);
}