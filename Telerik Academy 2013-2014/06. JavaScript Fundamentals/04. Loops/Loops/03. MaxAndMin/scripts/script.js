function onCheckMaxAndMinBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(" "),
        i,
        min = Number.MAX_SAFE_INTEGER,
        max = Number.MIN_SAFE_INTEGER;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);

        if (numbers[i] > max) {
            max = numbers[i];
        }

        if (numbers[i] < min) {
            min = numbers[i];
        }
    }

    jsConsole.writeLine("Max: " + max);
    jsConsole.writeLine("Min: " + min);
}