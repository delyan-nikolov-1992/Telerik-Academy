/// <reference path="libs/underscore-min.js" />

window.onload = function () {
    'use strict';

    var books,
		mostPopularAuthor;

    books = [
	{
	    name: 'Hamlet',
	    author: 'William Shakespeare'
	},
	{
	    name: 'Murder on the Orient Express',
	    author: 'Agatha Christie'
	},
    {
        name: 'Open Wings',
        author: 'Barbara Cartland'
    },
	{
	    name: 'Ten Little Niggers',
	    author: 'Agatha Christie'
	},
	{
	    name: 'King Lear',
	    author: 'William Shakespeare'
	},
	{
	    name: 'Othello',
	    author: 'William Shakespeare'
	}];

    mostPopularAuthor = _.chain(books)
                        .groupBy('author')
                        .sortBy('value')
                        .first()
                        .value();

    printAuthor(mostPopularAuthor);

    function printAuthor(books) {
        console.log('The most popular author is ' + _.first(books).author + ' with ' + books.length + ' books.');
    }
};