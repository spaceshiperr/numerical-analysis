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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
    }
}

