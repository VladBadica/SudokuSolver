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
        private bool _isSolving; 

        public FormMain()
        {
            InitializeComponent();
        }

        
        private void FormMain_Load(object sender, EventArgs e)
        {
            _board = new Board();

        }

        private void BtnSolve_Click(object sender, EventArgs e)
        {
            if (!_isSolving)
            {
                new Thread(() =>
                {
                    _isSolving = true;
                    Thread.CurrentThread.IsBackground = true;
                    _board.Solve();
                }).Start();
            }
            else
            {
                MessageBox.Show("Solve in progress!");
            }
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["OptionsForm"] == null)
            {
                var form = new OptionsForm();
                form.Show();
            }
        }
        
    }
}
