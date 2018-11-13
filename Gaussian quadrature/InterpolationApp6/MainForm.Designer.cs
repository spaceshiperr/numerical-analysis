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
            this.integralValueLabel = new System.Windows.Forms.Label();
            this.middleRectanglesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // integralValueLabel
            // 
            this.integralValueLabel.AutoSize = true;
            this.integralValueLabel.Location = new System.Drawing.Point(26, 24);
            this.integralValueLabel.Name = "integralValueLabel";
            this.integralValueLabel.Size = new System.Drawing.Size(74, 13);
            this.integralValueLabel.TabIndex = 0;
            this.integralValueLabel.Text = "Integral value:";
            // 
            // middleRectanglesLabel
            // 
            this.middleRectanglesLabel.AutoSize = true;
            this.middleRectanglesLabel.Location = new System.Drawing.Point(26, 54);
            this.middleRectanglesLabel.Name = "middleRectanglesLabel";
            this.middleRectanglesLabel.Size = new System.Drawing.Size(144, 13);
            this.middleRectanglesLabel.TabIndex = 1;
            this.middleRectanglesLabel.Text = "Integral by middle rectangles:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.middleRectanglesLabel);
            this.Controls.Add(this.integralValueLabel);
            this.Name = "MainForm";
            this.Text = "Integrals calculation based on numerical analysis methods";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label integralValueLabel;
        private System.Windows.Forms.Label middleRectanglesLabel;
    }
}

