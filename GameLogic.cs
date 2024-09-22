namespace TicTacToeGame
{
    internal class GameLogic
    {
        private GameBoard gameBoard;
        private GameRender gameRender;
        private Player currentPlayer;
        private Player playerX;
        private Player playerO;

        public GameLogic(GameBoard board, GameRender render, Player playerX, Player playerO)
        {
            this.gameBoard = board;
            this.gameRender = render;
            this.playerX = playerX;
            this.playerO = playerO;
            this.currentPlayer = playerX;
        }
        public void StartGame(Player playerX, Player playerO)
        {
            this.playerX = playerX;
            this.playerO = playerO;
            currentPlayer = playerX;
            ResetGame();
        }
        public void MakeMove(int row, int col)
        {
            if (gameBoard.MakeMove(row, col, currentPlayer.Symbol))
            {
                gameRender.UpdateCell(row, col, currentPlayer.Symbol);
                if (gameBoard.CheckWinner(currentPlayer.Symbol))
                {
                    gameRender.UpdateNextPlayerLabel($"{currentPlayer.Nickname} wins!");
                    EndGame();
                }
                else if (gameBoard.IsDraw())
                {
                    gameRender.UpdateNextPlayerLabel("It's a draw!");
                    EndGame();
                }
                else
                {
                    SwitchPlayer();
                    if (currentPlayer.Symbol == "O" && playerO.Nickname == "Computer")
                    {
                        MakeComputerMove();
                    }
                    else
                    {
                        gameRender.UpdateNextPlayerLabel($"{currentPlayer.Nickname}, it's your move!");
                    }
                }
            }
            else
            {
                gameRender.UpdateNextPlayerLabel("Cell is occupied! Try another move.");
            }
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == playerX)
            {
                currentPlayer = playerO;
            }
            else
            {
                currentPlayer = playerX;
            }
        }
        
        private void EndGame()
        {
            gameRender.SetCellsGray();
            gameRender.DisableCells();
        }

        public void ResetGame()
        {
            gameBoard.ResetBoard();
            currentPlayer = playerX;
            gameRender.UpdateBoard(gameBoard);
            gameRender.UpdateNextPlayerLabel($"{currentPlayer.Nickname}, your move!");
            gameRender.EnableCells();
        }

        public void MakeComputerMove()
        {
            
            var availablePositions = Enumerable.Range(0, 9)
                                               .Where(pos => gameBoard.GetCell(pos / 3, pos % 3) == "")
                                               .ToList();

            if (availablePositions.Count > 0)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(availablePositions.Count);
                int position = availablePositions[randomIndex];

                int row = position / 3;
                int col = position % 3;

                gameBoard.MakeMove(row, col, "O");
                gameRender.UpdateCell(row, col, "O");

                if (gameBoard.CheckWinner("O"))
                {
                    gameRender.UpdateNextPlayerLabel("Computer wins!");
                    EndGame();
                    return;
                }

                if (gameBoard.IsDraw())
                {
                    gameRender.UpdateNextPlayerLabel("It's a draw!");
                    EndGame();
                    return;
                }

                currentPlayer = playerX;
                gameRender.UpdateNextPlayerLabel($"{currentPlayer.Nickname}, it's your move!");
            }
        }
    }
}