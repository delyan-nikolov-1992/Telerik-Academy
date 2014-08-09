/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var students,
		studentWithHighestMarks;

    students = [
	{
	    firstName: 'Georgi',
	    lastName: 'Bratoev',
	    age: 26,
	    marks: [2, 2, 3]
	},
	{
	    firstName: 'Todor',
	    lastName: 'Skrimov',
	    age: 24,
	    marks: [5, 5, 6]
	},
	{
	    firstName: 'Viktor',
	    lastName: 'Yosifov',
	    age: 28,
	    marks: [4, 4, 3]
	},
	{
	    firstName: 'Todor',
	    lastName: 'Aleksiev',
	    age: 30,
	    marks: [4, 5, 5]
	},
	{
	    firstName: 'Nikolay',
	    lastName: 'Nikolov',
	    age: 26,
	    marks: [3, 4, 3]
	},
	{
	    firstName: 'Tsvetan',
	    lastName: 'Sokolov',
	    age: 24,
	    marks: [6, 6, 5]
	}];

    studentWithHighestMarks = _.chain(students)
							   .sortBy(sortByMarks)
                               .last()
                               .value();

    printStudent(studentWithHighestMarks);

    function sortByMarks(student) {
        var averageMark;

        averageMark = _.reduce(student.marks, function (memo, num) {
            return memo + num;
        }, 0) / student.marks.length;

        return averageMark;
    }

    function printStudent(student) {
        var marks;

        console.log('First name: ' + student.firstName);
        console.log('Last name: ' + student.lastName);
        console.log('Age: ' + student.age.toString());

        marks = '';

        _.each(student.marks, function (mark) {
            marks += mark.toString() + ' ';
        });

        console.log('Marks: ' + marks);
    }
};