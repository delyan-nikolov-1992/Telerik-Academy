window.onload = function () {
    var dFrag = document.createDocumentFragment(),
        numberOfDivs = 10,
        i;

    for (i = 0; i < numberOfDivs; i++) {
        dFrag.appendChild(createDivElement());
    }

    document.body.appendChild(dFrag);

    function createDivElement() {
        var div = document.createElement('div'),
            width = randomIntFromInterval(20, 100) + 'px',
            height = randomIntFromInterval(20, 100) + 'px',
            backgroundColor = getRandomColor(),
            fontColor = getRandomColor(),
            position = 'absolute',
            fullWidth = window.innerWidth,
            fullHeight = window.innerHeight,
            left = randomIntFromInterval(0, fullWidth) + 'px',
            top = randomIntFromInterval(0, fullHeight) + 'px',
            strong = document.createElement('strong'),
            strongInnerHTML = 'div',
            borderRadius = randomIntFromInterval(0, 50) + '%',
            borderColor = getRandomColor,
            borderWidth = randomIntFromInterval(1, 20) + 'px',
            borderStyle = 'solid';

        // styles for the div
        div.style.width = width;
        div.style.height = height;
        div.style.background = backgroundColor;
        div.style.color = fontColor;
        div.style.position = position;
        div.style.left = left;
        div.style.top = top;

        // adding the strong element
        strong.innerHTML = strongInnerHTML;
        div.appendChild(strong);

        // style for the border
        div.style.borderRadius = borderRadius;
        div.style.borderColor = borderColor;
        div.style.borderWidth = borderWidth;
        div.style.borderStyle = borderStyle;

        return div;
    }

    function randomIntFromInterval(min, max) {
        var randomInt = Math.floor(Math.random() * (max - min + 1) + min);

        return randomInt;
    }

    function getRandomColor() {
        var letters = '0123456789ABCDEF'.split(''),
            color = '#';

        for (var i = 0; i < 6; i++) {
            color += letters[randomIntFromInterval(0, 15)];
        }

        return color;
    }
};