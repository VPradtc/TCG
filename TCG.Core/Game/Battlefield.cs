namespace TCG.Core.Game
{
    public struct Battlefield
    {
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public Battlefield(Player player1, Player player2) : this()
        {
            Player1 = player1;
            Player2 = player2;
        }

    }
}
