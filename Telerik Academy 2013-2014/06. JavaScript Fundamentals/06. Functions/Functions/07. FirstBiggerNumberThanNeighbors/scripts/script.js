function onCheckCheckNeighborsBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        result = false,
        i;

    numbers = numbers.map(Number);

    for (i = 1; i < numbers.length - 1; i++) {
        if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1]) {
            jsConsole.writeLine(i);
            result = true;
            break;
        }
    }

    if (!result) {
        jsConsole.writeLine(-1);
    }
}