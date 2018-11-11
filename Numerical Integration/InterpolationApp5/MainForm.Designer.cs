namespace InterpolationApp5
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.MethodColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntergralSnDDiffColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RnColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.S2nColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntergralS2nDiffColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R2nColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RmainColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IAdjustedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntergralIAdjustedDiffColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.labelIntegral = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelIntegralFunction = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MethodColumn,
            this.SnColumn,
            this.IntergralSnDDiffColumn,
            this.RnColumn,
            this.S2nColumn,
            this.IntergralS2nDiffColumn,
            this.R2nColumn,
            this.RmainColumn,
            this.IAdjustedColumn,
            this.IntergralIAdjustedDiffColumn});
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGrid.Size = new System.Drawing.Size(957, 110);
            this.dataGrid.TabIndex = 0;
            // 
            // MethodColumn
            // 
            this.MethodColumn.HeaderText = "Метод";
            this.MethodColumn.Name = "MethodColumn";
            // 
            // SnColumn
            // 
            this.SnColumn.HeaderText = "Sn";
            this.SnColumn.Name = "SnColumn";
            // 
            // IntergralSnDDiffColumn
            // 
            this.IntergralSnDDiffColumn.HeaderText = "I - Sn";
            this.IntergralSnDDiffColumn.Name = "IntergralSnDDiffColumn";
            // 
            // RnColumn
            // 
            this.RnColumn.HeaderText = "Rn";
            this.RnColumn.Name = "RnColumn";
            // 
            // S2nColumn
            // 
            this.S2nColumn.HeaderText = "S2n";
            this.S2nColumn.Name = "S2nColumn";
            // 
            // IntergralS2nDiffColumn
            // 
            this.IntergralS2nDiffColumn.HeaderText = "I - S2n";
            this.IntergralS2nDiffColumn.Name = "IntergralS2nDiffColumn";
            // 
            // R2nColumn
            // 
            this.R2nColumn.HeaderText = "R2n";
            this.R2nColumn.Name = "R2nColumn";
            // 
            // RmainColumn
            // 
            this.RmainColumn.HeaderText = "Rmain";
            this.RmainColumn.Name = "RmainColumn";
            // 
            // IAdjustedColumn
            // 
            this.IAdjustedColumn.HeaderText = "Iad";
            this.IAdjustedColumn.Name = "IAdjustedColumn";
            // 
            // IntergralIAdjustedDiffColumn
            // 
            this.IntergralIAdjustedDiffColumn.HeaderText = "I - Iad";
            this.IntergralIAdjustedDiffColumn.Name = "IntergralIAdjustedDiffColumn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Integral exact value";
            // 
            // labelIntegral
            // 
            this.labelIntegral.AutoSize = true;
            this.labelIntegral.Location = new System.Drawing.Point(144, 167);
            this.labelIntegral.Name = "labelIntegral";
            this.labelIntegral.Size = new System.Drawing.Size(0, 13);
            this.labelIntegral.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Integral";
            // 
            // labelIntegralFunction
            // 
            this.labelIntegralFunction.AutoSize = true;
            this.labelIntegralFunction.Location = new System.Drawing.Point(144, 138);
            this.labelIntegralFunction.Name = "labelIntegralFunction";
            this.labelIntegralFunction.Size = new System.Drawing.Size(0, 13);
            this.labelIntegralFunction.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 248);
            this.Controls.Add(this.labelIntegralFunction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelIntegral);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid);
            this.MaximumSize = new System.Drawing.Size(974, 287);
            this.MinimumSize = new System.Drawing.Size(974, 287);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Integrals";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn MethodColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntergralSnDDiffColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RnColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn S2nColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntergralS2nDiffColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn R2nColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RmainColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IAdjustedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntergralIAdjustedDiffColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIntegral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelIntegralFunction;
    }
}

