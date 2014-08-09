function onCheckShowNumberBtnClick() {
    var number = jsConsole.readInteger('#tb-number'),
        digits = ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"],
        teenth = ["Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
                  "Eighteen", "Nineteen"],
        tenth = ["Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"],
        and = "and",
        hundred = "hundred",
        digit = parseInt(number / 100),
        result;

    if (number >= 0 && number <= 999) {
        if (digit === 0) {
            digit = parseInt(number / 10);

            if (digit === 0) {
                result = digits[number];
            } else if (digit === 1) {
                digit = number % 10;
                result = teenth[digit];
            } else {
                result = tenth[digit - 2];
                digit = number % 10;

                if (digit !== 0) {
                    result = result.concat(" " + digits[digit].toLowerCase());
                }
            }
        } else {
            result = digits[digit] + " hundred";
            digit = parseInt((number % 100) / 10);

            if (digit === 0) {
                digit = number % 10;

                if (digit !== 0) {
                    result = result.concat(" and " + digits[digit].toLowerCase());
                }
            } else if (digit === 1) {
                digit = number % 10;
                result = result.concat(" and " + teenth[digit].toLowerCase());
            } else {
                result = result.concat(" " + tenth[digit - 2].toLowerCase());
                digit = number % 10;

                if (digit !== 0) {
                    result = result.concat(" " + digits[digit].toLowerCase());
                }
            }
        }

        jsConsole.writeLine(result);
    } else {
        jsConsole.writeLine("The number must be in the range [0...999]!");
    }
}