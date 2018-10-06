namespace InterpolaionApp3
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
            this.RootsGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IndexColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntervalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewtonValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewtonIterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Newton2ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Newton2IterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecantValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecantIterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.RootsGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RootsGrid
            // 
            this.RootsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RootsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RootsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IndexColumn,
            this.IntervalColumn,
            this.NewtonValueColumn,
            this.NewtonIterColumn,
            this.Newton2ValueColumn,
            this.Newton2IterColumn,
            this.SecantValueColumn,
            this.SecantIterColumn});
            this.RootsGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RootsGrid.Location = new System.Drawing.Point(0, 98);
            this.RootsGrid.Name = "RootsGrid";
            this.RootsGrid.ReadOnly = true;
            this.RootsGrid.Size = new System.Drawing.Size(800, 352);
            this.RootsGrid.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Уравнение: ctg(x) - 2x^2 = 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Найти первые три положительных корня";
            // 
            // IndexColumn
            // 
            this.IndexColumn.HeaderText = "#";
            this.IndexColumn.Name = "IndexColumn";
            this.IndexColumn.ReadOnly = true;
            // 
            // IntervalColumn
            // 
            this.IntervalColumn.HeaderText = "interval";
            this.IntervalColumn.Name = "IntervalColumn";
            this.IntervalColumn.ReadOnly = true;
            // 
            // NewtonValueColumn
            // 
            this.NewtonValueColumn.HeaderText = "newton";
            this.NewtonValueColumn.Name = "NewtonValueColumn";
            this.NewtonValueColumn.ReadOnly = true;
            // 
            // NewtonIterColumn
            // 
            this.NewtonIterColumn.HeaderText = "newton iter";
            this.NewtonIterColumn.Name = "NewtonIterColumn";
            this.NewtonIterColumn.ReadOnly = true;
            // 
            // Newton2ValueColumn
            // 
            this.Newton2ValueColumn.HeaderText = "newton2";
            this.Newton2ValueColumn.Name = "Newton2ValueColumn";
            this.Newton2ValueColumn.ReadOnly = true;
            // 
            // Newton2IterColumn
            // 
            this.Newton2IterColumn.HeaderText = "newton2 iter";
            this.Newton2IterColumn.Name = "Newton2IterColumn";
            this.Newton2IterColumn.ReadOnly = true;
            // 
            // SecantValueColumn
            // 
            this.SecantValueColumn.HeaderText = "secant";
            this.SecantValueColumn.Name = "SecantValueColumn";
            this.SecantValueColumn.ReadOnly = true;
            // 
            // SecantIterColumn
            // 
            this.SecantIterColumn.HeaderText = "secant iter";
            this.SecantIterColumn.Name = "SecantIterColumn";
            this.SecantIterColumn.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Интервал:  [0, 10]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RootsGrid);
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RootsGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView RootsGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndexColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntervalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewtonValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewtonIterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Newton2ValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Newton2IterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecantValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecantIterColumn;
        private System.Windows.Forms.Label label3;
    }
}

