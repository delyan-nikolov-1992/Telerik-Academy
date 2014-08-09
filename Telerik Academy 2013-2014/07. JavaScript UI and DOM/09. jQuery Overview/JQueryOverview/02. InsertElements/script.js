/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\JQueryOverview\SliderControl\jquery.min.js" />
$.fn.putElements = function () {
    var $this = this,
        $prependedElement = $('<div>').text('The prepended div'),
        $appendedElement = $('<div>').text('The appended div'),
        $currentElement = $this.find('#current');

    $($prependedElement).prependTo($currentElement);
    $($appendedElement).appendTo($currentElement);
};