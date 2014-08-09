window.onload = function () {
    'use strict';
    var svg,
        svgNameSpace,
        text,
        path,
        rect,
        image;

    svgNameSpace = 'http://www.w3.org/2000/svg';
    svg = document.getElementById('the-svg');
    rect = createRect('-0.141', '0.216', '1058.177', '662.482', '#06173F');
    svg.appendChild(rect);
    image = createImage('500', '242', 'imgs/fish.jpg', 'matrix(0.407 0 0 0.407 101.0005 470.4084)');
    svg.appendChild(image);
    rect = createRect('101', '153.74', '98.5', '98.502', '#2D89EE');
    svg.appendChild(rect);
    rect = createRect('206.25', '153.74', '98.5', '98.502', '#5BA51A');
    svg.appendChild(rect);
    rect = createRect('311.916', '153.74', '204.251', '98.502', '#AB1A3B');
    svg.appendChild(rect);
    rect = createRect('523.041', '153.74', '204.25', '98.502', '#008B18');
    svg.appendChild(rect);
    rect = createRect('101', '259.742', '98.5', '98.5', '#54429A');
    svg.appendChild(rect);
    rect = createRect('206.25', '259.742', '98.5', '98.5', '#2574EB');
    svg.appendChild(rect);
    rect = createRect('311.916', '259.742', '204.251', '98.5', '#54429A');
    svg.appendChild(rect);
    rect = createRect('523.041', '259.742', '204.25', '98.5', '#D14828');
    svg.appendChild(rect);
    rect = createRect('774.374', '153.74', '204.252', '98.502', '#54429A');
    svg.appendChild(rect);
    rect = createRect('774.374', '259.742', '204.252', '98.5', '#008B18');
    svg.appendChild(rect);
    rect = createRect('101', '365.073', '203.75', '98.5', '#D14828');
    svg.appendChild(rect);
    rect = createRect('311.916', '365.073', '204.251', '98.5', '#008B18');
    svg.appendChild(rect);
    rect = createRect('628.5', '365.073', '98.791', '98.5', '#2D89EE');
    svg.appendChild(rect);
    rect = createRect('879.834', '365.073', '98.791', '98.5', '#012A6B');
    svg.appendChild(rect);
    rect = createRect('774.374', '365.073', '98.791', '98.5', '#D14828');
    svg.appendChild(rect);
    rect = createRect('985.54', '153.74', '72.328', '98.502', '#FFFFFF');
    svg.appendChild(rect);
    rect = createRect('985.54', '259.74', '72.328', '98.502', '#0071B3');
    svg.appendChild(rect);
    rect = createRect('985.54', '365.073', '72.328', '98.5', '#2D89EE');
    svg.appendChild(rect);
    rect = createRect('628.5', '470.406', '98.791', '98.5', '#5BA51A');
    svg.appendChild(rect);
    rect = createRect('523.041', '470.406', '98.792', '98.5', '#AB1A3B');
    svg.appendChild(rect);
    rect = createRect('311.916', '470.406', '204.251', '98.5', '#2D89EE');
    svg.appendChild(rect);
    text = createText('matrix(1 0 0 1 114.6694 244.011)', "'Arial'", '9.5177', '#FFFFFF', 'Store');
    svg.appendChild(text);
    path = createPath('M99.968,79.593c2.008,1.369,4.655,2.282,7.622,2.282c4.975,0,7.987-2.647,7.987-6.438 c0-3.514-1.78-5.521-6.937-7.165c-6.162-1.962-8.626-4.473-8.626-8.486c0-4.521,3.879-7.896,9.539-7.896 c3.24,0,5.659,0.776,6.846,1.552l-0.867,1.872c-0.867-0.593-3.058-1.598-6.07-1.598c-5.522,0-7.257,3.332-7.257,5.75 c0,3.286,1.963,5.157,6.938,6.755c5.613,1.825,8.625,4.017,8.625,8.991c0,4.245-3.104,8.535-10.451,8.535 c-2.921,0-6.344-0.913-8.215-2.282L99.968,79.593z', 'none', '#FFFFFF');
    svg.appendChild(path);
    path = createPath('M127.216,56.454v4.838h6.937v1.778h-6.937v14.013c0,2.69,0.821,4.747,3.514,4.747 c1.323,0,2.236-0.186,2.875-0.411l0.274,1.732c-0.776,0.318-1.917,0.595-3.377,0.595c-1.734,0-3.149-0.55-4.062-1.646 c-1.096-1.229-1.46-3.24-1.46-5.294V63.072h-4.017v-1.778h4.017V57.14L127.216,56.454z', 'none', '#FFFFFF');
    svg.appendChild(path);
    path = createPath('M154.509,77.905c0,1.779,0.091,3.516,0.365,5.294h-2.054l-0.365-3.377h-0.091 c-1.141,1.688-3.925,3.927-7.941,3.927c-4.975,0-6.982-3.377-6.982-6.024c0-4.975,4.609-8.215,14.833-8.078v-0.502 c0-1.643-0.365-6.571-6.207-6.523c-2.19,0-4.473,0.547-6.298,1.822l-0.73-1.597c2.419-1.597,5.112-2.1,7.211-2.1 c7.439,0,8.261,5.75,8.261,9.219v7.939H154.509z M152.273,71.514c-5.796-0.183-12.459,0.73-12.459,5.796 c0,3.104,2.236,4.609,4.792,4.609c4.245,0,6.526-2.512,7.394-4.475c0.183-0.457,0.274-0.913,0.274-1.276L152.273,71.514 L152.273,71.514z', 'none', '#FFFFFF');
    svg.appendChild(path);
    path = createPath('M162.178,68.365c0-2.374-0.045-4.699-0.183-7.072h2.054l0.091,4.747h0.137 c1.095-3.061,3.468-5.294,6.709-5.294c0.365,0,0.73,0.046,1.05,0.137v2.054c-0.411-0.091-0.776-0.091-1.278-0.091 c-3.058,0-5.385,2.556-6.115,6.344c-0.137,0.642-0.229,1.415-0.229,2.146v11.863h-2.236V68.365z', 'none', '#FFFFFF');
    svg.appendChild(path);
    path = createPath('M181.073,56.454v4.838h6.937v1.778h-6.937v14.013c0,2.69,0.821,4.747,3.514,4.747 c1.323,0,2.236-0.186,2.875-0.411l0.274,1.732c-0.776,0.318-1.917,0.595-3.377,0.595c-1.734,0-3.149-0.55-4.062-1.646 c-1.096-1.229-1.46-3.24-1.46-5.294V63.072h-4.017v-1.778h4.017V57.14L181.073,56.454z', 'none', '#FFFFFF');
    svg.appendChild(path);
    text = createText('matrix(1 0 0 1 218.3369 244.011)', "'Arial'", '9.5177', '#FFFFFF', 'XBox Live Games');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 114.6694 349.343)', "'Arial'", '9.5177', '#FFFFFF', 'Maps');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 114.6694 454.843)', "'Arial'", '9.5177', '#FFFFFF', 'Video');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 789.6704 244.011)', "'Arial'", '9.5177', '#FFFFFF', 'Music');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 789.6704 349.343)', "'Arial'", '9.5177', '#FFFFFF', 'Finance');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 997.6704 454.843)', "'Arial'", '9.5177', '#FFFFFF', 'SkyDrive');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 114.6694 558.843)', "'Arial'", '9.5177', '#FFFFFF', 'Desktop');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 324.8379 558.843)', "'Arial'", '9.5177', '#FFFFFF', 'Weather');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 218.3369 349.343)', "'Arial'", '9.5177', '#FFFFFF', 'Internet Explorer');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 324.8369 244.011)', "'Arial'", '9.5177', '#FFFFFF', 'Photos');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 536.1704 244.011)', "'Arial'", '9.5177', '#FFFFFF', 'Calendar');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 536.1704 558.843)', "'Arial'", '9.5177', '#FFFFFF', 'Camera');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 639.8364 558.843)', "'Arial'", '9.5177', '#FFFFFF', 'XBox Companion');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 639.8364 454.843)', "'Arial'", '9.5177', '#FFFFFF', 'Solitaire');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 324.8369 349.343)', "'Arial'", '9.5177', '#FFFFFF', 'Messaging');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 905.7075 67.0754)', "'Arial'", '21.4952', '#FFFFFF', 'Richard');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 951.7329 84.0979)', "'Arial'", '11.5791', '#FFFFFF', 'Perry');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 501.5957 456.1575)', "'Arial'", '13.6981', '#FFFFFF', '3');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 655.7563 202.9915)', "'Arial'", '55.7238', '#FFFFFF', '12');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 660.8462 214.4124)', "'Arial'", '8.8309', '#FFFFFF', 'monday');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 324.8369 390.1184)', "'Arial'", '19.3451', '#FFFFFF', 'Devon Hypnotize');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 324.8369 402.7805)', "'Arial'", '10.5519', '#FFFFFF', 'something they can do about him');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 324.8369 415.4426)', "'Arial'", '10.5519', '#FFFFFF', 'pile of books and scrollnext to');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 586.2642 285.9631)', "'Arial'", '11.6384', '#FFFFFF', 'Mike Gibbs, Troll Scout ');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 586.2642 299.929)', "'Arial'", '11.6384', '#FFFFFF', 'and 5 others commented ');
    svg.appendChild(text);
    text = createText('matrix(1 0 0 1 586.2642 313.8967)', "'Arial'", '11.6384', '#FFFFFF', 'on your photo.');
    svg.appendChild(text);
    image = createImage("256", "256", "imgs/pinball.jpg", "matrix(0.3848 0 0 0.3848 523.042 365.0764)");
    svg.appendChild(image);
    image = createImage("600", "300", "imgs/wordpress.jpg", "matrix(0.3404 0 0 0.3283 774.3735 470.4084)");
    svg.appendChild(image);
    image = createImage("226", "300", "imgs/sketchbook-logo.jpg", "matrix(0.32 0 0 0.3283 985.5396 153.7415)");
    svg.appendChild(image);
    image = createImage("80", "80", "imgs/profile-photo.jpg", "matrix(0.4185 0 0 0.4185 987.4351 50.616)");
    svg.appendChild(image);
    image = createImage("85", "78", "imgs/1.jpg", "matrix(0.6415 0 0 0.6415 123.4897 178.4973)");
    svg.appendChild(image);
    image = createImage("86", "85", "imgs/3.jpg", "matrix(0.6684 0 0 0.6684 387.0054 174.5842)");
    svg.appendChild(image);
    image = createImage("102", "106", "imgs/4.jpg", "matrix(0.6645 0 0 0.6645 844.7671 171.5247)");
    svg.appendChild(image);
    image = createImage("94", "82", "imgs/5.jpg", "matrix(0.6856 0 0 0.6856 118.6572 279.8494)");
    svg.appendChild(image);
    image = createImage("96", "84", "imgs/6.jpg", "matrix(0.6349 0 0 0.6349 223.6074 281.2922)");
    svg.appendChild(image);
    image = createImage("107", "89", "imgs/7.jpg", "matrix(0.6332 0 0 0.6332 381.6831 282.199)");
    svg.appendChild(image);
    image = createImage("84", "82", "imgs/8.jpg", "matrix(0.8069 0 0 0.8069 844.7671 277.2937)");
    svg.appendChild(image);
    image = createImage("119", "83", "imgs/9.jpg", "matrix(0.6369 0 0 0.6369 164.9819 389.6536)");
    svg.appendChild(image);
    image = createImage("104", "89", "imgs/10.jpg", "matrix(0.6819 0 0 0.6819 642.5151 383.6848)");
    svg.appendChild(image);
    image = createImage("86", "93", "imgs/11.jpg", "matrix(0.7889 0 0 0.7889 792.2583 375.9202)");
    svg.appendChild(image);
    text = createText('matrix(1 0 0 1 789.6704 454.843)', "'Arial'", '9.5177', '#FFFFFF', 'Reader');
    svg.appendChild(text);
    image = createImage("97", "92", "imgs/12.jpg", "matrix(0.7919 0 0 0.7919 893.1206 379.0149)");
    svg.appendChild(image);
    image = createImage("74", "66", "imgs/13.jpg", "matrix(0.7288 0 0 0.7288 1003.9351 390.2708)");
    svg.appendChild(image);
    image = createImage("97", "96", "imgs/14.jpg", "matrix(0.6717 0 0 0.6717 379.9487 487.4172)");
    svg.appendChild(image);
    image = createImage("99", "82", "imgs/15.jpg", "matrix(0.6315 0 0 0.6315 541.1763 489.7786)");
    svg.appendChild(image);
    image = createImage("113", "93", "imgs/2.jpg", "matrix(0.6823 0 0 0.6823 218.3369 167.9485)");
    svg.appendChild(image);
    image = createImage("92", "85", "imgs/16.jpg", "matrix(0.6953 0 0 0.6953 645.9888 482.2913)");
    svg.appendChild(image);

    function createText(transform, fontFamily, fontSize, fill, innerHTML) {
        var text;

        text = document.createElementNS(svgNameSpace, 'text');
        text.setAttribute('transform', transform);
        text.setAttribute('font-family', fontFamily);
        text.setAttribute('font-size', fontSize);
        text.setAttribute('fill', fill);
        text.innerHTML = innerHTML;

        return text;
    }

    function createPath(d, stroke, fill) {
        var path;

        path = document.createElementNS(svgNameSpace, 'path');
        path.setAttribute('d', d);
        path.setAttribute('stroke', stroke);
        path.setAttribute('fill', fill);

        return path;
    }

    function createRect(x, y, width, height, fill) {
        var rect;

        rect = document.createElementNS(svgNameSpace, 'rect');
        rect.setAttribute('x', x);
        rect.setAttribute('y', y);
        rect.setAttribute('width', width);
        rect.setAttribute('height', height);
        rect.setAttribute('fill', fill);

        return rect;
    }

    function createImage(width, height, href, transform) {
        var image;

        image = document.createElementNS(svgNameSpace, 'image');
        image.setAttributeNS(null, 'width', width);
        image.setAttributeNS(null, 'height', height);
        image.setAttributeNS('http://www.w3.org/1999/xlink', 'href', href);
        image.setAttributeNS(null, 'transform', transform);

        return image;
    }
};