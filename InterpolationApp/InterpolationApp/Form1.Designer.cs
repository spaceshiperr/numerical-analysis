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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.diffTabPage = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pointValueGrid)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.diffTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Функция f(x) = sin(x), на отрезке [a, b] = [0.5, 1.5]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Точки интерполирования: x2 = 1.55, x3 = 1.05";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Шаг для узлов h = 0.1";
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
            this.pointValueGrid.Location = new System.Drawing.Point(17, 18);
            this.pointValueGrid.Name = "pointValueGrid";
            this.pointValueGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pointValueGrid.Size = new System.Drawing.Size(648, 315);
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
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.diffTabPage);
            this.MainTabControl.Controls.Add(this.tabPage2);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainTabControl.Location = new System.Drawing.Point(0, 67);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(681, 383);
            this.MainTabControl.TabIndex = 4;
            // 
            // diffTabPage
            // 
            this.diffTabPage.Controls.Add(this.pointValueGrid);
            this.diffTabPage.Location = new System.Drawing.Point(4, 22);
            this.diffTabPage.Name = "diffTabPage";
            this.diffTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.diffTabPage.Size = new System.Drawing.Size(673, 357);
            this.diffTabPage.TabIndex = 0;
            this.diffTabPage.Text = "Разности";
            this.diffTabPage.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 357);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 61);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Точность вычислений E = 1/2 * ((10)^-5)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainTabControl);
            this.Name = "MainForm";
            this.Text = "Interpolation App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pointValueGrid)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.diffTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage diffTabPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}

