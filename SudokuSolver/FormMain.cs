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
        private Board _board;
        private GameSolver _gameSolver;
        private bool _isSolving; 

        public FormMain()
        {
            InitializeComponent();
        }

        
        private void FormMain_Load(object sender, EventArgs e)
        {
            _board = new Board();
            _gameSolver = new GameSolver();

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (!_isSolving)
            {
                new Thread(() =>
                {
                    _isSolving = true;
                    Thread.CurrentThread.IsBackground = true;
                    _gameSolver.Solve(_board);
                }).Start();
            }
            else
            {
                MessageBox.Show("Solve in progress!");
            }
        }

    }
}
