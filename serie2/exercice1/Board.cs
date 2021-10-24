using System;

namespace exercice1
{
    public enum CellState
    {
        E = (' ', true)
        X = ('X', false)
        O = ('O', false)
    }

    public struct Cell
    {
        private CellState state;

        public Cell()
        {
            state = Morp.E;
        }

        public CellState getCellState()
        {
            return state;
        }

        public void SetCellState()
        {
            if(this.state == CellState.E)
            {
                if()
            }
        }
    }

    public class Board
    {
        public int[,] Board;
        private int size;

        /// <summary>
        /// 
        /// </summary>
        public GameBoard(int size)
        {
            InitializeBoard();
        }

        /**
        Initialize Board - set board fields as empty
            */
        private void InitializeBoard(int size)
        {
            Board = new Cell[size, BOARD_SIZE];
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board.Length; j++)
                {
                    Board[i, j] = new Cell();
                }
            }
        }

        public void PrintBoard()
        {
            const int ASCII_CODE_0 = 48;
            int fieldNumber = 1;
            Console.WriteLine("-----");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (Board[i, j].isEmpty())
                        Console.Write((char)(ASCII_CODE_0 + fieldNumber));
                    else
                        Console.Write((char)(Board[i, j].getFieldState()));
                    fieldNumber++;

                    if (j < BOARD_SIZE - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine("-----");
        }

        public void PutMark(Player player, int fieldNumber)
        {

            int verticalY = (fieldNumber - 1) / 3;
            int horizontalX = (fieldNumber - 1) % 3;
            if (Board[verticalY, horizontalX].isEmpty())
            {
                Board[verticalY, horizontalX].markField(player);

            }

            else
            {
                Console.WriteLine("This place is taken. Select the field again: ");
                putMark(player, player.takeTurn());
            }
        }

        public void ClearBoard()
        {
            Console.Clear();
        }
    }
}