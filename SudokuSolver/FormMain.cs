using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class FormMain : Form
    {
        private GameSolver _gameSolver;
        private bool _isSolving; 
        public int[,] Board;


        public FormMain()
        {
            InitializeComponent();
            Board = new[,]
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };
        }

        public static string PrintBoard(int[,] board)
        {
            var result = new StringBuilder();
            for (var i = 0; i < 9; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    result.Append("---------------------------");
                    result.Append("\n");
                }
                for (var j = 0; j < 9; j++)
                {
                    if (j % 3 == 0 && j != 0)
                    {
                        result.Append("| ");
                    }
                    result.Append(board[i, j]);
                    result.Append(" ");
                }
                result.Append("\n");
            }

            return result.ToString();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            _gameSolver = new GameSolver();
            lblSudoku.Text = PrintBoard(Board);

        }

        private void lblSudoku_Click(object sender, EventArgs e)
        {

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!_isSolving)
            {
                new Thread(() =>
                {
                    _isSolving = true;
                    Thread.CurrentThread.IsBackground = true;
                    _gameSolver.Solve(Board);
                }).Start();
            }
            else
            {
                MessageBox.Show("Solve in progress!");
            }

        }
    }
}
