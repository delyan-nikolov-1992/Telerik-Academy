(function () {
    var numbers = new Array(20),
        i;

    for (i = 0; i < numbers.length; i++) {
        numbers[i] = i * 5;
        jsConsole.writeLine(numbers[i]);
    }
}).call(this);