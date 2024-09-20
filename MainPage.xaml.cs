namespace TicTacToeGame;
public partial class MainPage : ContentPage
{
    Label label, gameLabel;
    RadioButton rbtnPlayer, rbtnComputer;
    private GameLogic logic;
    private GameRender render;
    private GameBoard board;
    private Player playerX;
    private Player playerO;

    public MainPage()
    {
        InitializeComponent();

        logic = new GameLogic();
        board = new GameBoard();
        render = new GameRender();
        playerX = new Player("X");
        playerO = new Player("O");

        CreateStartPage();
    }
        
    private void CreateStartPage()
    {
        label = new Label()
        {
            Padding = 5,
            Text = "Tic-Tac-Toe",
            TextColor = Colors.Blue,
            FontSize = 30,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Start,
        };

        gameLabel = new Label
        {
            Padding = 3,
            Text = "Let's play!",
            TextColor = Colors.Black,
            FontSize = 24,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        rbtnPlayer = new RadioButton
        {
            Content = "Player vs Player",
            Value = "players",
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };

        rbtnComputer = new RadioButton
        {
            Content = "Player vs Computer",
            Value = "computer",
            IsChecked = true,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };

        

        Button startButton = new Button()
        {
            Text = "Start Game",
            FontSize = 26,
            TextColor = Colors.White,
            BackgroundColor = Colors.Blue,
            FontAttributes = FontAttributes.Bold,
            CornerRadius = 3,
            WidthRequest = 140,
            HeightRequest = 70,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.End
        };

        startButton.Clicked += OnStartGameClicked;

        Content = new StackLayout
        {
            Children = { label, gameLabel, rbtnComputer, rbtnPlayer, startButton }
        };
    }
    private void OnStartGameClicked(object sender, EventArgs e)
    {
        if (rbtnComputer.IsChecked)
        {
            logic.GameMode();
        }
        else
        {
            logic.GameMode();
        }
        board.CreateBoard();
        logic.StartGame(playerX, playerO);
        render.RenderBoard(board);
    }

    private void OnGridTapped(int gridID)
    {
        logic.Move(gridID);

        render.UpdateBoard(board);
    }
}
