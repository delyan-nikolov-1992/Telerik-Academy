var movingShapes = (function () {
    var angle = 0,
        counterX = 125,
        counterY = 75,
        movingShapesObj = {
            add: function (shape) {
                var divElement = document.createElement('div'),
                    container = document.getElementById('container');

                // styles
                divElement.style.backgroundColor = getRandomColor();
                divElement.style.color = getRandomColor();
                divElement.style.width = '30px';

                // border
                divElement.style.borderWidth = '3px';
                divElement.style.borderStyle = 'solid';
                divElement.style.borderColor = getRandomColor();

                // inner Text
                divElement.innerText = 'div';
                divElement.style.textAlign = 'center';

                // position
                divElement.style.position = 'absolute';

                if (shape === 'rect') {
                    divElement.className += ' rect';
                    container.appendChild(divElement);
                    moveDivsInRectangle();
                } else if (shape === 'ellipse') {
                    divElement.className += ' ellipse';
                    container.appendChild(divElement);
                    moveDivsInCircle();
                }
            }
        };

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

    function moveDivsInCircle() {
        var allDivs = document.getElementsByClassName('ellipse'),
            dX = 325,
            dY = 75,
            radius = 50,
            currentAngle,
            i,
            len;

        for (i = 0, len = allDivs.length; i < len; i++) {
            currentAngle = angle + i * 2 * Math.PI / len;

            allDivs[i].style.left = (dX + radius * Math.cos(currentAngle)) + 'px';
            allDivs[i].style.top = (dY + radius * Math.sin(currentAngle)) + 'px';
        }

        angle += 0.1;
        setTimeout(moveDivsInCircle, 100);
    }

    function moveDivsInRectangle() {
        var allDivs = document.getElementsByClassName('rect'),
            step = 5,
            dX = 0,
            dY = step,
            i,
            len;

        if (counterY >= 125) {
            dX = step * -1;
            dY = 0;
        }

        if (counterX <= 60) {
            dX = 0;
            dY = step * -1;
        }

        if (counterY <= 30) {
            dX = step;
            dY = 0;
        }

        if (counterX >= 150 && dX === step) {
            dX = 0;
            dY = step;
        }

        counterX += dX;
        counterY += dY;

        for (i = 0, len = allDivs.length; i < len; i++) {
            allDivs[i].style.left = (counterX) + 'px';
            allDivs[i].style.top = (counterY) + 'px';
        }

        setTimeout(moveDivsInRectangle, 100);
    }

    return movingShapesObj;
})();

//add element with rectangular movement
movingShapes.add('rect');

//add element with ellipse movement
movingShapes.add('ellipse');