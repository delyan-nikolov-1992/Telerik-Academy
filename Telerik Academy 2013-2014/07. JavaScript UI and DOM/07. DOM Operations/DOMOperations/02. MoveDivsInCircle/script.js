window.onload = function () {
    var dFrag = document.createDocumentFragment(),
        numberOfDivs = 5,
        angle = 0,
        i;

    for (i = 0; i < numberOfDivs; i++) {
        dFrag.appendChild(createDivElement());
    }

    document.body.appendChild(dFrag);
    moveDivsInCircle();

    function createDivElement() {
        var div = document.createElement('div'),
            width = 30 + 'px',
            backgroundColor = 'green',
            fontColor = 'red',
            position = 'absolute',
            strong = document.createElement('strong'),
            textAlign = 'center',
            strongInnerHTML = 'div',
            borderRadius = 50 + '%',
            borderColor = 'blue',
            borderWidth = 2 + 'px',
            borderStyle = 'solid';

        // styles for the div
        div.style.width = width;
        div.style.background = backgroundColor;
        div.style.color = fontColor;
        div.style.position = position;

        // adding the strong element
        strong.innerHTML = strongInnerHTML;
        div.appendChild(strong);
        div.style.textAlign = textAlign;

        // style for the border
        div.style.borderRadius = borderRadius;
        div.style.borderColor = borderColor;
        div.style.borderWidth = borderWidth;
        div.style.borderStyle = borderStyle;

        return div;
    }

    function moveDivsInCircle() {
        var allDivs = document.body.getElementsByTagName('div'),
            dX = 200,
            dY = 200,
            radius = 50,
            currentAngle,
            i;

        for (i = 0; i < allDivs.length; i++) {
            currentAngle = angle + i * 2 * Math.PI / numberOfDivs;

            allDivs[i].style.left = (dX + radius * Math.cos(currentAngle)) + 'px';
            allDivs[i].style.top = (dY + radius * Math.sin(currentAngle)) + 'px';
        }

        angle += 0.05;
        setTimeout(moveDivsInCircle, 100);
    }
};