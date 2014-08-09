var domModule = (function () {
    var buffer = [];

    var domModuleObj = {
        appendChild: function (domElement, selector) {
            var parentElement = document.querySelector(selector);

            parentElement.appendChild(domElement);
        },
        removeChild: function (parentSelector, childSelector) {
            var parent = document.querySelector(parentSelector),
                child = document.querySelector(childSelector);

            parent.removeChild(child);
        },
        addHandler: function (selector, eventType, eventListener) {
            var element = document.querySelector(selector);

            element.addEventListener(eventType, eventListener);
        },
        appendToBuffer: function (selector, element) {
            var currentDomElement;

            if (buffer[selector]) {
                buffer[selector].push(element);

                if (buffer[selector].length === 100) {
                    currentDomElement = document.querySelector(selector);

                    for (var i = 0; i < buffer[selector].length; i++) {
                        currentDomElement.appendChild(buffer[selector][i]);
                    }

                    buffer[selector] = [];
                }
            } else {
                buffer[selector] = [];
                buffer[selector].push(element);
            }
        }
    };

    return domModuleObj;
})(),
    div = document.createElement('div'),
    i;

// appends div to #wrapper
domModule.appendChild(div, '#wrapper');

// removes li:first-child from ul
domModule.removeChild('ul', 'li:first-child');

// add handler to each a element with class button
domModule.addHandler('a.button', 'click', function () { alert('Clicked'); });

// appends 100 divs to #container
for (i = 0; i < 100; i++) {
    domModule.appendToBuffer('#container', div.cloneNode(true));
}