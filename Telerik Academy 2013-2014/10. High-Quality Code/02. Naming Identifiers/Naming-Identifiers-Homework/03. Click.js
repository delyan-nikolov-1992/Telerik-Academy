function ClickOnButton(event, args) {
    "use strict";

    var currentWindow = window,
        browser = currentWindow.navigator.appCodeName,
        checkBrowser = browser === "Mozilla";

    if (checkBrowser) {
        alert("Yes");
    } else {
        alert("No");
    }
}