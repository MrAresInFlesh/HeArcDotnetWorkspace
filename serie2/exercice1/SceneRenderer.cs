using System;

namespace exercice1
{
    public class SceneRenderer: I_EndGameConditions<Board>
    {
        private Board board;
        private Player a_player, b_player;
        private Boolean gameOver;
        private int turn;

        public SceneRenderer()
        {
            Welcome();
            InitializePlayers();
            InitializeBoard();
            PlayGame();
        }

        public void Welcome()
        {
            Console.WriteLine("#############################################################");
            Console.WriteLine("         WELCOME TO THIS TICTACTOE GAME IN C# !");
            Console.WriteLine("#############################################################");
        }

        public void InitializePlayers()
        {
            Console.WriteLine("Enter name of player 1 :");
            string name = Console.ReadLine().ToString();
            this.a_player = new Player(name, CellState.O);
            Console.WriteLine("Hello " + this.a_player.name + "! \n");

            Console.WriteLine("Enter name of player 2 :");
            name = Console.ReadLine().ToString();
            this.b_player = new Player(name, CellState.X);
            Console.WriteLine("Hello " + this.b_player.name + "! \n");
        }

        public void InitializeBoard()
        {
            Console.WriteLine("Enter the size of Tic Tac Toe board :");
            int size = int.Parse(Console.ReadLine());
            this.board = new Board(size);
            this.board.Display();
        }

        public void PlayGame()
        {
            this.turn = 1;
            this.gameOver = false;
            while(!this.gameOver)
            {
                if(this.turn % 2 == 0)
                {
                    Console.WriteLine("Player " + this.b_player.name + " can play.\n Enter coordinates in the form of (x, y) to play : \n");
                    this.board.PutMark(b_player.GetCellState(), Play());              
                }
                else
                {
                    this.board.PutMark(a_player.GetCellState(), Play());
                }
                Update();
                EndGame();
            }
        }

        private (int, int) Play()
        {
            //(int cellInputI, int cellInputJ) = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            char[] inputs = Console.ReadLine().ToCharArray();
            Console.WriteLine(inputs.GetValue(1).ToString() + ", " + (inputs.GetValue(3).ToString()));

            (int cellInputI, int cellInputJ) = (Convert.ToInt32((inputs.GetValue(1))), Convert.ToInt32((inputs.GetValue(3))));

            if (cellInputI >= 0 || cellInputI < this.board.Size() &&
                cellInputJ >= 0 || cellInputJ < this.board.Size())
	        {
                this.turn += 1;
                return (cellInputI, cellInputJ);
	        }
            else
            {
                Console.WriteLine("...");
                return Play();
            }
        }

        public void EndGame()
        {
            Console.WriteLine("\n Press [q] to quit");
            if(Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.Q)
                this.gameOver = true;
            }
        }

        public bool Update()
        {
            board.Display();
            if     (EndGameDraw(this.board))        return this.gameOver = true;
            else if(EndGameColumns(this.board))     return this.gameOver = true;
            else if(EndGameDiagonals(this.board))   return this.gameOver = true;
            else if(EndGameRows(this.board))        return this.gameOver = true;
            else return false;
        }

        public bool EndGameDraw(Board board)
        {
            foreach (Cell cell in board.boardGame)
            {
                if (cell.GetCellState() == CellState.E)
                {
                    return false;
                }
                else
                { 
                    return true; 
                }
            }
            return false;
        }

        public bool EndGameColumns(Board board)
        {
            bool check = false;
            for (int j = 0; j < board.Size(); j++)
            {
                for (int i = 0; i < board.Size(); i++)
			    {
                    if (board.boardGame[i, j].GetCellState() != CellState.E &&
                        board.boardGame[i, j].GetCellState() == board.boardGame[i+1, j+1].GetCellState())
                    {
                        check = true;
                    }
                    else check = false;
			    }
            }
            return check;
        }
        
        public bool EndGameRows(Board board)
        {
            bool check = false;
            for (int i = 0; i < board.Size(); i++)
            {
                for (int j = 0; j < board.Size(); j++)
			    {
                    if (board.boardGame[i, j].GetCellState() != CellState.E &&
                        board.boardGame[i, j].GetCellState() == board.boardGame[i, j+1].GetCellState())
                    {
                        check = true;
                    }
                    else check = false;
			    }
            }
            return check;
        }

        public bool EndGameDiagonals(Board board)
        {
            bool check = false;
            for (int i = 0, j = 0; i < board.Size(); i++, j++)
            {
                if (board.boardGame[i, j].GetCellState() != CellState.E && 
                    board.boardGame[i, j].GetCellState() == board.boardGame[i+1, j+1].GetCellState())
                {
                    check = true;
                }
                else check = false;
            }
            return check;
        }
    }
}