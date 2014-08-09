/// <reference path='jquery-2.0.2.js' />

window.onload = function () {
    'use strict';

    var $errorMessage,
        $successMessage,
        addStudent,
        reloadStudents,
        deleteStudent,
        resourceUrl;

    resourceUrl = 'http://localhost:3000/students';
    $successMessage = $('.messages .success');
    $errorMessage = $('.messages .error');

    addStudent = function (data) {
        return $.ajax({
            url: resourceUrl,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                $successMessage.html('' + data.name + ' successfully added')
                               .show()
                               .fadeOut(2000);
            },
            error: function (err) {
                $errorMessage.html('Error happened: ' + err)
                             .show()
                             .fadeOut(2000);
            }
        });
    };

    reloadStudents = function () {
        return $.ajax({
            url: resourceUrl,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                var student,
                    $studentsList,
                    i,
                    len;

                $studentsList = $('<ul/>').addClass('students-list');

                for (i = 0, len = data.students.length; i < len; i++) {
                    student = data.students[i];

                    $('<li />').addClass('student-item')
                               .append($('<strong /> ')
                               .html(student.id))
                               .append($('<strong /> ')
                               .html(student.name))
                               .append($('<span />')
                               .html(student.grade))
                               .appendTo($studentsList);
                }

                $('#students-container').html($studentsList);
            },
            error: function (err) {
                $errorMessage.html('Error happened: ' + err)
                             .show()
                             .fadeOut(2000);
            }
        });
    };

    deleteStudent = function (data) {
        return $.ajax({
            url: resourceUrl + '/' + data.id,
            type: 'POST',
            data: { _method: 'delete' },
            success: function () {
                $successMessage.html('Student successfully deleted')
                               .show()
                               .fadeOut(2000);
            },
            error: function (err) {
                $errorMessage.html('Error happened: ' + err)
                             .show()
                             .fadeOut(2000);
            }
        });
    };

    $(function () {
        $('#btn-add-student').on('click', function () {
            var student;

            student = {
                name: $('#tb-name').val(),
                grade: $('#tb-grade').val()
            };

            addStudent(student);
        });

        $('#btn-list-students').on('click', function () {
            reloadStudents();
        });

        $('#btn-delete-student').on('click', function () {
            var student;

            student = {
                id: $('#tb-id').val()
            };

            deleteStudent(student);
        });
    });
};