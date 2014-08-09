(function () {
    if (!document.querySelectorAll) {
        document.querySelectorAll = function (selector) {
            if (selector[0] === '#') {
                return document.getElementById(selector.substr(1));
            }
            else if (selector[0] === '.') {
                return document.getElementsByClassName(selector.substr(1));
            }
            else {
                return document.getElementsByTagName(selector);
            }
        };
    }

    if (!document.querySelector) {
        document.querySelector = function (selector) {
            return querySelectorAll(selector)[0];
        };
    }
}).call(this);

(function () {
    var allDivs = document.querySelectorAll("div"),
        firstDiv = document.querySelector("div"),
        i,
        len;

    for (i = 0, len = allDivs.length; i < len; i++) {
        allDivs[i].style.backgroundColor = 'yellow';
        allDivs[i].style.color = 'blue';
    }

    firstDiv.style.color = 'pink';
}).call(this);