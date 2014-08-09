/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\JQueryOverview\SliderControl\jquery.min.js" />
$.fn.changeColor = function () {
    var $this = this;

    $this.find('#background-btn').on('click', onButtonClick);

    function onButtonClick() {
        var $input = $this.parent().find('#background-color');

        $this.parent().css('background-color', $input.val());
    }
};