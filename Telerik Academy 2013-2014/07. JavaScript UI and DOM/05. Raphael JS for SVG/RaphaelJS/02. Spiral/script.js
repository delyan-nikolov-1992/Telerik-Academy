window.onload = function () {
    var paperS = Raphael(0, 0, 400, 300);

    drawSpiral(250, 150, 0, 2);

    function drawSpiral(centerX, centerY, a, b) {
        var centralPoint = "M" + centerX + ' ' + centerY,
            spiralPoints = [centralPoint],
            spiral,
            spiralPointsStr,
            angle,
            x,
            y,
            i;

        for (i = 0; i < 700; i++) {
            angle = 0.1 * i;
            x = centerX + (a + b * angle) * Math.cos(angle);
            y = centerY + (a + b * angle) * Math.sin(angle);

            spiralPoints.push('L ' + x + ' ' + y);
        }

        spiralPointsStr = spiralPoints.join(' ');
        spiral = paperS.path(spiralPointsStr);
    }
};