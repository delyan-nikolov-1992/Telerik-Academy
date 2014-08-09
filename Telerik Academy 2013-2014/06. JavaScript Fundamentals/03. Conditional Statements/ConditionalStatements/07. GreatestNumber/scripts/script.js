function onCheckGreatestNumberBtnClick() {
    var firstNumber = jsConsole.readInteger('#tb-first-number'),
        secondNumber = jsConsole.readInteger('#tb-second-number'),
        thirdNumber = jsConsole.readInteger('#tb-third-number'),
        fourthNumber = jsConsole.readInteger('#tb-fourth-number'),
        fiftheNumber = jsConsole.readInteger('#tb-fifth-number'),
        greatestNumber = biggestNumber(biggestNumber(firstNumber, secondNumber, thirdNumber),
                         fourthNumber, fiftheNumber);

    jsConsole.writeLine("The greatest number is " + greatestNumber);
}

// using the algorithm from Task 03. BiggestNumber
function biggestNumber(firstNumber, secondNumber, thirdNumber) {
    if (firstNumber >= secondNumber) {
        if (firstNumber >= thirdNumber) {
            return firstNumber;
        }

        return thirdNumber;
    } else if (secondNumber >= thirdNumber) {
        return secondNumber;
    }

    return thirdNumber;
}