function onCheckSelectionSortBtnClick() {
    var numbers = jsConsole.read('#tb-numbers').split(", "),
        i,
        j,
        minElement,
        oldValue;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = parseInt(numbers[i]);
    }

    for (i = 0; i < numbers.length; i++) {
        minElement = i;

        for (j = i + 1; j < numbers.length; j++) {
            if (numbers[j] < numbers[minElement]) {
                minElement = j;
            }
        }

        if (minElement !== i) {
            oldValue = numbers[i];
            numbers[i] = numbers[minElement];
            numbers[minElement] = oldValue;
        }
    }

    for (i = 0; i < numbers.length; i++) {
        jsConsole.write(numbers[i] + " ");
    }

    jsConsole.writeLine("");
}