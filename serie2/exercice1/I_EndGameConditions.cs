using System;

namespace exercice1
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Board"></typeparam>
    public interface I_EndGameConditions<Board>
    {
        public bool EndGameDraw(Board board);
        public bool EndGameColumns(Board board);
        public bool EndGameRows(Board board);
        public bool EndGameDiagonals(Board board);
    }
}
