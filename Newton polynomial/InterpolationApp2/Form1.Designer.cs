namespace InterpolationApp2
{
    partial class Form1
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
            this.diffGrid = new System.Windows.Forms.DataGridView();
            this.ColumnX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiff1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiff2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.ColumnI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.diffGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // diffGrid
            // 
            this.diffGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.diffGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.diffGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnX,
            this.ColumnF,
            this.ColumnDiff1,
            this.ColumnDiff2,
            this.Column3});
            this.diffGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.diffGrid.Location = new System.Drawing.Point(0, 0);
            this.diffGrid.Name = "diffGrid";
            this.diffGrid.Size = new System.Drawing.Size(800, 235);
            this.diffGrid.TabIndex = 0;
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
            // ColumnDiff1
            // 
            this.ColumnDiff1.HeaderText = "р.р. 1-го п.";
            this.ColumnDiff1.Name = "ColumnDiff1";
            // 
            // ColumnDiff2
            // 
            this.ColumnDiff2.HeaderText = "р.р. 2-го п.";
            this.ColumnDiff2.Name = "ColumnDiff2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "р.р. 3-го п.";
            this.Column3.Name = "Column3";
            // 
            // resultGrid
            // 
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnI,
            this.Column0,
            this.Column1,
            this.Column2,
            this.Column4});
            this.resultGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.resultGrid.Location = new System.Drawing.Point(0, 241);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.Size = new System.Drawing.Size(800, 161);
            this.resultGrid.TabIndex = 1;
            // 
            // ColumnI
            // 
            this.ColumnI.HeaderText = "i";
            this.ColumnI.Name = "ColumnI";
            // 
            // Column0
            // 
            this.Column0.HeaderText = "0";
            this.Column0.Name = "Column0";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "2";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "3";
            this.Column4.Name = "Column4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.diffGrid);
            this.Name = "Form1";
            this.Text = "Интерполяционный многочлен в форме Ньютона";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.diffGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView diffGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnX;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiff1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiff2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView resultGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}

