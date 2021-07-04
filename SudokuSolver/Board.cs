using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public class Board
    {
        private readonly int[,] _matrix;
        public void SetValue(int number, Tuple<int, int> position)
        {
            var (x, y) = position;
            _matrix[x, y] = number;
            _buttons[x, y].Text = number.ToString();

        }
        public int[,] GetMatrix() => _matrix;

        private readonly Button[,] _buttons = new Button[9, 9];
        private const int CellSize = 48;
        private static readonly char[] ValidKeys = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        public Board()
        {
            _matrix = new[,]
            {
                { 5, 0, 0, 2, 0, 0, 0, 4, 0 },
                { 0, 0, 0, 6, 0, 3, 0, 0, 0 } ,
                { 0, 3, 0, 0, 0, 9, 0, 0, 7 } ,
                { 0, 0, 3, 0, 0, 7, 0, 0, 0 } ,
                { 0, 0, 7, 0, 0, 8, 0, 0, 0 } ,
                { 6, 0, 0, 0, 0, 0, 0, 2, 0 } ,
                { 0, 8, 0, 0, 0, 0, 0, 0, 3 } ,
                { 0, 0, 0, 4, 0, 0, 6, 0, 0 } ,
                { 0, 0, 0, 1, 0, 0, 5, 0, 0 }
            };
            CreateMap();
        }

        private void CreateMap()
        {
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    var btnCell = new Button
                    {
                        Name = $"{i},{j}",
                        Size = new Size(CellSize, CellSize),
                        Text = _matrix[i, j].ToString(),
                        Location = new Point(j * CellSize, i * CellSize)
                    }; 

                    btnCell.Font = new Font(btnCell.Font.FontFamily, 17);
                    btnCell.KeyPress += btnKeyPress;

                    _buttons[i, j] = btnCell;
                    Application.OpenForms["FormMain"].Controls.Add(btnCell);
                }
            }
        }

        public void btnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!ValidKeys.Contains(e.KeyChar)) return;

            var btnPressed = sender as Button;
            SetValue((int)char.GetNumericValue(e.KeyChar), new Tuple<int, int>(int.Parse(btnPressed.Name.Split(',')[0]), int.Parse(btnPressed.Name.Split(',')[1])));
        }

    }
}
