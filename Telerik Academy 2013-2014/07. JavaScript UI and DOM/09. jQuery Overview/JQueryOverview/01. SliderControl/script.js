/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\JQueryOverview\SliderControl\jquery.min.js" />
$.fn.slide = function () {
    var $this = this,
        currentSlide = 0,
        autoSlideChanger = setInterval(nextSlide, 5000),
        slides = [
        '<img src="doge.jpg" alt="Doge" />',
        '<article><header><h1>Lorem ipsum</h1></header><p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p></article>',
        '<ul><li><a href="#">Link</a></li><li><a href="#">Link</a></li><li><a href="#">Link</a></li><li><a href="#">Link</a></li><li><a href="#">Link</a></li></ul>',
        '<table><thead><tr><th>First name</th><th>Last name</th><th>Grade</th></tr></thead><tbody><tr><td>Peter</td><td>Ivanov</td><td>3</td></tr><tr><td>Stefan</td><td>Ganchev</td><td>6</td></tr><tr><td>Milena</td><td>Karaivanova</td><td>4</td></tr><tr><td>Boyko</td><td>Borisov</td><td>6</td></tr></tbody></table>'
        ];

    setSlideToCurrent();
    $this.find('#prev-button').on('click', prevSlide);
    $this.find('#next-button').on('click', nextSlide);

    function nextSlide() {
        currentSlide++;

        if (currentSlide === slides.length) {
            currentSlide = 0;
        }

        setSlideToCurrent();
        resetTimer();
    }

    function prevSlide() {
        currentSlide--;

        if (currentSlide < 0) {
            currentSlide = slides.length - 1;
        }

        setSlideToCurrent();
        resetTimer();
    }

    function setSlideToCurrent() {
        $this.find('#current-slide').html(slides[currentSlide]);
    }

    function resetTimer() {
        clearInterval(autoSlideChanger);
        autoSlideChanger = setInterval(nextSlide, 5000);
    }
};