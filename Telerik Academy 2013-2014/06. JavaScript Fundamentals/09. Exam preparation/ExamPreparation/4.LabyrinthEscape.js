// 04. Labyrinth Escape from JavaScript - 1 April 2013 - Evening

function Solve(input) {
    var rowsAndCols = input[0].split(" ").map(Number),
        rows = rowsAndCols[0],
        cols = rowsAndCols[1],
        startPosition = input[1].split(" ").map(Number),
        currentRow = startPosition[0],
        currentCol = startPosition[1],
        field = [],
        fieldWithNumbers = [],
        counter = 1,
        direction,
        i,
        j,
        sumOfNumbers = 0,
        numberOfCells = 0;

    for (i = 0; i < rows; i++) {
        field[i] = [];
        fieldWithNumbers[i] = [];

        for (j = 0; j < cols; j++) {
            field[i][j] = input[i + 2][j];
            fieldWithNumbers[i][j] = counter++;
        }
    }

    while (true) {
        if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
            return "out " + sumOfNumbers;
        } else if (fieldWithNumbers[currentRow][currentCol] === 'X') {
            return "lost " + numberOfCells;
        }

        sumOfNumbers += fieldWithNumbers[currentRow][currentCol];
        numberOfCells += 1;
        fieldWithNumbers[currentRow][currentCol] = 'X';
        direction = field[currentRow][currentCol];

        if (direction === 'r') {
            currentCol += 1;
        } else if (direction === 'l') {
            currentCol -= 1;
        } else if (direction === 'u') {
            currentRow -= 1;
        } else {
            currentRow += 1;
        }
    }
}