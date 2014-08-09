/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\JQueryOverview\SliderControl\jquery.min.js" />
$.fn.dropdown = function () {
    var $this = $(this);
    $this.hide();

    var $generatedDropdown = $('<div></div>').addClass('dropdown-list-container');
    var $generatedList = $('<ul></ul>').addClass('dropdown-list-options');
    var $options = $this.find('option');

    for (var i = 0; i < $options.length; i++) {
        var $currentOption = $options[i];
        var currentOptionValue = $currentOption.value;
        var currentOptionText = $currentOption.innerHTML;
        var $generatedListItem = $('<li></li>')
                            .addClass('dropdown-list-option')
                            .html(currentOptionText)
                            .data('data-value', currentOptionValue);
        $generatedList.append($generatedListItem);
    }

    $generatedDropdown.append($generatedList);

    $this.after($generatedDropdown);

    var generatedLiElements = $generatedDropdown.find('.dropdown-list-option');

    $(".dropdown-list-option").on("click", function () {
        var data = $(this).data('data-value');
        var selector = 'option[value=\'' + data + '\']';

        if ($('#dropdown').find(selector).attr('selected') == 'selected') {
            $('#dropdown').find(selector).removeAttr('selected', '');
            $(this).css('background-color', '');
        } else {
            $('#dropdown').find(selector).attr('selected', 'selected');
            $(this).css('background-color', 'red');
        }
    });

    return $this;
};