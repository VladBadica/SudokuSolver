using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class GameEngine
    {
        public int[,] Board;

        public GameEngine()
        {
            Board = new int[9,9];
        }

        public String PrintBoard()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    result.Append("---------------------------");
                    result.Append("\n");
                }
                for (int j = 0; j < 9; j++)
                {
                    if(j % 3 == 0 && j != 0)
                    {
                        result.Append("| ");
                    }
                    result.Append(Board[i, j]);
                    result.Append(" ");
                }
                result.Append("\n");
            }

            return result.ToString();
        }
    }
}
