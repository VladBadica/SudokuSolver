using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public class Board
    {
        private readonly int[,] _matrix;
        public void SetValue(int number, Tuple<int, int> position)
        {
            if (CheckValid(_matrix, number, position))
            {
                var (x, y) = position;
                _matrix[x, y] = number;
                _buttons[x, y].Text = number == 0 ? "" : number.ToString();
                _buttons[x, y].ForeColor = Color.Black;

                if (IsSolved())
                {
                    MessageBox.Show("Well done, you solved it!");
                }

            }
            else
            {
                var (x, y) = position;
                _matrix[x, y] = number;
                _buttons[x, y].Text = number == 0 ? "" : number.ToString();
                _buttons[x, y].ForeColor = Color.Red;
            }
        }
        public void DirectSet(int number, Tuple<int, int> position)
        {
            var (x, y) = position;
            _matrix[x, y] = number;
            _buttons[x, y].Text = number == 0 ? "" : number.ToString();
            _buttons[x, y].ForeColor = Color.Black;
        }
        public int[,] GetMatrix() => _matrix;

        private readonly Button[,] _buttons = new Button[9, 9];
        private const int CellSize = 48;
        private static readonly int[] ValidKeys = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public Board()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _matrix = new[,]
            {
                { 0, 9, 0, 0, 3, 0, 0, 0, 6 },
                { 0, 3, 0, 0, 6, 8, 7, 0, 1 } ,
                { 0, 6, 7, 5, 0, 2, 4, 0, 0 } ,
                { 9, 4, 0, 6, 8, 1, 0, 7, 0 } ,
                { 5, 0, 6, 0, 0, 0, 0, 0, 4 } ,
                { 0, 0, 0, 0, 5, 0, 2, 0, 0 } ,
                { 6, 0, 8, 2, 1, 3, 0, 4, 7 } ,
                { 7, 2, 9, 0, 4, 6, 0, 5, 3 } ,
                { 0, 1, 0, 0, 0, 0, 0, 8, 2 }
            };
            CreateMap();
        }

        private void CreateMap()
        {
            var offSetY = 0;
            for (var i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    offSetY += 10;
                }
                var offSetX = 0;
                for (var j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        offSetX += 10;
                    }

                    var cellX = offSetX + 50 + j * CellSize;
                    var cellY = offSetY +  80 + i * CellSize;
                    
                    var btnCell = new Button
                    {
                        Name = $"{i},{j}",
                        Size = new Size(CellSize, CellSize),
                        Text = _matrix[i, j] == 0 ? "" : _matrix[i, j].ToString(),
                        Location = new Point(cellX, cellY)
                    }; 

                    btnCell.Font = new Font(btnCell.Font.FontFamily, 17);
                    btnCell.KeyDown += BtnKeyPress;

                    _buttons[i, j] = btnCell;
                    Application.OpenForms["FormMain"].Controls.Add(btnCell);
                }
            }
        }

        public void BtnKeyPress(object sender, KeyEventArgs e)
        {
            var btnPressed = sender as Button;
            if (ValidKeys.Contains(e.KeyValue))
            {
                SetValue((int)char.GetNumericValue((char)e.KeyValue), new Tuple<int, int>(int.Parse(btnPressed.Name.Split(',')[0]), int.Parse(btnPressed.Name.Split(',')[1])));
            }
            else if(e.KeyCode == Keys.Back)
            {
                SetValue(0, new Tuple<int, int>(int.Parse(btnPressed.Name.Split(',')[0]), int.Parse(btnPressed.Name.Split(',')[1])));
            }

        }

        public bool CheckValid(int[,] board, int number, Tuple<int, int> position)
        {
            if (number == 0)
            {
                return true;
            }
            
            // Check columns
            for (var i = 0; i < 9; i++)
            {
                if (board[i, position.Item2] == number && i != position.Item1)
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

            for (var i = boxStartX; i < boxStartX + 3; i++)
            {
                for (var j = boxStartY; j < boxStartY + 3; j++)
                {
                    if (board[i, j] == number && i != position.Item1 && j != position.Item2)
                    {
                        return false;
                    }
                }
            }

            if (bool.Parse(ConfigurationManager.AppSettings.Get("DiagonalRules")))
            {
                for (var i = 0; i < 9; i++)
                {
                    if (board[i, i] == number && position.Item1 == position.Item2)
                    {
                        return false;
                    }
                }

                for (var i = 0; i < 9; i++)
                {
                    if (board[i, 8 - i] == number && position.Item1 + position.Item2 == 8)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        public Tuple<int, int> FindEmpty(int[,] board)
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (board[i, j] == 0)
                        return new Tuple<int, int>(i, j);
                }
            }

            return null;
        }

        public bool IsSolved()
        {
            if (FindEmpty(_matrix) == null)
            {
                return true;
            }

            return false;
        }

        public bool Solve()
        {
            Thread.Sleep(50);

            var find = FindEmpty(GetMatrix());
            if (find == null)
            {
                MessageBox.Show("Solution Found");
                return true;
            }

            for (var i = 1; i <= 9; i++)
            {
                if (CheckValid(GetMatrix(), i, find))
                {
                    DirectSet(i, find);

                    if (Solve())
                    {
                        return true;
                    }

                }
                SetValue(0, find);
            }

            return false;
        }

    }
}
