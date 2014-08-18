/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var animals,
		allLegsOfAnimals;

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

    allLegsOfAnimals = _.chain(animals)
                        .pluck('numberOfLegs')
						.reduce(countLegs, 0)
                        .value();

    console.log('The total number of legs of all animals is ' + allLegsOfAnimals);

    function countLegs(memo, num) {
        return memo + num;
    }
};