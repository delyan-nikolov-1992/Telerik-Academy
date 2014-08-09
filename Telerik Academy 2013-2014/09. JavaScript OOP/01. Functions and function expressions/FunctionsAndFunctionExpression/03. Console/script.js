String.format = function (strings) {
    var formattedString = strings[0],
        regex,
        index,
        len;

    for (index = 0, len = strings.length - 1; index < len; index++) {
        regex = new RegExp("\\{" + index + "\\}", "gm");
        formattedString = formattedString.replace(regex, strings[index + 1]);
    }

    return formattedString;
};

var specialConsole = (function () {
    var specialConsoleObj = {
        writeLine: printOnConsole,
        writeError: printOnConsole,
        writeWarning: printOnConsole
    };

    function printOnConsole() {
        if (arguments.length > 1) {
            console.log(String.format(arguments));
        } else {
            console.log(arguments[0]);
        }
    }

    return specialConsoleObj;
})();

//logs to the console "Message: hello"
specialConsole.writeLine("Message: hello");

//logs to the console "Message: hello"
specialConsole.writeLine("Message: {0}", "hello");

specialConsole.writeError("Error: {0}", "Something happened");
specialConsole.writeWarning("Warning: {0}", "A warning");