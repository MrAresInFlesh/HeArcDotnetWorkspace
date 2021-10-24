using System;

namespace exercice1
{
    public class SceneRenderer: I_EndGameConditions<Board>
    {
        public SceneRenderer()
        {
            
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
            for (int j = 0; j < board.size(); j++)
            {
                for (int i = 0; i < board.size(); i++)
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
            for (int i = 0; i < board.size(); i++)
            {
                for (int j = 0; j < board.size(); j++)
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
            for (int i = 0, j = 0; i < board.size(); i++, j++)
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