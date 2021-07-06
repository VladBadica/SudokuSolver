
namespace SudokuSolver
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkboxDiagonalRules = new System.Windows.Forms.CheckBox();
            this.lblDeco = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkboxDiagonalRules
            // 
            this.chkboxDiagonalRules.AutoSize = true;
            this.chkboxDiagonalRules.Location = new System.Drawing.Point(12, 66);
            this.chkboxDiagonalRules.Name = "chkboxDiagonalRules";
            this.chkboxDiagonalRules.Size = new System.Drawing.Size(120, 17);
            this.chkboxDiagonalRules.TabIndex = 0;
            this.chkboxDiagonalRules.Text = "Add Diagonal Rules";
            this.chkboxDiagonalRules.UseVisualStyleBackColor = true;
            this.chkboxDiagonalRules.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // lblDeco
            // 
            this.lblDeco.AutoSize = true;
            this.lblDeco.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeco.Location = new System.Drawing.Point(126, 9);
            this.lblDeco.Name = "lblDeco";
            this.lblDeco.Size = new System.Drawing.Size(72, 23);
            this.lblDeco.TabIndex = 1;
            this.lblDeco.Text = "Options";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 450);
            this.Controls.Add(this.lblDeco);
            this.Controls.Add(this.chkboxDiagonalRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkboxDiagonalRules;
        private System.Windows.Forms.Label lblDeco;
    }
}