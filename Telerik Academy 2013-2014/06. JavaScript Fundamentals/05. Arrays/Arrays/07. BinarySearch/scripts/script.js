function onCheckBinarySearchBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        searchedNumber = jsConsole.readInteger('#tb-searched-number'),
        index;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);
    }

    numbers.sort(orderBy);
    index = binarySearch(numbers, searchedNumber, 0, numbers.length - 1);

    jsConsole.writeLine(index === null ? "There is no such number: " + searchedNumber
            : "The index of " + searchedNumber + " is " + index);
}

function orderBy(firstNumber, secondNumber) {
    return firstNumber > secondNumber;
}

function binarySearch(numbers, searchedNumber, min, max) {
    var middle;

    if (max < min) {
        return null;
    } else {
        middle = Math.floor((min + max) / 2);

        if (numbers[middle] > searchedNumber) {
            return binarySearch(numbers, searchedNumber, min, middle - 1);
        } else if (numbers[middle] < searchedNumber) {
            return binarySearch(numbers, searchedNumber, middle + 1, max);
        } else {
            return middle;
        }
    }
}