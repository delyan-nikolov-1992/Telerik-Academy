/// <reference path="js-console.js" />

window.onload = function () {
    'use strict';

    var MIN_VALUE = 1000,
        MAX_VALUE = 9999,
        numberOfGuesses = 0,
        answer,
        input,
        submitButton,
        newGameButton,
        namesOfWinners = [];

    loadHighscoreTable();

    answer = randomIntFromInterval(MIN_VALUE, MAX_VALUE);

    input = document.getElementById('input-number');
    submitButton = document.getElementById('submit-number');
    newGameButton = document.getElementById('new-game-button');

    submitButton.addEventListener('click', submitNumber);
    newGameButton.addEventListener('click', startNewGame);

    function submitNumber() {
        var inputValue,
            guessedNumber,
            i,
            j,
            len,
            answerAsString,
            sheeps,
            rams;

        console.log(answer);
        inputValue = input.value;
        guessedNumber = Number(inputValue);

        if (Math.floor(guessedNumber) === guessedNumber && guessedNumber >= MIN_VALUE && guessedNumber <= MAX_VALUE) {
            numberOfGuesses++;

            if (guessedNumber !== answer) {
                sheeps = 0;
                rams = 0;
                answerAsString = answer.toString();

                for (i = 0, len = inputValue.length; i < len; i++) {
                    if (inputValue[i] === answerAsString[i]) {
                        rams++;
                    } else {
                        for (j = 0; j < len; j++) {
                            if (i !== j && inputValue[i] === answerAsString[j] && inputValue[j] !== answerAsString[j]) {
                                sheeps++;
                                break;
                            }
                        }
                    }
                }

                jsConsole.writeLine('Sheeps: ' + sheeps);
                jsConsole.writeLine('Rams: ' + rams);
            } else {
                jsConsole.writeLine('Congratulations! You have 4 rams and you needed only ' + numberOfGuesses + ' guesses.');
                jsConsole.writeLine('The correct number is ' + answer + '.');

                input.style.display = 'none';
                submitButton.style.display = 'none';
                newGameButton.style.display = 'inline';

                updateHighscore();
            }
        } else {
            jsConsole.writeLine('The input should be a positive integer between ' + MIN_VALUE + ' and ' + MAX_VALUE + '!');
        }
    }

    function updateHighscore() {
        var name;

        name = prompt("Congratulations! Please, enter your name:");

        while (true) {
            if (namesOfWinners.indexOf(name) === -1) {
                break;
            }

            name = prompt("The name already exists! Please, enter another name:");
        }

        localStorage.setItem(name, numberOfGuesses);
        loadHighscoreTable();
    }

    function loadHighscoreTable() {
        var i,
            len,
            highscoreHTML = '',
            htmlTable = document.getElementById('highscoreTable'),
            results = [];

        results = loadPairs();

        results.sort(function (a, b) {
            return a.guesses - b.guesses;
        });

        if (!(!localStorage.length || localStorage.length === 0)) {
            for (i = 0, len = results.length; i < len; i++) {
                highscoreHTML += '<tr><td>' + (i + 1) + '</td><td>' + results[i].name + '</td><td>' + results[i].guesses + "</td></tr>";
            }

            htmlTable.innerHTML = highscoreHTML;
        }
    }

    function startNewGame() {
        answer = randomIntFromInterval(MIN_VALUE, MAX_VALUE);
        numberOfGuesses = 0;

        newGameButton.style.display = 'none';
        input.style.display = 'inline';
        submitButton.style.display = 'inline';

        document.querySelector('#js-console p').innerText = '';
        document.getElementById('input-number').value = '';
    }

    function loadPairs() {
        var result = [],
            i,
            len,
            key,
            value,
            obj = {};

        if (!(!localStorage.length || localStorage.length === 0)) {
            for (i = 0, len = localStorage.length; i < len; i++) {
                key = localStorage.key(i);
                value = localStorage.getItem(key);

                if (isIntegerNumber(value)) {
                    namesOfWinners.push(key);

                    obj = {
                        name: key,
                        guesses: parseInt(value)
                    };

                    result.push(obj);
                }
            }
        }

        return result;
    }

    function randomIntFromInterval(min, max) {
        var randomInt = Math.floor(Math.random() * (max - min + 1) + min);

        return randomInt;
    }

    function isIntegerNumber(value) {
        if (!isNaN(value) && value.indexOf('.') === -1) {
            return true;
        }

        return false;
    }
};