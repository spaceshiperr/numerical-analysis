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
            ((System.ComponentModel.ISupportInitialize)(this.DerivativeGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DerivativeGrid
            // 
            this.DerivativeGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.ColumnFNumError3});
            this.DerivativeGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.DerivativeGrid.Location = new System.Drawing.Point(0, 0);
            this.DerivativeGrid.Name = "DerivativeGrid";
            this.DerivativeGrid.Size = new System.Drawing.Size(800, 224);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DerivativeGrid);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DerivativeGrid)).EndInit();
            this.ResumeLayout(false);

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
    }
}

