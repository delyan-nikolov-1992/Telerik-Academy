/// <reference path="libs/jquery.js" />

(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery",
            "handlebars": "libs/handlebars",
            "combobox": "combobox",
            "templateEngine": "templateEngine"
        }
    });

    require(["jquery", "templateEngine", "combobox"], function ($) {
        // I am just requiring the combobox and template engine modules to create the Jquery Plugins. Then just use them.

        // Data object
        var people = [{
            id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/doncho.jpg"
            },
            {
                id: 2, name: "Niki Kostov", age: 19, avatarUrl: "images/niki.jpg"
            },
            {
                id: 3, name: "Ivo Kenov", age: 15, avatarUrl: "images/ivo.jpg"
            }];

        // Populate the main div
        $("#mainDiv").templateEngine(people);

        // Use jquery plugin to make the dropdown
        $("#mainDiv").combobox();
    });

}());