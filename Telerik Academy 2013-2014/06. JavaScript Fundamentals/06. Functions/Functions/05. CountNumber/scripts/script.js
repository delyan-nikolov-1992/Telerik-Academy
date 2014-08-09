function onCheckCountNumberBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        searchedNumber = jsConsole.readInteger('#tb-searched-number'),
        counter;

    numbers = numbers.map(Number);
    counter = countNumber(numbers, searchedNumber);

    jsConsole.writeLine(searchedNumber + " appears " + counter +
            (counter === 1 ? " time" : " times") + " in the given array.");
}

function countNumber(numbers, searchedNumber) {
    var counter = 0,
        i;

    for (i = 0; i < numbers.length; i++) {
        if (numbers[i] === searchedNumber) {
            counter++;
        }
    }

    return counter;
}