/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\ExamJSUIAndDOM\02. JQuery\jquery.min.js" />

$.fn.gallery = function (cols) {
    var $this = this,
        $parentNode = $this;

    $this.addClass('gallery');
    $parentNode.find('.gallery-list').addClass('clearfix');
    setWidth();
    $this.find('.selected').hide();

    $this.find('.image-container').on('click', onClickGalleyImage);
    $this.find('.current-image').on('click', onClickCurrentImage);
    $this.find('.previous-image').on('click', onClickPreviousImage);
    $this.find('.next-image').on('click', onClickNextImage);

    function setWidth() {
        var width,
            imageWidth,
            imageMarginLeft,
            imageMarginRight,
            imageContainer;

        if (!cols) {
            cols = 4;
        }

        imageContainer = $this.find('.image-container');
        imageMarginRight = imageContainer.css("marginRight");
        imageMarginLeft = imageContainer.css("marginLeft");
        imageWidth = imageContainer.width() + parseInt(imageMarginRight) + parseInt(imageMarginLeft);
        width = (cols * imageWidth);
        $this.width(width);
    }

    function onClickGalleyImage() {
        var $this = $(this),
            currentSrc,
            prevSrc,
            nextSrc;

        if (!$parentNode.find('.selected').is(':visible')) {
            currentSrc = $this.find('img').attr('src');

            if ($this.is(':first-of-type')) {
                prevSrc = $this.parent().find($this.selector + ':last-of-type').find('img').attr('src');
            } else {
                prevSrc = $this.prev().find('img').attr('src');
            }

            if ($this.is(':last-of-type')) {
                nextSrc = $this.parent().find($this.selector + ':first-of-type').find('img').attr('src');
            } else {
                nextSrc = $this.next().find('img').attr('src');
            }

            $parentNode.find('.selected .current-image img').attr('src', currentSrc);
            $parentNode.find('.selected .previous-image img').attr('src', prevSrc);
            $parentNode.find('.selected .next-image img').attr('src', nextSrc);
            $parentNode.find('.selected').show();
            $parentNode.find('.gallery-list').addClass('blurred disabled-background');
        }
    }

    function onClickCurrentImage() {
        var $this = $(this);

        $this.parent().hide();
        $parentNode.find('.gallery-list').removeClass('blurred disabled-background');
    }

    function onClickPreviousImage() {
        var $this = $(this),
            currentSrc,
            prevSrc,
            nextSrc,
            firstSrc,
            lastSrc,
            galleryList,
            len,
            i,
            searchedSrc,
            searchedPrevSrc;

        nextSrc = $this.parent().find('.current-image img').attr('src');
        currentSrc = $this.find('img').attr('src');
        firstSrc = $parentNode.find('.gallery-list .image-container:first-of-type img').attr('src');
        lastSrc = $parentNode.find('.gallery-list .image-container:last-of-type img').attr('src');

        if (currentSrc === firstSrc) {
            prevSrc = lastSrc;
        } else {
            galleryList = $($parentNode.find('.gallery-list'));
            len = galleryList.children().length;
            searchedPrevSrc = galleryList.find('.image-container:eq(0) img').attr('src');

            for (i = 0; i < len; i++) {
                searchedSrc = galleryList.find('.image-container:eq(' + i + ') img').attr('src');

                if (currentSrc === searchedSrc) {
                    prevSrc = searchedPrevSrc;
                    break;
                }

                searchedPrevSrc = searchedSrc;
            }
        }

        $this.parent().find('.current-image img').attr('src', currentSrc);
        $this.parent().find('.next-image img').attr('src', nextSrc);
        $this.parent().find('.previous-image img').attr('src', prevSrc);
    }

    function onClickNextImage() {
        var $this = $(this),
            currentSrc,
            prevSrc,
            nextSrc,
            firstSrc,
            lastSrc,
            galleryList,
            len,
            i,
            searchedSrc,
            searchedNextSrc;

        prevSrc = $this.parent().find('.current-image img').attr('src');
        currentSrc = $this.find('img').attr('src');
        firstSrc = $parentNode.find('.gallery-list .image-container:first-of-type img').attr('src');
        lastSrc = $parentNode.find('.gallery-list .image-container:last-of-type img').attr('src');

        if (currentSrc === lastSrc) {
            nextSrc = firstSrc;
        } else {
            galleryList = $($parentNode.find('.gallery-list'));
            len = galleryList.children().length;
            searchedNextSrc = galleryList.find('.image-container:eq(' + (len - 1) + ') img').attr('src');

            for (i = len - 1; i >= 0; i--) {
                searchedSrc = galleryList.find('.image-container:eq(' + i + ') img').attr('src');

                if (currentSrc === searchedSrc) {
                    nextSrc = searchedNextSrc;
                    break;
                }

                searchedNextSrc = searchedSrc;
            }
        }

        $this.parent().find('.current-image img').attr('src', currentSrc);
        $this.parent().find('.previous-image img').attr('src', prevSrc);
        $this.parent().find('.next-image img').attr('src', nextSrc);
    }
};