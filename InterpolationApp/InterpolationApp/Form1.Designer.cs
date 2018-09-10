namespace InterpolationApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pointValueGrid = new System.Windows.Forms.DataGridView();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Values = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deltaY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delta2Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delta3Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delta4Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pointValueGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x) = sin(x), [a, b] = [0.5, 1.5]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "x2 = 1.55, x3 = 1.05";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "h = 0.1, E = 1/2 * ((10)^-5)";
            // 
            // pointValueGrid
            // 
            this.pointValueGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointValueGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Points,
            this.Values,
            this.deltaY,
            this.delta2Y,
            this.delta3Y,
            this.delta4Y});
            this.pointValueGrid.Location = new System.Drawing.Point(21, 66);
            this.pointValueGrid.Name = "pointValueGrid";
            this.pointValueGrid.Size = new System.Drawing.Size(689, 332);
            this.pointValueGrid.TabIndex = 3;
            // 
            // Points
            // 
            this.Points.HeaderText = "x";
            this.Points.Name = "Points";
            // 
            // Values
            // 
            this.Values.HeaderText = "y";
            this.Values.Name = "Values";
            // 
            // deltaY
            // 
            this.deltaY.HeaderText = "Δ y";
            this.deltaY.Name = "deltaY";
            // 
            // delta2Y
            // 
            this.delta2Y.HeaderText = "Δ ² y";
            this.delta2Y.Name = "delta2Y";
            // 
            // delta3Y
            // 
            this.delta3Y.HeaderText = "Δ ³ y";
            this.delta3Y.Name = "delta3Y";
            // 
            // delta4Y
            // 
            this.delta4Y.HeaderText = "Δ ⁴ y";
            this.delta4Y.Name = "delta4Y";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pointValueGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Interpolation App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pointValueGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView pointValueGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Points;
        private System.Windows.Forms.DataGridViewTextBoxColumn Values;
        private System.Windows.Forms.DataGridViewTextBoxColumn deltaY;
        private System.Windows.Forms.DataGridViewTextBoxColumn delta2Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn delta3Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn delta4Y;
    }
}

