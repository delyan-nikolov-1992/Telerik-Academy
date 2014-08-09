window.onload = function () {
    var canvas,
        ctx,
        sprites,
        rightKey = false,
        leftKey = false,
        upKey = false,
        downKey = false,
        x = 25,
        y = 455,
        width = 90,
        height = 115,
        srcX = -5,
        srcY = 0;

    (function init() {
        canvas = document.getElementById('canvas');
        ctx = canvas.getContext('2d');
        sprites = new Image();
        sprites.src = 'imgs/walk.png';
        setInterval(loop, 1000 / 30);
        document.addEventListener('keydown', keyDown, false);
        document.addEventListener('keyup', keyUp, false);
    })();

    function clearCanvas() {
        ctx.clearRect(0, 0, 1000, 800);
    }

    function drawMario() {
        if (rightKey) {
            sprites.src = 'imgs/walk.png';
            x += 5;
            y = 455;
        } else if (leftKey) {
            x -= 5;
            y = 450;
            sprites.src = 'imgs/walkReverse.png';
        }

        if (x > 925) {
            x = 925;
        }

        if (x < 0) {
            x = 0;
        }

        ctx.drawImage(sprites, srcX, srcY, width, height, x, y, width, height);
    }

    function loop() {
        clearCanvas();
        drawMario();
    }

    function keyDown(e) {
        if (e.keyCode == 39) {
            rightKey = true;
        } else if (e.keyCode == 37) {
            leftKey = true;
        }
    }

    function keyUp(e) {
        if (e.keyCode == 39) {
            rightKey = false;
        } else if (e.keyCode == 37) {
            leftKey = false;
        }
    }
};