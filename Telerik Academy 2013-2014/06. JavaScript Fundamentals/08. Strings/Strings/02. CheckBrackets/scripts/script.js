function onCheckCheckBracketsBtnClick() {
    var expression = jsConsole.read('#tb-expression'),
        isCorrect = true,
        counter = 0,
        i;

    for (i = 0; i < expression.length; i++) {
        if (expression[i] === '(') {
            counter++;
        } else if (expression[i] === ')') {
            counter--;
        }

        if (counter < 0) {
            isCorrect = false;
            break;
        }
    }

    if (counter !== 0) {
        isCorrect = false;
    }

    jsConsole.writeLine("Is the expression correct? " + isCorrect);
}