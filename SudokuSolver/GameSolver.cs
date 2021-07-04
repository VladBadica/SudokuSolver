using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public class GameSolver
    {
        private readonly Label _lblSudoku;

        public GameSolver()
        {
            _lblSudoku = (Label)Application.OpenForms["FormMain"].Controls.Find("lblSudoku", false).FirstOrDefault();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public bool Solve(Board board)
        {
           // Thread.Sleep(1);
            
            var find = FindEmpty(board.GetMatrix());
            if (find == null)
            {
                return true;
            }

            for (var i = 1; i <= 9; i++)
            {
                if (CheckValid(board.GetMatrix(), i, find))
                {
                    board.SetValue(i, find);

                    if (Solve(board))
                    {
                        return true;
                    }

                }

                board.SetValue(0, find);

            }

            return false;
        }

        public Tuple<int, int> FindEmpty(int[,] board)
        {
            for(var i = 0; i < 9; i++)
            {
                for(var j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                        return new Tuple<int, int>(i, j); 
                }
            }

            return null;
        }

        public bool CheckValid(int[,] board, int number, Tuple<int, int> position)
        {
            // Check columns
            for (var i = 0; i< 9; i++)
            {
                if(board[i,position.Item2] == number && i != position.Item1)
                {
                    return false;
                }
            }

            //Check rows
            for (var j = 0; j < 9; j++)
            {
                if (board[position.Item1, j] == number && j != position.Item2)
                {
                    return false;
                }
            }

            //Check Box
            var (boxStartX, boxStartY) = new Tuple<int, int>(position.Item1 / 3 * 3, position.Item2 / 3 * 3);

            for(var i = boxStartX; i < boxStartX + 3; i++)
            {
                for (var j = boxStartY; j < boxStartY + 3; j++)
                {
                    if(board[i,j] == number && i != position.Item1 && j != position.Item2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
