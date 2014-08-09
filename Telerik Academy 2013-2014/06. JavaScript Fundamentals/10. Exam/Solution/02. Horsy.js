function solve(input) {
    var rowsAndCols = input[0].split(" ").map(Number),
        rows = rowsAndCols[0],
        cols = rowsAndCols[1],
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
            field[i][j] = parseInt(input[i + 1][j]);
            //console.log(field[i][j]);
            fieldWithNumbers[i][j] = Math.pow(2, i) - j;
            //console.log(fieldWithNumbers[i][j]);
        }
    }

    var currentRow = rows - 1;
    var currentCol = cols - 1;

    while (true) {
        if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
            return "Go go Horsy! Collected " + sumOfNumbers + " weeds";
        } else if (fieldWithNumbers[currentRow][currentCol] === 'X') {
            return "Sadly the horse is doomed in " + numberOfCells + " jumps";
        }

        sumOfNumbers += fieldWithNumbers[currentRow][currentCol];
        numberOfCells += 1;
        fieldWithNumbers[currentRow][currentCol] = 'X';
        direction = field[currentRow][currentCol];

        if (direction === 1) {
            currentRow -= 2;
            currentCol += 1;
        } else if (direction === 2) {
            currentRow -= 1;
            currentCol += 2;
        } else if (direction === 3) {
            currentRow += 1;
            currentCol += 2;
        } else if (direction === 4) {
            currentRow += 2;
            currentCol += 1;
        } else if (direction === 5) {
            currentRow += 2;
            currentCol -= 1;
        } else if (direction === 6) {
            currentRow += 1;
            currentCol -= 2;
        } else if (direction === 7) {
            currentRow -= 1;
            currentCol -= 2;
        } else if (direction === 8) {
            currentRow -= 2;
            currentCol -= 1;
        }
    }
}