namespace TicTacToe_v2.Models
{
    public class TicTacToe
    {
        public int[,] board { get; set; } = new int[3, 3];
        public int activePlayer { get; set; } = 1;
    }
}
