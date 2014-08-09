function onCheckPrimeBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        isPrime = true,
        divider = 2,
        maxDivider = Math.sqrt(number);

    if (number >= 1) {
        while (divider <= maxDivider) {
            if (number % divider === 0) {
                isPrime = false;
                break;
            }

            divider++;
        }

        if (number !== 1 && isPrime) {
            jsConsole.writeLine(number + " is prime");
        } else {
            jsConsole.writeLine(number + " is not prime");
        }
    } else {
        jsConsole.writeLine("The prime numbers are always positive!");
    }
}