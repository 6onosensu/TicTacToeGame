namespace TicTacToeGame
{
    internal class GameRender
    {
        Grid board;
        Label label;
        Label[,] labels = new Label[3, 3];
        private MainPage mainPage;
        public Label NextPlayerLabel { get; private set; }
        public GameRender(MainPage page)
        {
            this.mainPage = page;
            board = new Grid();
            CreateBoard();

            NextPlayerLabel = new Label
            {
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            
        }
        public Grid GetBoard()
        {
            return board;
        }

        private void CreateBoard() 
        { 
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++) 
                {
                    label = new Label
                    {
                        Text = "",
                        FontSize = 30,
                        TextColor = Colors.White,
                        BackgroundColor = Colors.LightGray,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };

                    var tapGesture = new TapGestureRecognizer();
                    tapGesture.Tapped += OnLabelTapped;
                    label.GestureRecognizers.Add(tapGesture);

                    board.Add(label, col, row);
                    labels[row, col] = label;
                }
            }
        }

        private void OnLabelTapped(object sender, EventArgs e)
        {
            Label tappedLabel = (Label)sender;

            int row = Grid.GetRow(tappedLabel);
            int col = Grid.GetColumn(tappedLabel);

            mainPage.OnGridTapped(row, col);
        }

        public void UpdateBoard(GameBoard gameBoard)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    UpdateCell(row, col, gameBoard.GetCell(row, col));
                }
            }
        }
        public void UpdateCell(int row, int col, string symbol)
        {
            Label label = labels[row, col];
            label.Text = symbol;
            if (symbol == "X") { label.BackgroundColor = Colors.Red; }
            else if (symbol == "O") { label.BackgroundColor = Colors.Green; }
            else { label.BackgroundColor = Colors.LightGray; }

        }

        public void UpdateNextPlayerLabel(string text) 
        {
            NextPlayerLabel.Text = text;
        }

        public void SetCellsGray()
        {
            foreach (var label in labels)
            {
                label.BackgroundColor = Colors.Gray;
            }
        }

        public void DisableCells()
        {
            foreach (var label in labels)
            {
                if (label != null && label.GestureRecognizers.Count > 0)
                {
                    label.GestureRecognizers.Clear();
                }
            }
        }
        public void EnableCells()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Label label = labels[row, col];
                    if (label != null)
                    {
                        var tapGesture = new TapGestureRecognizer();
                        tapGesture.Tapped += OnLabelTapped;
                        label.GestureRecognizers.Add(tapGesture);
                    }
                }
            }
        }

    }
}