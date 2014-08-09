window.onload = function () {
    var docFragment = document.createDocumentFragment(),
        textArea = document.createElement('textarea'),
        inputColorFont = document.createElement('input'),
        inputColorBackground = document.createElement('input');

    inputColorFont.type = 'color';
    inputColorBackground.type = 'color';
    inputColorFont.onchange = changeTextFontColor;
    inputColorBackground.onchange = changeBackgroundColor;

    docFragment.appendChild(textArea);
    docFragment.appendChild(inputColorFont);
    docFragment.appendChild(inputColorBackground);

    document.body.appendChild(docFragment);

    function changeTextFontColor() {
        textArea.style.color = inputColorFont.value;
    }

    function changeBackgroundColor() {
        textArea.style.backgroundColor = inputColorBackground.value;
    }
};