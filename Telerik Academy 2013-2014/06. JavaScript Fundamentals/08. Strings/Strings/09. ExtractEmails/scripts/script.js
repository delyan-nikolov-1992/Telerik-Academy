function onCheckExtractEmailBtnClick() {
    var text = jsConsole.read('#tb-text'),
        emails = text.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);

    jsConsole.writeLine(emails);
}