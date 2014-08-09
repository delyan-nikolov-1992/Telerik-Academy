(function () {
    var canvas = document.getElementById("the-canvas"),
		context = canvas.getContext("2d");

    context.lineWidth = 2;

    drawHead();
    drawBicycle();
    drawHouse();

    function drawHead() {
        var radius = 100,
            lineLength = 100,
            scaleX = 5,
            centerX = 210,
            centerY = 288;

        context.beginPath();
        context.arc(centerX, centerY, radius, 15 / 9 * Math.PI + 0.1, Math.PI * 4 / 3 - 0.1, false);

        var currentX = centerX - 15;
        var currentY = centerY + 25;

        context.lineJoin = "bevel";
        context.moveTo(currentX, currentY);
        context.lineTo(currentX - 25, currentY);
        context.lineTo(currentX, currentY - 40);

        currentY += 40;
        scaleX = 3;
        radius = 15;

        context.save();
        context.rotate(Math.PI / 10);
        context.scale(scaleX, 1);
        context.moveTo(currentX / scaleX + 30 + radius, currentY / radius + 250);
        context.arc(currentX / scaleX + 30, currentY / radius + 250, radius, 0, 2 * Math.PI, false);
        context.restore();

        currentY -= 80;
        currentX -= 50;
        radius = 14;
        scaleX = 1.5;

        context.save();
        context.scale(scaleX, 1);
        context.moveTo(currentX / scaleX + radius, currentY);
        context.arc(currentX / scaleX, currentY, radius, 0, 2 * Math.PI, false);

        currentX += 90;
        context.moveTo(currentX / scaleX + radius, currentY);
        context.arc(currentX / scaleX, currentY, radius, 0, 2 * Math.PI, false);

        context.restore();

        context.fillStyle = 'rgb(144, 202, 215)';
        context.fill();
        context.strokeStyle = 'rgb(27, 76, 87)';
        context.stroke();

        context.beginPath();

        var scaleY = 2;
        radius = 6;

        context.save();
        context.moveTo(currentX, currentY);
        context.scale(1, scaleY);
        context.arc(currentX - radius, currentY / scaleY, radius, 0, 2 * Math.PI, false);
        currentX -= 90;
        context.moveTo(currentX, currentY / scaleY);
        context.arc(currentX - radius, currentY / scaleY, radius, 0, 2 * Math.PI, false);
        context.restore();

        context.fillStyle = 'rgb(34, 84, 95)';
        context.fill();
        context.stroke();

        centerX = 70;
        centerY = 70;
        radius = 18;
        lineLength = 100;
        scaleX = 3;
        context.save();
        context.scale(scaleX, 1);
        context.beginPath();
        context.arc(centerX, centerY, radius, 0, 2 * Math.PI, false);
        context.restore();

        context.lineTo(centerX * scaleX + radius * scaleX, centerY + lineLength);
        context.bezierCurveTo(centerX * scaleX + radius * 2, centerY + lineLength + radius, centerX * scaleX - radius * 2,
                 centerY + lineLength + radius, (centerX - radius) * scaleX, centerY + lineLength);
        context.lineTo((centerX - radius) * scaleX, centerY);

        context.moveTo(centerX * scaleX + radius * scaleX, centerY + lineLength);
        centerX = centerX * scaleX;
        centerY = centerY + lineLength + radius;
        radius = 22;
        scaleX = 5;
        centerX = centerX / scaleX;

        context.save();
        context.scale(scaleX, 1);
        context.arc(centerX, centerY, radius, 15 / 9 * Math.PI, Math.PI * 4 / 3, false);
        context.restore();

        context.fillStyle = 'rgb(57, 102, 147)';
        context.fill();
        context.stroke();
    }

    function drawBicycle() {
        var radius = 50,
            centerX = 500,
            centerY = 300,
            dX = 225;

        context.beginPath();
        context.arc(centerX, centerY, radius, 0, 2 * Math.PI);
        context.moveTo(centerX + dX + radius, centerY);
        context.arc(centerX + dX, centerY, radius, 0, 2 * Math.PI);
        context.fillStyle = 'rgb(144, 202, 215)';
        context.fill();

        context.moveTo(centerX, centerY);
        context.lineTo(550, 220);
        context.lineTo(540, 195);
        context.lineTo(510, 195);
        context.lineTo(570, 195);
        context.moveTo(550, 220);
        context.lineTo(590, 300);
        context.moveTo(605, 300);
        context.arc(590, 300, 15, 0, 2 * Math.PI);

        context.moveTo(600, 310);
        context.lineTo(610, 320);
        context.moveTo(580, 290);
        context.lineTo(570, 280);

        context.moveTo(centerX, centerY);
        context.lineTo(590, 300);

        context.lineTo(680, 220);
        context.lineTo(550, 220);
        context.moveTo(680, 220);
        context.lineTo(centerX + dX, centerY);
        context.lineTo(centerX + dX - 67, centerY - 120);
        context.lineTo(centerX + dX - 100, centerY - 100);
        context.moveTo(centerX + dX - 67, centerY - 120);
        context.lineTo(centerX + dX - 50, centerY - 150);

        context.strokeStyle = 'rgb(52, 128, 146)';
        context.stroke();
    }

    function drawHouse() {
        // begin base
        context.beginPath();
        context.strokeStyle = 'black';
        context.fillStyle = 'rgb(151, 91, 91)';
        context.fillRect(900, 200, 300, 200);
        context.strokeRect(900, 200, 300, 200);
        // end base

        // begin door
        context.moveTo(930, 400);
        context.lineTo(930, 330);
        context.bezierCurveTo(945, 300, 985, 300, 1000, 330);
        context.lineTo(1000, 400);
        context.moveTo(965, 400);
        context.lineTo(965, 307);
        context.moveTo(960, 380);
        context.arc(955, 380, 5, 0, 2 * Math.PI);
        context.moveTo(980, 380);
        context.arc(975, 380, 5, 0, 2 * Math.PI);
        context.stroke();
        // end door

        // start roof
        context.beginPath();
        context.moveTo(900, 200);
        context.lineTo(1050, 50);
        context.lineTo(1200, 200);
        context.closePath();
        context.fill();
        context.stroke();
        // end roof

        // start chimney
        context.beginPath();
        context.save();
        context.scale(3, 1);
        context.moveTo(385, 100);
        context.arc(380, 100, 5, 0, 2 * Math.PI);
        context.restore();
        context.lineTo(385 * 3, 170);
        context.lineTo(385 * 3 - 30, 170);
        context.lineTo(385 * 3 - 30, 100);
        context.fill();
        context.stroke();
        // end chimney

        // start deleting end of chimney
        context.beginPath();
        context.strokeStyle = 'rgb(151, 91, 91)';
        context.moveTo(385 * 3, 170);
        context.lineTo(385 * 3 - 30, 170);
        context.stroke();
        // end deleting end of chimney

        // windows stroke and fill styles
        context.strokeStyle = 'rgb(94, 56, 56)';
        context.fillStyle = 'black';

        // begin top left four windows
        context.fillRect(920, 220, 50, 30);
        context.strokeRect(920, 220, 50, 30);
        context.fillRect(975, 220, 50, 30);
        context.strokeRect(975, 220, 50, 30);

        context.fillRect(920, 255, 50, 30);
        context.strokeRect(920, 255, 50, 30);
        context.fillRect(975, 255, 50, 30);
        context.strokeRect(975, 255, 50, 30);
        // end top left four windows

        // begin top right four windows
        context.fillRect(1070, 220, 50, 30);
        context.strokeRect(1070, 220, 50, 30);
        context.fillRect(1125, 220, 50, 30);
        context.strokeRect(1125, 220, 50, 30);

        context.fillRect(1070, 255, 50, 30);
        context.strokeRect(1070, 255, 50, 30);
        context.fillRect(1125, 255, 50, 30);
        context.strokeRect(1125, 255, 50, 30);
        // end top right four windows

        // begin bottom right four windows
        context.fillRect(1070, 310, 50, 30);
        context.strokeRect(1070, 310, 50, 30);
        context.fillRect(1125, 310, 50, 30);
        context.strokeRect(1125, 310, 50, 30);

        context.fillRect(1070, 345, 50, 30);
        context.strokeRect(1070, 345, 50, 30);
        context.fillRect(1125, 345, 50, 30);
        context.strokeRect(1125, 345, 50, 30);
        // end top bottom four windows
    }
}());