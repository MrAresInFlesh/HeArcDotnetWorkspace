using System;

namespace exercice1
{
    
    public class Player
    {
        private string name;
        private int score = 0;

        public Player(string name)
        {
            this.name = name;
        }

        public static (int, int) play()
        {
            int cellInputI = int.Parse(Console.ReadLine());
            int cellInputJ = int.Parse(Console.ReadLine());
            return (cellInputI, cellInputJ);
        }

        public int GetScore()
        {
            return this.score;
        }

        public void SetScore(int value)
        {
            this.score = value;
        }
    }
}