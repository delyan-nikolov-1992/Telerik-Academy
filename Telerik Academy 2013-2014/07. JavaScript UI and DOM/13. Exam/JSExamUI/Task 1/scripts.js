function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector),
        galleryList = document.createElement('div'),
        newLine = document.createElement('br'),
        selected = document.createElement('div'),
        imageBox = document.createElement('div'),
        imageBoxTitle = document.createElement('strong'),
        imageBoxContent = document.createElement('img'),
        filterBox = document.createElement('div'),
        filterBoxTitle = document.createElement('strong'),
        filterBoxContent = document.createElement('input'),
        boxes,
        selectedBox = null;

    imageBox.appendChild(imageBoxTitle);
    imageBox.appendChild(imageBoxContent);
    filterBox.appendChild(filterBoxTitle);
    filterBox.appendChild(newLine);
    filterBox.appendChild(filterBoxContent);

    // begin style
    filterBoxTitle.style.fontWeight = 'normal';
    filterBox.style.textAlign = 'center';

    galleryList.style.position = 'absolute';
    galleryList.style.top = '0';
    galleryList.style.right = '0';

    imageBox.style.width = '130px';
    imageBox.style.padding = '10px';
    imageBox.style.textAlign = 'center';

    imageBoxContent.style.width = '130px';
    imageBoxContent.style.borderRadius = '10px';

    selected.style.zoom = '4';
    // end style

    galleryList.className = 'gallery-list';
    selected.className = 'selected';
    imageBoxTitle.className = 'image-title';
    imageBoxContent.className = 'image-content';
    filterBoxTitle.className = 'filter-title';
    filterBoxContent.className = 'filter-content';

    boxes = createImageBoxes();
    appendToDOM();
    
    function onBoxMouseover(ev) {
        if (selectedBox !== this) {
            this.style.background = 'rgb(212, 202, 200)';
        }
    }

    function onBoxMouseout(ev) {
        if (selectedBox !== this) {
            this.style.background = '';
        }

    }

    function onBoxClick(ev) {
        var content;

        // no box is selected
        if (selectedBox !== null && selectedBox !== this) {
            selectedBox.style.background = '';
        }

        // this box is the selected box
        if (selectedBox !== this) {
            this.style.background = 'rgb(212, 202, 200)';
            selectedBox = this;

            selected.innerText = '';

            selected.appendChild(this.cloneNode(true));
            content = selected.querySelector('div');
            content.style.backgroundColor = '';
        }
    }

    function createImageBoxes() {
        var imageBoxes = [],
            i,
            len = items.length;

        for (i = 0; i < len; i++) {
            imageBoxTitle.innerText = items[i].title;
            imageBoxContent.src = items[i].url;
            imageBoxes.push(imageBox.cloneNode(true));

            if (i === 0) {
                selected.appendChild(imageBox.cloneNode(true));
            }
        }

        return imageBoxes;
    }

    function onKeyUp(ev) {
        var valThis = this.querySelector('input').value.toLowerCase();
        var children = galleryList.children;

        for (var i = 1; i < children.length; i++) {
            var text = children[i].querySelector('strong').innerText.toLowerCase();
            (text.indexOf(valThis) == 0) ? children[i].style.display = 'block' : children[i].style.display = 'none';
        }
    }

    //$('#s').keyup(function () {
    //    var valThis = $(this).val().toLowerCase();
    //    $('.countryList>li').each(function () {
    //        var text = $(this).text().toLowerCase();
    //        (text.indexOf(valThis) == 0) ? $(this).show() : $(this).hide();
    //    });
    //});

    function appendToDOM() {
        var docFragment = document.createDocumentFragment(),
            i,
            len = boxes.length;

        filterBoxTitle.innerText = 'Filter';
        boxes.unshift(filterBox.cloneNode(true));
        boxes[0].addEventListener('keyup', onKeyUp);
        galleryList.appendChild(boxes[0]);

        for (i = 1; i < len; i++) {
            boxes[i].addEventListener('click', onBoxClick);
            boxes[i].addEventListener('mouseover', onBoxMouseover);
            boxes[i].addEventListener('mouseout', onBoxMouseout);
            galleryList.appendChild(boxes[i]);
        }

        docFragment.appendChild(selected);
        docFragment.appendChild(galleryList);

        container.appendChild(docFragment);
    }
}