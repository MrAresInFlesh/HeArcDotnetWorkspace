using System;

namespace exercice1
{
    /// <summary>
    /// 
    /// </summary>
    public enum CellState
    {
        E = ' ',
        X = 'X',
        O = 'O'
    }

    /// <summary>
    /// 
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
    /// 
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
        /// 
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
        /// 
        /// </summary>
        public void Display()
        {
            Console.Write(" ");
            for (int i = 0; i < this.boardSize; i++)
            {
                Console.Write("======");
            }
            Console.Write("\n");
            for (int i = 0; i < this.boardSize; i++)
            {
                Console.Write(" |");
                for (int j = 0; j < this.boardSize; j++)
                {
                    Console.Write("  " + (char)(this.boardGame[i, j].GetCellState()) + "  ");
                    if (j <= this.boardSize - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("\n |");
                for (int k = 0; k < this.boardSize - 1; k++)
                {
                    Console.Write("-----+");
                }
                Console.Write("-----|\n");
            }
            Console.Write(" ");
            for (int i = 0; i < this.boardSize; i++)
            {
                Console.Write("======");
            }
            Console.Write("\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="fieldNumber"></param>
        public void PutMark(CellState cellState, (int i, int j) coord)
        {
            if (this.boardGame[coord.i, coord.j].GetCellState() == CellState.E)
            {
                this.boardGame[coord.i, coord.j].SetCellState(cellState);
                Display();
            }
            else
            {
                Console.WriteLine("This place is taken. Select the field again: \n");
                this.PutMark(cellState, coord);
                Display();
            }
        }

        public void ClearBoard()
        {
            Console.Clear();
        }
    }
}