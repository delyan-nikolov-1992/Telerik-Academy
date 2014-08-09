function onCheckChangeRegionsBtnClick() {
    var text = jsConsole.read('#tb-text'),
        changedText = "",
        attachedText = "",
        i,
        j;

    for (i = 0; i < text.length; i++) {
        if (text.substr(i, 8) === "<upcase>") {
            i += 8;

            while (true) {
                if (text.substr(i, 9) === "</upcase>") {
                    changedText += attachedText.toUpperCase();
                    i += 8;
                    break;
                }

                if (i === text.length) {
                    changedText += "<upcase>" + attachedText;
                    break;
                }

                attachedText += text[i];
                i++;
            }
        } else if (text.substr(i, 9) === "<lowcase>") {
            i += 9;

            while (true) {
                if (text.substr(i, 10) === "</lowcase>") {
                    changedText += attachedText.toLowerCase();
                    i += 9;
                    break;
                }

                if (i === text.length) {
                    changedText += "<lowcase>" + attachedText;
                    break;
                }

                attachedText += text[i];
                i++;
            }
        } else if (text.substr(i, 9) === "<mixcase>") {
            i += 9;

            while (true) {
                if (text.substr(i, 10) === "</mixcase>") {
                    for (j = 0; j < attachedText.length; j++) {
                        if (getRandomInt() === 0) {
                            changedText += attachedText[j].toLowerCase();
                        } else {
                            changedText += attachedText[j].toUpperCase();
                        }
                    }

                    i += 9;
                    break;
                }

                if (i === text.length) {
                    changedText += "<mixcase>" + attachedText;
                    break;
                }

                attachedText += text[i];
                i++;
            }
        } else {
            changedText += text[i];
        }

        attachedText = "";
    }

    jsConsole.writeLine(changedText);
}

function getRandomInt() {
    return Math.floor(Math.random() * 2);
}