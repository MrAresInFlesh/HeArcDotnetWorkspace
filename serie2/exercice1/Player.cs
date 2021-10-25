using System;

namespace exercice1
{
    
    public class Player
    {
        public string name { get; }
        private int score = 0;
        private CellState cellState;

        public Player(string name, CellState cellState)
        {
            this.name = name;
            this.cellState = cellState;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void SetScore(int value)
        {
            this.score = value;
        }

        public CellState GetCellState()
        {
            return this.cellState;
        }
    }
}