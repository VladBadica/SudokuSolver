using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    public class GameSolver
    {      

        public int[,] Solve(int[,] board)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j< 9; j++)
                {
                    board[i, j] = 1;
                }
            }

            return board;
        }

        public Tuple<int, int> findEmpty(int[,] board)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                        return new Tuple<int, int>(i, j); 
                }
            }

           return new Tuple<int, int>(-1,-1);
        }

        public bool checkValid(int[,] board, int number, Tuple<int, int> position)
        {
            Console.WriteLine("AWDAW");
            // Check columns
            for (int i = 0; i< 9; i++)
            {
                if(board[i,position.Item2] == number && i != position.Item1)
                {
                    return false;
                }
            }

            //Check rows
            for (int j = 0; j < 9; j++)
            {
                if (board[position.Item1, j] == number && j != position.Item2)
                {
                    return false;
                }
            }

            //Check Box
            Tuple<int, int> boxStart = new Tuple<int, int>(position.Item1 / 3 * 3, position.Item2 / 3 * 3);

            for(int i = boxStart.Item1; i < boxStart.Item1+ 3; i++)
            {

                for (int j = boxStart.Item2; j < boxStart.Item2 + 3; j++)
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
