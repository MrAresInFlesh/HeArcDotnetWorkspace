using System;

namespace exercice1
{
    /// <summary>
    /// Enum to represent the state of a "square" in the table of tictactoe game.
    /// </summary>
    public enum CellState
    {
        E = ' ',
        X = 'X',
        O = 'O'
    }

    /// <summary>
    /// Cell struct to be used in a board object.
    /// This is just a simple container which will be stored in a [,] array.
    /// </summary>
    public struct Cell
    {
        private CellState cellState;

        public Cell(CellState cellState)
        {
            this.cellState = cellState;
        }

        public CellState GetCellState()
        {
            return this.cellState;
        }

        public void SetCellState(CellState cellState)
        {
            if(this.cellState == CellState.E)
            {
                this.cellState = cellState;
            }
        }
    }

    /// <summary>
    /// Board class to manipulate the tictactoe board.
    /// Nothing out of the ordinary here.
    /// </summary>
    public class Board
    {
        public Cell[,] boardGame { get; set; }
        private int boardSize;

        /// <summary>
        /// 
        /// </summary>
        public Board(int size)
        {
            this.boardSize = size;
            InitializeBoard(this.boardSize);
        }

        public int Size()
        {
            return this.boardSize;
        }

        /// <summary>
        /// Initializing each square of the board with a cell.
        /// </summary>
        /// <param name="size"></param>
        private void InitializeBoard(int size)
        {
            this.boardGame = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.boardGame[i, j] = new Cell(CellState.E);
                }
            }
        }

        /// <summary>
        /// Just the display of the board in the console.
        /// </summary>
        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("            ");
            for (int i = 0; i < this.boardSize; i++)
            {
                Console.Write("======");
            }
            Console.Write("\n           ");
            for (int i = 0; i < this.boardSize; i++)
            {
                Console.Write("|");
                for (int j = 0; j < this.boardSize; j++)
                {
                    Console.Write("  " + (char)(this.boardGame[i, j].GetCellState()) + "  ");
                    if (j <= this.boardSize - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("\n           |");
                for (int k = 0; k < this.boardSize - 1; k++)
                {
                    Console.Write("-----+");
                }
                Console.Write("-----|\n           ");
            }
            Console.Write(" ");
            for (int i = 0; i < this.boardSize; i++)
            {
                Console.Write("======");
            }
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Called to change the state of a Cell in the Board when a player plays.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="fieldNumber"></param>
        public bool PutMark(CellState cellState, (int i, int j) coord)
        {
            if (this.boardGame[coord.i, coord.j].GetCellState() == CellState.E)
            {
                this.boardGame[coord.i, coord.j].SetCellState(cellState);
                return true;
            }
            else
            {
                Console.WriteLine("     | This place is taken. Select the field again: ");
                return false;
            }
        }
    }
}