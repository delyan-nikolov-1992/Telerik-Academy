(function () {
    var nestedDivs = document.querySelectorAll("div > div");

    jsConsole.writeLine("Using querySelectorAll():");
    jsConsole.writeLine("All divs that are directly inside other divs are: " + nestedDivs.length);
}).call(this);

(function () {
    var allDivs = document.getElementsByTagName("div"),
        nestedDivs = [],
        i,
        len;

    for (i = 0, len = allDivs.length; i < len; i++) {
        if (allDivs[i].parentNode instanceof HTMLDivElement) {
            nestedDivs.push(allDivs[i]);
        }
    }

    jsConsole.writeLine("");
    jsConsole.writeLine("Using getElementsByTagName():");
    jsConsole.writeLine("All divs that are directly inside other divs are: " + nestedDivs.length);
}).call(this);