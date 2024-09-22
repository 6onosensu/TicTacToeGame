namespace TicTacToeGame
{
    internal class Player
    {
        public string Symbol { get; set; }
        public string Nickname {  get; set; }

        public Player(string symbol, string nickname) 
        {
            Symbol = symbol;
            Nickname = nickname;
        }
    }
}
