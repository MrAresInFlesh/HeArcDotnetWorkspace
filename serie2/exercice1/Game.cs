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
            Console.WriteLine("\n       | Press [q] to quit");
            if(Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.Q)
                this.gameOver = true;
            }
        }

        /// <summary>
        /// Called to check on the victory conditions of the game.
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            board.Display();
            if(EndGameDraw(this.board)) return this.gameOver = true;
            if(EndGameColumns(this.board)) return this.gameOver = true;
            else if(EndGameDiagonals(this.board)) return this.gameOver = true;
            else if(EndGameRows(this.board)) return this.gameOver = true;
            else return false;
        }

        /// <summary>
        /// Check if each Cell in the board has a value. If it's true, then it's a draw.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Check for each columns if the victory condition is good. Meaning that there is n same symbols in the 
        /// same columns, with n being the size of the board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool EndGameColumns(Board board)
        {
            bool check = false;
            for (int i = 0; i < board.Size(); ++i)
            {
                int xCounter = 0;
                int oCounter = 0;
                for (int j = 0; j < board.Size(); ++j)
                {
                    if (j + 1 == board.Size())
                    {
                        // debug : Console.WriteLine("(i,j):" + i + ", " + j + " == (i:" + i + ", j-1: " +  j  + ")" +
                        // (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.X));
                        if (board.boardGame[j, i].GetCellState() != CellState.E && board.boardGame[j, i].GetCellState() == CellState.X)
                        {
                            xCounter++;
                            Console.WriteLine("x counter : " + xCounter);
                        }
                        // debug : Console.WriteLine(board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O);
                        if (board.boardGame[j, i].GetCellState() != CellState.E &&
                            board.boardGame[j, i].GetCellState() == CellState.O)
                        {
                            oCounter++;
                            Console.WriteLine("o counter : " + oCounter);
                        }
                    }
                    else if(j+1 < this.board.Size())
                    {
                        // debug : Console.WriteLine("(i,j):" + i + ", " + j + " == (i:" + i + ", j: " +  j  + ")" + 
                        // (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.X));
                        if (board.boardGame[j, i].GetCellState() != CellState.E &&
                            board.boardGame[j, i].GetCellState() == CellState.X)
                        {
                            xCounter++;
                            Console.WriteLine("x counter : " + xCounter);
                        }
                        // debug : Console.WriteLine(board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O);
                        if (board.boardGame[j, i].GetCellState() != CellState.E && board.boardGame[j, i].GetCellState() == CellState.O)
                        {
                            oCounter++;
                            Console.WriteLine("o counter : " + oCounter);
                        }
                    }
                    else check = false;
                    if (oCounter >= this.board.Size()) check = true;
                    if (xCounter >= this.board.Size()) check = true;
                }
                // Console.WriteLine("Check : " + check);
            }
            return check;
        }

        /// <summary>
        /// Check for each rows if the victory condition is good. Meaning that there is n same symbols in the
        /// same row, with n being the size of the board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool EndGameRows(Board board)
        {
            bool check = false;
            for (int i = 0; i < board.Size(); ++i)
            {
                int xCounter = 0;
                int oCounter = 0;
                for (int j = 0; j < board.Size(); ++j)
			    {
                    if (j+1 == board.Size())
                    {
                        // debug : Console.WriteLine("(i,j):" + i + ", " + j + " == (i:" + i + ", j-1: " +  j  + ")" +
                        // (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.X));
                        if (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.X)
                        {
                            xCounter++;
                            // debug : Console.WriteLine("x counter : " + xCounter);
                        }
                        // debug : Console.WriteLine(board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O);
                        if (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O)
                        {
                            oCounter++;
                            // debug :  Console.WriteLine("o counter : " + oCounter);
                        }
                    }
                    else if(j+1 < this.board.Size())
                    {
                        // debug : Console.WriteLine("(i,j):" + i + ", " + j + " == (i:" + i + ", j: " +  j  + ")" + 
                        // (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.X));
                        if (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.X)
                        {
                            xCounter++;
                            // debug : Console.WriteLine("x counter : " + xCounter);
                        }
                        // debug : Console.WriteLine(board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O);
                        if (board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O)
                        {
                            oCounter++;
                            // debug : Console.WriteLine("o counter : " + oCounter);
                        }
                    }
                    else check = false;
                    if (oCounter >= this.board.Size()) check = true;
                    if (xCounter >= this.board.Size()) check = true;
                }
                // Console.WriteLine("Check : " + check);
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