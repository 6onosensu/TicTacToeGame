namespace TicTacToeGame
{
    internal class GameBoard
    {
        string[,] board;

        readonly int[][] combinations = new int[][]
        {
            new int[] { 0, 1, 2 }, // top row
            new int[] { 3, 4, 5 }, // middle row
            new int[] { 6, 7, 8 }, // bottom row
            new int[] { 0, 3, 6 }, // left column
            new int[] { 1, 4, 7 }, // middle column
            new int[] { 2, 5, 8 }, // right column
            new int[] { 0, 4, 8 }, // top-left to bottom-right
            new int[] { 2, 4, 6 }  // top-right to bottom-left
        };

        public GameBoard()
        {
            board = new string[3, 3];
            ResetBoard();
        }

        public string GetCell(int row, int col)
        {
            return board[row, col];
        }

        public bool MakeMove(int row, int col, string symbol)
        {
            if (IsCellEmpty(row, col))
            {
                board[row, col] = symbol;
                return true;
            }
            return false;
        }

        public bool IsCellEmpty(int row, int col)
        {
            return board[row, col] == "";
        }

        public bool IsBoardFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (IsCellEmpty(row, col))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckWinner(string symbol)
        {
            string[] boardList = new string[9];
            int index = 0;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    boardList[index] = board[row, col];
                    index++;
                }
            }

            foreach (var comb in combinations)
            {
                if (boardList[comb[0]] == symbol &&
                    boardList[comb[1]] == symbol &&
                    boardList[comb[2]] == symbol)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsDraw()
        {
            return IsBoardFull() && !CheckWinner("X") && !CheckWinner("O");
        }

        public void ResetBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = "";
                }
            }
        }
    }
}