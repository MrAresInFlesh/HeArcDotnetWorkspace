using System;

namespace exercice1
{
    public class Game: I_EndGameConditions<Board>
    {
        private Board board;
        private Player a_player, b_player;
        private Boolean gameOver, victory;
        private int turn;

        /// <summary>
        /// Main class that contains the logic behind the tictactoe game.
        /// </summary>
        public Game()
        {
            Welcome();
            InitializePlayers();
            InitializeBoard();
            PlayGame();
        }

        public void Welcome()
        {
            Console.WriteLine("     #############################################################");
            Console.WriteLine("                 WELCOME TO THIS TICTACTOE GAME IN C# !");
            Console.WriteLine("     #############################################################");
        }

        public void InitializePlayers()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("     |\n     |       Enter name of player 1 : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string name = Console.ReadLine().ToString();
            this.a_player = new Player(name, CellState.O);
            Console.WriteLine("     |       Hello " + this.a_player.name + " !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("     |\n     |       Enter name of player 2 : ");
            Console.ForegroundColor = ConsoleColor.Green;
            name = Console.ReadLine().ToString();
            this.b_player = new Player(name, CellState.X);
            Console.WriteLine("     |       Hello " + this.b_player.name + " !");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void InitializeBoard()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            int size = 0;
            Console.Write("     |       Enter the size of Tic Tac Toe board [3~20]! :");
            size = int.Parse(Console.ReadLine());
            while (size > 20) 
            {
                Console.Write("     |       Enter the size of Tic Tac Toe board [3~20]! :");
                size = int.Parse(Console.ReadLine());
            }
            this.board = new Board(size); 
            this.board.Display();
        }

        /// <summary>
        /// Main Loop
        /// While the game continue, it should not end. (lol)
        /// </summary>
        public void PlayGame()
        {
            while(!this.gameOver)
            {
                this.turn = 1;
                this.victory = false;
                while (!this.victory)
                {
                    bool checkCoord = false;
                    if (this.turn % 2 == 0)
                    {
                        Console.WriteLine("     | ------------------------------------------------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("     | " + this.b_player.name + " can play.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     | Enter coordinates in the form of (x, y) to play :");
                        while (!checkCoord) checkCoord = this.board.PutMark(b_player.GetCellState(), Play());
                    }
                    else
                    {
                        Console.WriteLine("     | ------------------------------------------------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("     | " + this.a_player.name + " can play.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("     | Enter coordinates in the form of (x, y) to play : ");
                        while (!checkCoord) checkCoord = this.board.PutMark(a_player.GetCellState(), Play());
                    }
                    this.victory = Update();
                }
                Console.WriteLine("     | ------------------------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("     | " + this.a_player.name + " Score : " + this.a_player.GetScore());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("     | " + this.b_player.name + " Score : " + this.b_player.GetScore());
                Console.ForegroundColor = ConsoleColor.White;
                EndGame();
                if (!this.gameOver)
                {
                    InitializeBoard();
                }
            }
        }

        /// <summary>
        /// Called to play each turn for players.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// To end the game manually after a game.
        /// </summary>
        public void EndGame()
        {
            Console.Write("\n     | Press [q] to quit, or any other [key] to continue : ");
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                this.gameOver = true;
                this.victory = true;
            }
            Console.Clear();
            Console.WriteLine("     | ------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     | " + this.a_player.name + " Score : " + this.a_player.GetScore());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     | " + this.b_player.name + " Score : " + this.b_player.GetScore());
            Console.ForegroundColor = ConsoleColor.White;
            if (this.a_player.GetScore() < this.b_player.GetScore())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     | " + this.a_player.name + ", you loser.");
            }
            if (this.a_player.GetScore() > this.b_player.GetScore())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     | " + this.b_player.name + " ==  stupid stupid.");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Called to check on the victory conditions of the game.
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            board.Display();
            if(EndGameDraw(this.board)) return this.victory = true;
            if(EndGameColumns(this.board)) return this.victory = true;
            else if(EndGameDiagonals(this.board)) return this.victory = true;
            else if(EndGameRows(this.board)) return this.victory = true;
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
                    // debug: Console.WriteLine(cell.GetCellState().ToString());
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
                            // Console.WriteLine("x counter : " + xCounter);
                        }
                        // debug : Console.WriteLine(board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O);
                        if (board.boardGame[j, i].GetCellState() != CellState.E &&
                            board.boardGame[j, i].GetCellState() == CellState.O)
                        {
                            oCounter++;
                            // Console.WriteLine("o counter : " + oCounter);
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
                            // Console.WriteLine("x counter : " + xCounter);
                        }
                        // debug : Console.WriteLine(board.boardGame[i, j].GetCellState() != CellState.E && board.boardGame[i, j].GetCellState() == CellState.O);
                        if (board.boardGame[j, i].GetCellState() != CellState.E && board.boardGame[j, i].GetCellState() == CellState.O)
                        {
                            oCounter++;
                            // Console.WriteLine("o counter : " + oCounter);
                        }
                    }
                    else check = false;
                    if (oCounter >= this.board.Size())
                    {
                        check = true;
                        this.a_player.SetScore(1);
                    }
                    if (xCounter >= this.board.Size())
                    {
                        check = true;
                        this.b_player.SetScore(1);
                    }
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
                    if (oCounter >= this.board.Size())
                    {
                        check = true;
                        this.a_player.SetScore(1);
                    }
                    if (xCounter >= this.board.Size())
                    {
                        check = true;
                        this.b_player.SetScore(1);
                    }
                }
                // Console.WriteLine("Check : " + check);
            }
            return check;
        }

        /// <summary>
        /// Check if either player has a full diagonal of its symbol.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool EndGameDiagonals(Board board)
        {
            int xCounter = 0;
            int oCounter = 0;
            bool check = false;
            for (int i = 0, j = 0; i < board.Size()-1; i++, j++)
            {
                if (board.boardGame[i, j].GetCellState() != CellState.E && 
                    board.boardGame[i, j].GetCellState() == CellState.X)
                {
                    xCounter ++;
                }
                if (board.boardGame[i, j].GetCellState() != CellState.E &&
                    board.boardGame[i, j].GetCellState() == CellState.O)
                {
                    oCounter++;
                }
            }
            if (oCounter >= this.board.Size())
            {
                check = true;
                this.a_player.SetScore(1);
            }
            if (xCounter >= this.board.Size())
            {
                check = true;
                this.b_player.SetScore(1);
            }
            return check;
        }
    }
}