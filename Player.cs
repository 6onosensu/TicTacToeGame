namespace TicTacToeGame
{
    internal class Player
    {
        public char Symbol { get; set; }
        public string Nickname {  get; set; }
        public List<int> Moves { get; set; }

        public Player(char symbol, string nickname) 
        {
            Symbol = symbol;
            Nickname = nickname;
            Moves = new List<int>();
        }

        public void AddMove(int move) 
        { 
            Moves.Add(move);
        }

        public void ResetMoves() { Moves.Clear(); }
    }
}
