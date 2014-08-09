function onCheckCheckNeighborsBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        index = jsConsole.readInteger('#tb-index'),
        i;

    if (index === 0 || index === numbers.length - 1) {
        jsConsole.writeLine("The number at index " + index + " does not have two neighbors.");
    } else {
        numbers = numbers.map(Number);

        if (numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1]) {
            jsConsole.writeLine("The number at index " + index + " is bigger than its two neighbors.");
        } else {
            jsConsole.writeLine("The number at index " + index + " is not bigger than its two neighbors.");
        }
    }
}