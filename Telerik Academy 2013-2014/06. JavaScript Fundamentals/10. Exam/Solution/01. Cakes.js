function solve(params) {
    var numbers = params.map(Number);
    var amount = numbers[0];
    var current = 0;
    var answer = 0;

    numbers.shift();
    numbers.sort(orderBy);

    var sumAllNumbers = numbers[0] + numbers[1] + numbers[2];

    if (sumAllNumbers === amount) {
        return sumAllNumbers;
    }

    //while (true) {
    //    current += numbers[0];

    //    if (current > amount) {
    //        current -= numbers[0];
    //        break;
    //    }

    //    if (current === amount) {
    //        return current;
    //    }
    //}

    for (var i = 0; i < numbers.length; i++) {
        while (true) {
            current += numbers[i];

            if (current > amount) {
                break;
            }

            if (current === amount) {
                return current;
            }
        }

        current -= numbers[i];
    }

    if (current > answer) {
        answer = current;
    }

    current = 0;

    for (i = numbers.length - 1; i >= 0; i--) {
        while (true) {
            current += numbers[i];

            if (current > amount) {
                break;
            }

            if (current === amount) {
                return current;
            }
        }

        current -= numbers[i];
    }

    if (current > answer) {
        answer = current;
    }

    //current = 0;







    // NESHTO MN TYPO
    current = sumAllNumbers;

    if (current < amount) {
        for (i = 0; i < numbers.length; i++) {
            while (true) {
                current += numbers[i];

                if (current > amount) {
                    break;
                }

                if (current === amount) {
                    return current;
                }
            }

            current -= numbers[i];
        }

        if (current > answer) {
            answer = current;
        }

        current = sumAllNumbers;

        for (i = numbers.length - 1; i >= 0; i--) {
            while (true) {
                current += numbers[i];

                if (current > amount) {
                    break;
                }

                if (current === amount) {
                    return current;
                }
            }

            current -= numbers[i];
        }

        if (current > answer) {
            answer = current;
        }
    }


    function orderBy(a, b) {
        return a > b;
    }

    return answer;
}