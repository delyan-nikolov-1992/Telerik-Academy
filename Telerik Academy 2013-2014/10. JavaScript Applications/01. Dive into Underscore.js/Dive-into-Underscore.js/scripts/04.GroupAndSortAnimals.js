/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var animals,
		groupedAndSortedAnimals;

    animals = [
	{
	    name: 'lion',
	    species: 'mammal',
	    numberOfLegs: 4
	},
	{
	    name: 'hummingbird',
	    species: 'bird',
	    numberOfLegs: 2
	},
	{
	    name: 'housefly',
	    species: 'insect',
	    numberOfLegs: 6
	},
	{
	    name: 'penguin',
	    species: 'bird',
	    numberOfLegs: 2
	},
	{
	    name: 'spider',
	    species: 'insect',
	    numberOfLegs: 8
	},
	{
	    name: 'bear',
	    species: 'mammal',
	    numberOfLegs: 2
	}];

    groupedAndSortedAnimals = _.chain(animals)
                               .sortBy('numberOfLegs')
							   .groupBy('species')
                               .value();

    _.each(groupedAndSortedAnimals, printAnimals);

    function printAnimals(animals) {
        console.log('Species: ' + _.first(animals).species);

        _.each(animals, function (animal) {
            console.log('Name: ' + animal.name);
            console.log('Number of legs: ' + animal.numberOfLegs.toString());
        });

        console.log('');
    }
};