/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var students,
		studentsWithFirstNameBeforeLastName;

    students = [
	{
	    firstName: 'Georgi',
	    lastName: 'Bratoev'
	},
	{
	    firstName: 'Todor',
	    lastName: 'Skrimov'
	},
	{
	    firstName: 'Viktor',
	    lastName: 'Yosifov'
	},
	{
	    firstName: 'Todor',
	    lastName: 'Aleksiev'
	},
	{
	    firstName: 'Nikolay',
	    lastName: 'Nikolov'
	},
	{
	    firstName: 'Tsvetan',
	    lastName: 'Sokolov'
	}];

    studentsWithFirstNameBeforeLastName = _.chain(students)
										   .filter(isFirstNameBeforeLastName)
										   .sortBy(sortByLastNameDescending)
                                           .value();

    _.each(studentsWithFirstNameBeforeLastName, printStudent);

    function isFirstNameBeforeLastName(student) {
        return student.firstName <= student.lastName;
    }

    function sortByLastNameDescending(student) {
        return student.lastName.charCodeAt() * -1;
    }

    function printStudent(student) {
        console.log('First name: ' + student.firstName);
        console.log('Last name: ' + student.lastName);
        console.log('');
    }
};