/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\JQueryOverview\SliderControl\jquery.min.js" />
$.fn.messageBox = function () {
    var $this = $(this);

    var onSuccessButton = $('#on-success-btn').on('click', function () {
        var msgBox = $('#message-box').messageBox();
        msgBox.success('Success message');
    });

    var onErrorButton = $('#on-error-btn').on('click', function () {
        var msgBox = $('#message-box').messageBox();
        msgBox.error('Error message');
    });

    return {
        success: function (message) {
            $this.each(function () {
                $this.css('background-color', 'green');
                $this.animate({ 'opacity': 1 }, 1000);
                $(this).html(message);
                setInterval(function () { $this.animate({ 'opacity': 0 }, 1000); }, 3000);
            });
            return $this;
        },
        error: function (message) {
            $this.each(function () {
                $this.css('background-color', 'red');
                $this.animate({ 'opacity': 1 }, 1000);
                $(this).html(message);
                setInterval(function () { $this.animate({ 'opacity': 0 }, 1000); }, 3000);
            });
            return $this;
        }
    };
};