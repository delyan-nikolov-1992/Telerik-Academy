function onCheckSearchForWordBtnClick(insensitive) {
    var text = jsConsole.read('#tb-text'),
        word = jsConsole.read('#tb-word'),
        modifier = "g",
        regex,
        count;

    switch (arguments.length) {
        case 0:
            regex = new RegExp("\\b" + word + "\\b", modifier);
            break;
        case 1:
            modifier += insensitive;
            regex = new RegExp("\\b" + word + "\\b", modifier);
            break;
    }

    count = text.match(regex);
    jsConsole.writeLine(count === null ? "No occurrences of the word " + word
                                           : count.length + (count.length === 1 ? " occurrence"
                                           : " occurrences") + " of the word " + word);
}