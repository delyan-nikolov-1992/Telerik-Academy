(function () {
    var canvas = document.getElementById("the-canvas"),
		context = canvas.getContext("2d"),
        centerX = 11,
		centerY = 100,
		radius = 10,
		stepX = 3,
		stepY = 3;

    drawCirlce();

    function drawCirlce() {
        context.clearRect(0, 0, canvas.width, canvas.height);

        context.beginPath();
        context.arc(centerX, centerY, radius, 0, 2 * Math.PI);
        context.fill();
        context.stroke();

        if (centerY + radius >= canvas.height || centerY - radius <= 0) {
            stepY *= -1;
        } else if (centerX + radius >= canvas.width || centerX - radius <= 0) {
            stepX *= -1;
        }

        centerX += stepX;
        centerY += stepY;

        requestAnimationFrame(drawCirlce);
    }
}());