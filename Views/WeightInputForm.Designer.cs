namespace MyShop.Views
{
    partial class WeightInputForm
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
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.btnWeigh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.DecimalPlaces = 1;
            this.numericUpDownWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownWeight.Location = new System.Drawing.Point(328, 142);
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(136, 56);
            this.numericUpDownWeight.TabIndex = 0;
            // 
            // btnWeigh
            // 
            this.btnWeigh.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWeigh.Location = new System.Drawing.Point(279, 294);
            this.btnWeigh.Name = "btnWeigh";
            this.btnWeigh.Size = new System.Drawing.Size(237, 82);
            this.btnWeigh.TabIndex = 1;
            this.btnWeigh.Text = "Взвесить";
            this.btnWeigh.UseVisualStyleBackColor = true;
            this.btnWeigh.Click += new System.EventHandler(this.btnWeigh_Click);
            // 
            // WeightInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWeigh);
            this.Controls.Add(this.numericUpDownWeight);
            this.Name = "WeightInputForm";
            this.Text = "WeightInputForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.Button btnWeigh;
    }
}