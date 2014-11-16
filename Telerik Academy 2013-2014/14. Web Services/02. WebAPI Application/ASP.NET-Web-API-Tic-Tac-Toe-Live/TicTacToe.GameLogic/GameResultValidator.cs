namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        // O-X
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            GameResult winnerByRow = this.WinnerByRow(board);

            if (winnerByRow != GameResult.NotFinished)
            {
                return winnerByRow;
            }

            GameResult winnerByCol = this.WinnerByCol(board);

            if (winnerByCol != GameResult.NotFinished)
            {
                return winnerByCol;
            }

            GameResult winnerByDiagonal = this.WinnerByDiagonal(board);

            if (winnerByDiagonal != GameResult.NotFinished)
            {
                return winnerByDiagonal;
            }

            if (!board.Contains("-"))
            {
                return GameResult.Draw;
            }

            return GameResult.NotFinished;
        }

        private GameResult WinnerByRow(string board)
        {
            for (int i = 0; i < board.Length; i += 3)
            {
                if (board[i] != '-' && board[i] == board[i + 1] && board[i + 1] == board[i + 2])
                {
                    if (board[i] == 'X')
                    {
                        return GameResult.WonByX;
                    }

                    return GameResult.WonByO;
                }
            }

            return GameResult.NotFinished;
        }

        private GameResult WinnerByCol(string board)
        {
            for (int i = 0; i < board.Length / 3; i++)
            {
                if (board[i] != '-' && board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    if (board[i] == 'X')
                    {
                        return GameResult.WonByX;
                    }

                    return GameResult.WonByO;
                }
            }

            return GameResult.NotFinished;
        }

        private GameResult WinnerByDiagonal(string board)
        {
            if (board[0] != '-' && board[0] == board[4] && board[4] == board[8])
            {
                if (board[0] == 'X')
                {
                    return GameResult.WonByX;
                }

                return GameResult.WonByO;
            }
            else if (board[2] != '-' && board[2] == board[4] && board[4] == board[6])
            {
                if (board[2] == 'X')
                {
                    return GameResult.WonByX;
                }

                return GameResult.WonByO;
            }

            return GameResult.NotFinished;
        }
    }
}