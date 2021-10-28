using System;

namespace exercice1
{
    public class Game: I_EndGameConditions<Board>
    {
        private Board board;
        private Player a_player, b_player;
        private Boolean gameOver;
        private int turn;

        public Game()
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
            Console.WriteLine("\n   |        Enter the size of Tic Tac Toe board :");
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
                bool checkCoord = false;
                if(this.turn % 2 == 0)
                {
                    Console.WriteLine("     | ------------------------------------------------------------------------------------------------");
                    Console.WriteLine("     | Player " + this.b_player.name + " can play.");
                    Console.WriteLine("     | Enter coordinates in the form of (x, y) to play :");
                    while(!checkCoord) checkCoord = this.board.PutMark(b_player.GetCellState(), Play());
                }
                else
                {
                    Console.WriteLine("     | ------------------------------------------------------------------------------------------------");
                    Console.WriteLine("     | Player " + this.b_player.name + " can play.");
                    Console.WriteLine("     | Enter coordinates in the form of (x, y) to play : ");
                    while(!checkCoord) checkCoord = this.board.PutMark(a_player.GetCellState(), Play());
                }
                this.gameOver = Update();
            }
        }

        private (int, int) Play()
        {
            //works as well : (int cellInputI, int cellInputJ) = (int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.Write("     | coordinates : ");
            char[] inputs = Console.ReadLine().ToCharArray();
            int deltaValueFromKeys = 48;
            int cellInputI, cellInputJ = -1;

            try
            {
                (cellInputI, cellInputJ) = (Convert.ToInt32((inputs.GetValue(1))) - deltaValueFromKeys, Convert.ToInt32((inputs.GetValue(3))) - deltaValueFromKeys); 
            } 
            catch (Exception)
            {
                Console.WriteLine("     | The error was handled, those coordinates are impossible.");
                return Play();
            }

            if (cellInputI >= 0 && cellInputI < this.board.Size() &&
                cellInputJ >= 0 && cellInputJ < this.board.Size())
	        {
                this.turn += 1;
                return (cellInputI, cellInputJ);
	        }
            else return Play();
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
            //if     (EndGameDraw(this.board))        return this.gameOver = true;
            if(EndGameColumns(this.board))     return this.gameOver = true;
            //else if(EndGameDiagonals(this.board))   return this.gameOver = true;
            else if(EndGameRows(this.board))        return this.gameOver = true;
            else return false;
        }

        public bool EndGameDraw(Board board)
        {
            bool check = false;
            foreach (Cell cell in board.boardGame)
            {
                if (cell.GetCellState() == CellState.E)
                {
                    Console.WriteLine(cell.GetCellState().ToString());
                    check = false;
                    break;
                }
                else
                { 
                    check = true; 
                }
            }
            return check;
        }

        public bool EndGameRows(Board board)
        {
            bool check = false;
            for (int j = 0; j < board.Size()-1; j++)
            {
                for (int i = 0; i < board.Size()-1; i++)
			    {
                    if (board.boardGame[i, j].GetCellState() != CellState.E &&
                        board.boardGame[i, j].GetCellState() == board.boardGame[i, j+1].GetCellState())
                    {
                        Console.WriteLine("Rows win" + board.Size());
                        check = true;
                    }
                    else 
                    {
                        check = false;
                        break;
                    }
			    }
            }
            return check;
        }
        
        public bool EndGameColumns(Board board)
        {
            bool check = false;
            for (int i = 0; i < board.Size(); ++i)
            {
                for (int j = 0; j < board.Size(); ++j)
			    {
                    if(i+1 == this.board.Size())
                    {
                        Console.WriteLine("(i,j):" + i + ", " + j + "== (i:" + i + ", j-1:" +  (j-1)  + ")" +
                            (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == board.boardGame[i, j-1].GetCellState()));
                        if (board.boardGame[i, j].GetCellState() != CellState.E &&
                            board.boardGame[i, j].GetCellState() == board.boardGame[i, j-1].GetCellState())
                        {
                            Console.WriteLine("Columns win");
                            check = true;
                        }
                    }
                    else if(i+1 < this.board.Size())
                    {
                        Console.WriteLine("(i,j):" + i + ", " + j + "== (i+1:" + (i+1) + ", j:" +  j  + ")" + 
                            (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == board.boardGame[i, j+1].GetCellState()));
                        if (board.boardGame[i, j].GetCellState() != CellState.E &&
                            board.boardGame[i, j].GetCellState() == board.boardGame[i, j+1].GetCellState())
                        {
                            Console.WriteLine("Columns win");
                            check = true;
                        }
                    }
                    else check = false;
			    }
                Console.WriteLine("Check : " + check);
            }
            return check;
        }

        public bool EndGameDiagonals(Board board)
        {
            bool check = false;
            for (int i = 0, j = 0; i < board.Size()-1; i++, j++)
            {
                if (board.boardGame[i, j].GetCellState() != CellState.E && 
                    board.boardGame[i, j].GetCellState() == board.boardGame[i+1, j+1].GetCellState())
                {
                    Console.WriteLine("Diagonal win");
                    check = true;
                }
                else 
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
    }
}