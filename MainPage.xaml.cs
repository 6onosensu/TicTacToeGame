namespace TicTacToeGame;
public partial class MainPage : ContentPage
{
    Entry playerXEntry, playerOEntry;
    Label label, gameLabel;
    RadioButton rbtnPlayer, rbtnComputer;
    Button newGameBtn, toMainPageBtn;
    private GameLogic logic;
    private GameRender render;
    private GameBoard board;
    private Player playerX;
    private Player playerO;

    public MainPage()
    {
        InitializeComponent();
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

        rbtnPlayer.CheckedChanged += OnModeChanged;
        rbtnComputer.CheckedChanged += OnModeChanged;

        playerXEntry = new Entry
        {
            Placeholder = "Enter Player X Name",
            FontSize = 24,
            WidthRequest = 300,
            HeightRequest = 70,
            TextColor = Colors.Blue,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };
        playerOEntry = new Entry
        {
            Placeholder = "Enter Player O Name",
            WidthRequest = 300,
            HeightRequest = 70,
            FontSize = 24,
            TextColor = Colors.Blue,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            IsVisible = false,
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
            Padding = 10,
            Spacing = 10,
            Children = { label, gameLabel, rbtnComputer, rbtnPlayer, playerXEntry, playerOEntry, startButton }
        };
    }
    private void OnModeChanged(object sender, CheckedChangedEventArgs e)
    {
        playerOEntry.IsVisible = rbtnPlayer.IsChecked;
    }
    private void OnStartGameClicked(object? sender, EventArgs e)
    {
        string nameX = playerXEntry.Text;
        string nameO = playerOEntry.Text;

        playerX = new Player("X", nameX);

        if (rbtnComputer.IsChecked)
        {
            playerO = new Player("O", "Computer");
        }
        else
        {
            playerO = new Player("O", nameO);
        }

        board = new GameBoard();
        render = new GameRender(this);
        logic = new GameLogic(board, render, playerX, playerO);

        logic.ResetGame();

        AddButtons();

        StackLayout layout = new StackLayout
        {
            Padding = 10,
            Spacing = 10,
            Children = { render.NextPlayerLabel, render.GetBoard(), newGameBtn, toMainPageBtn }
        };
        Content = layout;
    }

    private void AddButtons()
    {
        newGameBtn = new Button
        {
            Text = "New Game",
            BackgroundColor = Colors.Green,
            TextColor = Colors.White,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        newGameBtn.Clicked += OnNewGameClicked;

        toMainPageBtn = new Button
        {
            Text = "To Main Page",
            BackgroundColor = Colors.Red,
            TextColor = Colors.White,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center
        };
        toMainPageBtn.Clicked += OnToMainPageClicked;
    }

    private void OnNewGameClicked(object sender, EventArgs e)
    {
        logic.ResetGame();
    }

    private void OnToMainPageClicked(object sender, EventArgs e)
    {
        CreateStartPage();
    }
    public void OnGridTapped(int row, int col)
    {
        logic.MakeMove(row, col);
        render.UpdateBoard(board);
    }
}
