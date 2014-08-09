function makeListView(dataCollection) {
    var templateId = $(this).data('template');
    var template = $('#' + templateId).html();
    var templateCollection = Handlebars.compile(template);
    $(this).html(templateCollection(dataCollection));

    return $(this);
}

var books = {
    books: [
        {
            id: 1,
            title: 'JavaScript: The good parts'
        },
        {
            id: 2,
            title: 'Secrets of the JavaScript Ninja'
        },
        {
            id: 3,
            title: 'Core HTML5 Canvas'
        },
        {
            id: 4,
            title: 'JavaScript Patterns'
        },
    ]
};

var students = {
    students: [
        {
            number: 1,
            name: 'Peter Petrov',
            mark: 5.5
        },
        {
            number: 2,
            name: 'Stamat Georgiev',
            mark: 4.7
        },
        {
            number: 3,
            name: 'Maria Todorova',
            mark: 5
        },
        {
            number: 4,
            name: 'Georgi Geshov',
            mark: 3.7
        }
    ]
};

$(document).ready(function () {
    $.fn.listview = makeListView;
    $('#books-list').listview(books);
    $('#students-table').listview(students);
});
