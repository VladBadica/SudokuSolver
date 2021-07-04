using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class FormMain : Form
    {
        private GameSolver gameSolver = null;
        private GameEngine gameEngine = null;
        public FormMain()
        {
            InitializeComponent();
            gameSolver = new GameSolver();
            gameEngine = new GameEngine();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblSudoku.Text = gameEngine.PrintBoard();

        }

        private void lblSudoku_Click(object sender, EventArgs e)
        {

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            gameEngine.Board = gameSolver.Solve(gameEngine.Board);
            lblSudoku.Text = gameEngine.PrintBoard();
        }
    }
}
