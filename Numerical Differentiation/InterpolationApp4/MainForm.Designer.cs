namespace InterpolationApp4
{
    partial class MainForm
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
            this.DerivativeGrid = new System.Windows.Forms.DataGridView();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFDerivative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFNum1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFNumError1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFNum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFNumError2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFNum3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFNumError3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpectedStepColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObservedStepColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DerivativeGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DerivativeGrid
            // 
            this.DerivativeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DerivativeGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.DerivativeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DerivativeGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnF,
            this.ColumnFDerivative,
            this.ColumnFNum1,
            this.ColumnFNumError1,
            this.ColumnFNum2,
            this.ColumnFNumError2,
            this.ColumnFNum3,
            this.ColumnFNumError3,
            this.MaxError,
            this.ExpectedStepColumn,
            this.ObservedStepColumn});
            this.DerivativeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DerivativeGrid.Location = new System.Drawing.Point(0, 24);
            this.DerivativeGrid.Name = "DerivativeGrid";
            this.DerivativeGrid.Size = new System.Drawing.Size(1055, 261);
            this.DerivativeGrid.TabIndex = 0;
            // 
            // ColumnX
            // 
            this.ColumnX.HeaderText = "x";
            this.ColumnX.Name = "ColumnX";
            // 
            // ColumnF
            // 
            this.ColumnF.HeaderText = "f(x)";
            this.ColumnF.Name = "ColumnF";
            // 
            // ColumnFDerivative
            // 
            this.ColumnFDerivative.HeaderText = "f\'(x)";
            this.ColumnFDerivative.Name = "ColumnFDerivative";
            // 
            // ColumnFNum1
            // 
            this.ColumnFNum1.HeaderText = "f\'(x) right";
            this.ColumnFNum1.Name = "ColumnFNum1";
            // 
            // ColumnFNumError1
            // 
            this.ColumnFNumError1.HeaderText = "O(h)";
            this.ColumnFNumError1.Name = "ColumnFNumError1";
            // 
            // ColumnFNum2
            // 
            this.ColumnFNum2.HeaderText = "f\'(x) both";
            this.ColumnFNum2.Name = "ColumnFNum2";
            // 
            // ColumnFNumError2
            // 
            this.ColumnFNumError2.HeaderText = "O(h^2)";
            this.ColumnFNumError2.Name = "ColumnFNumError2";
            // 
            // ColumnFNum3
            // 
            this.ColumnFNum3.HeaderText = "f\'(x) left";
            this.ColumnFNum3.Name = "ColumnFNum3";
            // 
            // ColumnFNumError3
            // 
            this.ColumnFNumError3.HeaderText = "O(h)";
            this.ColumnFNumError3.Name = "ColumnFNumError3";
            // 
            // MaxError
            // 
            this.MaxError.HeaderText = "max O(h)";
            this.MaxError.Name = "MaxError";
            // 
            // ExpectedStepColumn
            // 
            this.ExpectedStepColumn.HeaderText = "expected h";
            this.ExpectedStepColumn.Name = "ExpectedStepColumn";
            // 
            // ObservedStepColumn
            // 
            this.ObservedStepColumn.HeaderText = "observed h";
            this.ObservedStepColumn.Name = "ObservedStepColumn";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.AboutToolStripMenuItem.Text = "О программе";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 285);
            this.Controls.Add(this.DerivativeGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DerivativeGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DerivativeGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFDerivative;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFNum1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFNumError1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFNum2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFNumError2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFNum3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFNumError3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxError;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpectedStepColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObservedStepColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
    }
}

