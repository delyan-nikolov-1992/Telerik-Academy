function onCheckExtractPalindromesBtnClick() {
    var text = jsConsole.read('#tb-text'),
        words = text.match(/\w+/g),
        palindromes = [],
        i;

    String.prototype.reverse = function () {
        var reversedText = "",
            i;

        for (i = this.length - 1; i >= 0; i--) {
            reversedText += this[i];
        }

        return reversedText;
    };

    for (i = 0; i < words.length; i++) {
        if (words[i] === words[i].reverse()) {
            palindromes.push(words[i]);
        }
    }

    jsConsole.writeLine(palindromes.join(", "));
}