/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var people,
		mostCommonFirstName,
        mostCommonLastName;

    people = [
	{
	    firstName: 'Georgi',
	    lastName: 'Bratoev'
	},
	{
	    firstName: 'Todor',
	    lastName: 'Skrimov'
	},
	{
	    firstName: 'Valentin',
	    lastName: 'Bratoev'
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

    mostCommonFirstName = mostCommonName(people, 'firstName');
    mostCommonLastName = mostCommonName(people, 'lastName');

    printName(mostCommonFirstName, 'first name');
    printName(mostCommonLastName, 'last name');

    function mostCommonName(people, name) {
        var countName;

        countName = _.chain(people)
                     .countBy(name)
                     .pairs()
                     .sortBy(1)
                     .last()
                     .value();

        return countName;
    }

    function printName(mostCommonName, name) {
        console.log('There are ' + _.last(mostCommonName) + ' people with ' + name + ' ' + _.first(mostCommonName));
    }
};