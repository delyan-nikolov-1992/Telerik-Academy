window.onload = function () {
    var program = [
        {
            id: 0,
            title: 'Course Introduction',
            firstDate: 'Wed 18:00, 28-May-2014',
            secondDate: 'Thu 14:00, 29-May-2014'
        },
        {
            id: 1,
            title: 'Document Object Model',
            firstDate: 'Wed 18:00, 28-May-2014',
            secondDate: 'Thu 14:00, 29-May-2014'
        },
        {
            id: 2,
            title: 'HTML5 Canvas',
            firstDate: 'Thu 18:00, 29-May-2014',
            secondDate: 'Fri 14:00, 30-May-2014'
        },
        {
            id: 3,
            title: 'Kinetic JS Overview',
            firstDate: 'Thu 18:00, 29-May-2014',
            secondDate: 'Fri 14:00, 30-May-2014'
        },
        {
            id: 4,
            title: 'SVG and RaphaelJS',
            firstDate: 'Wed 18:00, 04-Jun-2014',
            secondDate: 'Thu 14:00, 05-Jun-2014'
        },
        {
            id: 5,
            title: 'Animations with Canvas and SVG',
            firstDate: 'Wed 18:00, 04-Jun-2014',
            secondDate: 'Thu 14:00, 05-Jun-2014'
        },
        {
            id: 6,
            title: 'DOM operations',
            firstDate: 'Thu 18:00, 05-Jun-2014',
            secondDate: 'Fri 14:00, 06-Jun-2014'
        },
        {
            id: 7,
            title: 'Event model',
            firstDate: 'Thu 18:00, 05-Jun-2014',
            secondDate: 'Fri 14:00, 06-Jun-2014'
        },
        {
            id: 8,
            title: 'jQuery overview',
            firstDate: 'Wed 18:00, 11-Jun-2014',
            secondDate: 'Thu 14:00, 12-Jun-2014'
        },
        {
            id: 9,
            title: 'HTML Templates',
            firstDate: 'Wed 18:00, 11-Jun-2014',
            secondDate: 'Thu 14:00, 12-Jun-2014'
        },
        {
            id: 10,
            title: 'Exam preparation',
            firstDate: 'Thu 18:00, 12-Jun-2014',
            secondDate: 'Fri 14:00, 13-Jun-2014'
        },
        {
            id: 11,
            title: 'Exam',
            firstDate: 'Tue 10:00, 17-Jun-2014',
            secondDate: 'Tue 16:30, 17-Jun-2014'
        },
        {
            id: 12,
            title: 'Teamwork Defence',
            firstDate: 'Thu 10:00, 19-Jun-2014',
            secondDate: 'Thu 10:00, 19-Jun-2014'
        },
    ];

    var templateSource = document.getElementById("program-template").innerHTML,
        template = Handlebars.compile(templateSource),
        coursesHtml = template({ program: program }),
        container = document.getElementById("program-container");

    container.innerHTML = coursesHtml;
};