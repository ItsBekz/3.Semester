namespace TicTacToe.Models
{
    public class TicTacToeGame
    {
        private char[,] board;
        private char currentPlayer;

        public TicTacToeGame()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            InitializeBoard();
        }

        public char[,] GetBoard()
        {
            return board;
        }

        public char GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != '\0')
            {
                return false;
            }

            board[row, col] = currentPlayer;
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            return true;
        }

        private void InitializeBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = '\0';
                }
            }
        }
    }


}
