function onCheckReplaceTagBtnClick() {
    var text = jsConsole.read('#tb-html'),
        changedText = "",
        i = 0;

    for (i = 0; i < text.length; i++) {
        if (text.substr(i, 9) === "<a href=\"") {
            changedText += "[URL=";
            i += 9;

            while (true) {
                if (text.substr(i, 2) === "\">") {
                    changedText += "]";
                    i += 2;
                    break;
                }

                changedText += text[i];
                i++;
            }
        }

        if (text.substr(i, 4) === "</a>") {
            changedText += "[/URL]";
            i += 4;
        } else {
            changedText += text[i];
        }
    }

    jsConsole.writeLine(changedText);
}