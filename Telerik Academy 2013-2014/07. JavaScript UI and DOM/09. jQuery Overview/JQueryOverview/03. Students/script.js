/// <reference path="F:\Programs\Microsoft Visual Studio 2013\Projects\JavaScript\JQueryOverview\SliderControl\jquery.min.js" />
$.fn.putStudents = function () {
    var $this = this,
        students = [
            {
                firstName: 'Petar',
                lastName: 'Ivanov',
                grade: 3
            },
            {
                firstName: 'Milena',
                lastName: 'Grigorova',
                grade: 6
            },
            {
                firstName: 'Gergana',
                lastName: 'Borisova',
                grade: 12
            },
            {
                firstName: 'Boyko',
                lastName: 'Petrov',
                grade: 7
            }
        ];

    appendTable();

    function appendTable() {
        var i,
            prop,
            $table = $('<table>'),
            $thead = $('<thead>'),
            $tbody = $('<tbody>'),
            $tr = $('<tr>');

        $this.append($table);
        $this.find($table).append($thead);
        $this.find($thead).append($tr);
        $('<th>').text('First name').appendTo($this.find($tr));
        $('<th>').text('Last name').appendTo($this.find($tr));
        $('<th>').text('Grade').appendTo($this.find($tr));
        $this.find($table).append($tbody);

        for (i = 0; i < students.length; i++) {
            $tr = $('<tr>');
            $this.find($tbody).append($tr);

            for (prop in students[i]) {
                $('<td>').text(students[i][prop]).appendTo($this.find($tr));
            }
        }
    }
};