namespace InterpolationApp6
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
            this.intGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.intGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // intGridView
            // 
            this.intGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.intGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.intGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.intGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.ValueColumn,
            this.ErrorColumn});
            this.intGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.intGridView.Location = new System.Drawing.Point(0, 0);
            this.intGridView.Name = "intGridView";
            this.intGridView.Size = new System.Drawing.Size(800, 144);
            this.intGridView.TabIndex = 2;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Method";
            this.NameColumn.Name = "NameColumn";
            // 
            // ValueColumn
            // 
            this.ValueColumn.HeaderText = "Integral value";
            this.ValueColumn.Name = "ValueColumn";
            // 
            // ErrorColumn
            // 
            this.ErrorColumn.HeaderText = "Error";
            this.ErrorColumn.Name = "ErrorColumn";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 144);
            this.Controls.Add(this.intGridView);
            this.Name = "MainForm";
            this.Text = "Integrals calculation based on numerical analysis methods";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.intGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView intGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorColumn;
    }
}

