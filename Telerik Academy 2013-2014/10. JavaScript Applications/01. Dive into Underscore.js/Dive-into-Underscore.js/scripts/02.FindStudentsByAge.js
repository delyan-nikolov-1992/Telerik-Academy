/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var students,
		studentsWithAgeBetween18And24;

    students = [
	{
	    firstName: 'Georgi',
	    lastName: 'Bratoev',
	    age: 26
	},
	{
	    firstName: 'Todor',
	    lastName: 'Skrimov',
	    age: 24
	},
	{
	    firstName: 'Viktor',
	    lastName: 'Yosifov',
	    age: 28
	},
	{
	    firstName: 'Todor',
	    lastName: 'Aleksiev',
	    age: 30
	},
	{
	    firstName: 'Nikolay',
	    lastName: 'Nikolov',
	    age: 26
	},
	{
	    firstName: 'Tsvetan',
	    lastName: 'Sokolov',
	    age: 24
	}];

    studentsWithAgeBetween18And24 = _.chain(students)
								     .filter(isAgeBetween18And24)
                                     .map(findFirstNameAndLastName)
								     .value();

    _.each(studentsWithAgeBetween18And24, printStudent);

    function isAgeBetween18And24(student) {
        return student.age >= 18 && student.age <= 24;
    }

    function findFirstNameAndLastName(student) {
        return {
            firstName: student.firstName,
            lastName: student.lastName
        };
    }

    function printStudent(student) {
        console.log('First name: ' + student.firstName);
        console.log('Last name: ' + student.lastName);
        console.log('');
    }
};