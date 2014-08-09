function onCheckFindRootsBtnClick() {
    var firstCoefficient = jsConsole.readFloat('#tb-first-coefficient'),
        secondCoefficient = jsConsole.readFloat('#tb-second-coefficient'),
        thirdCoefficient = jsConsole.readFloat('#tb-third-coefficient'),
        discriminant,
        firstRoot,
        secondRoot;

    if (firstCoefficient === 0) {
        jsConsole.writeLine("The equation is linear, not quadratic!");
    } else {
        discriminant = (secondCoefficient * secondCoefficient) - (4 * firstCoefficient * thirdCoefficient);

        if (discriminant < 0) {
            jsConsole.writeLine("There are no real roots!");
        } else if (discriminant === 0) {
            firstRoot = (-secondCoefficient) / (2 * firstCoefficient);
            jsConsole.writeLine("There is exactly one real root: " + firstRoot);
        } else {
            firstRoot = (-secondCoefficient + Math.sqrt(discriminant)) / (2 * firstCoefficient);
            secondRoot = (-secondCoefficient - Math.sqrt(discriminant)) / (2 * firstCoefficient);
            jsConsole.writeLine("There are two distinct roots: " + firstRoot + ", " + secondRoot);
        }
    }
}