window.onload = function () {
    'use strict';
    var svg,
        svgNameSpace,
        text,
        circle,
        line,
        path;

    svgNameSpace = 'http://www.w3.org/2000/svg';
    svg = document.getElementById('the-svg');
    text = createText(20, 135, 'Calibri', 40, 'rgb(62, 63, 55)', 'M');
    svg.appendChild(text);
    circle = createCircle(130, 130, 50, 'rgb(62, 63, 55)');
    svg.appendChild(circle);
    line = createLine(130, 100, 130, 160);
    svg.appendChild(line);
    path = createPath('M 130 100 C 110 115 110 145 130 160', 'none', 'rgb(94, 177, 74)');
    svg.appendChild(path);
    path = createPath('M 130 100 C 150 115 150 145 130 160', 'none', 'rgb(68, 150, 68)');
    svg.appendChild(path);
    text = createText(28, 190, 'Calibri', 40, 'rgb(40, 40, 39)', 'E');
    svg.appendChild(text);
    circle = createCircle(130, 180, 50, 'rgb(40, 40, 39)');
    svg.appendChild(circle);
    text = createText(87, 182, 'sans-serif', 25, 'rgb(253, 253, 252)', 'express');
    svg.appendChild(text);
    text = createText(28, 245, 'Calibri', 40, 'rgb(226, 51, 55)', 'A');
    svg.appendChild(text);
    circle = createCircle(130, 230, 50, 'rgb(226, 51, 55)');
    svg.appendChild(circle);
    path = createPath('M 130 210 L 100 215 L 110 260 L 130 260', 'rgb(179, 179, 179)', 'none');
    svg.appendChild(path);
    path = createPath('M 130 210 L 160 215 L 150 260 L 130 260', 'rgb(179, 179, 179)', 'rgb(182, 48, 50)');
    svg.appendChild(path);
    path = createPath('M 115 255 L 130 215 L 130 230 L 123 255 Z', 'none', 'rgb(241, 239, 239)');
    svg.appendChild(path);
    path = createPath('M 145 255 L 130 215 L 130 230 L 137 255 Z', 'none', 'rgb(179, 179, 179)');
    svg.appendChild(path);
    text = createText(28, 302, 'Calibri', 40, 'rgb(142, 199, 78)', 'N');
    svg.appendChild(text);
    circle = createCircle(130, 290, 50, 'rgb(142, 199, 78)');
    svg.appendChild(circle);
    path = createPath('M 100 290 L 100 300 L 92 310 L 92 288 L 102 280 L 112 288 L 112 310 L 105 300 L 105 290 Z', 'none', 'rgb(71, 73, 63)');
    svg.appendChild(path);
    path = createPath('M 125 310 L 117 300 L 117 288 L 125 280 L 133 288 L 133 300 Z', 'none', 'white');
    svg.appendChild(path);
    path = createPath('M 145 310 L 137 300 L 137 288 L 145 280 L 148 283 L 148 260 L 155 267 155 300 Z', 'none', 'rgb(71, 73, 63)');
    svg.appendChild(path);
    circle = createCircle(145, 295, 4, 'rgb(142, 199, 78)');
    svg.appendChild(circle);
    path = createPath('M 168 310 L 160 300 L 160 288 L 168 280 L 175 288 L 170 293 L 170 290 L 165 290 L 165 298 L 170 305 Z', 'none', 'rgb(71, 73, 63)');
    svg.appendChild(path);
    circle = createCircle(168, 290, 2, 'white');
    svg.appendChild(circle);

    function createText(x, y, fontFamily, fontSize, fill, innerHTML) {
        var text;

        text = document.createElementNS(svgNameSpace, 'text');
        text.setAttribute('x', x);
        text.setAttribute('y', y);
        text.setAttribute('font-family', fontFamily);
        text.setAttribute('font-size', fontSize);
        text.setAttribute('fill', fill);
        text.innerHTML = innerHTML;

        return text;
    }

    function createCircle(cx, cy, r, fill) {
        var circle;

        circle = document.createElementNS(svgNameSpace, 'circle');
        circle.setAttribute('cx', cx);
        circle.setAttribute('cy', cy);
        circle.setAttribute('r', r);
        circle.setAttribute('fill', fill);

        return circle;
    }

    function createLine(x1, y1, x2, y2) {
        var line;

        line = document.createElementNS(svgNameSpace, 'line');
        line.setAttribute('x1', x1);
        line.setAttribute('y1', y1);
        line.setAttribute('x2', x2);
        line.setAttribute('y2', y2);

        return line;
    }

    function createPath(d, stroke, fill) {
        var path;

        path = document.createElementNS(svgNameSpace, 'path');
        path.setAttribute('d', d);
        path.setAttribute('stroke', stroke);
        path.setAttribute('fill', fill);

        return path;
    }
};