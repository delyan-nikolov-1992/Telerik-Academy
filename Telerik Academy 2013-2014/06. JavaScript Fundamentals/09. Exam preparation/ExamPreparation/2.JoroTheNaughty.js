// 02. Joro the Naughty - 1 April 2013 - Morning

function Solve(input) {
    var rowsColsAndJumps = input[0].split(" ").map(Number),
        rows = rowsColsAndJumps[0],
        cols = rowsColsAndJumps[1],
        allJumps = rowsColsAndJumps[2],
        field = initField(rows, cols),
        currentPosition = input[1].split(" ").map(Number),
        currentRow = currentPosition[0],
        currentCol = currentPosition[1],
        newPosition,
        jumpPositions = [],
        counter = 0,
        sumOfNumbers = 0,
        numberOfJumps = 0,
        i;

    for (i = 0; i < allJumps; i++) {
        newPosition = input[i + 2].split(" ").map(Number);
        jumpPositions.push(newPosition[0]);
        jumpPositions.push(newPosition[1]);
    }

    while (true) {
        if (currentRow < 0 || currentRow >= rows
                || currentCol < 0 || currentCol >= cols) {
            return "escaped " + sumOfNumbers;
        } else if (field[currentRow][currentCol] === 'X') {
            return "caught " + numberOfJumps;
        }

        sumOfNumbers += field[currentRow][currentCol];
        numberOfJumps += 1;
        field[currentRow][currentCol] = 'X';
        currentRow += jumpPositions[counter * 2];
        currentCol += jumpPositions[counter * 2 + 1];
        counter++;

        if (counter === allJumps) {
            counter = 0;
        }
    }

    function initField(rows, cols) {
        var i,
            j,
            counter = 1,
            field = [];

        for (i = 0; i < rows; i++) {
            field[i] = [];

            for (j = 0; j < cols; j++) {
                field[i][j] = counter++;
            }
        }

        return field;
    }
}