using System;
using System.Configuration;
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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            chkboxDiagonalRules.Checked = bool.Parse(ConfigurationManager.AppSettings.Get("DiagonalRules"));
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(
                ConfigurationUserLevel.None);
            ConfigurationManager.AppSettings.Set("DiagonalRules", chkboxDiagonalRules.Checked.ToString());
            config.AppSettings.Settings.Add("DiagonalRules", chkboxDiagonalRules.Checked.ToString());
        }
    }
}
