namespace MyShop.Views
{
    partial class BuyerSettingsForm
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
            this.nudCash = new System.Windows.Forms.NumericUpDown();
            this.nudCard = new System.Windows.Forms.NumericUpDown();
            this.nudBonus = new System.Windows.Forms.NumericUpDown();
            this.btnApply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonus)).BeginInit();
            this.SuspendLayout();
            // 
            // nudCash
            // 
            this.nudCash.DecimalPlaces = 2;
            this.nudCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudCash.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudCash.Location = new System.Drawing.Point(201, 41);
            this.nudCash.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCash.Name = "nudCash";
            this.nudCash.Size = new System.Drawing.Size(120, 38);
            this.nudCash.TabIndex = 0;
            // 
            // nudCard
            // 
            this.nudCard.DecimalPlaces = 2;
            this.nudCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudCard.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudCard.Location = new System.Drawing.Point(201, 100);
            this.nudCard.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudCard.Name = "nudCard";
            this.nudCard.Size = new System.Drawing.Size(120, 38);
            this.nudCard.TabIndex = 1;
            // 
            // nudBonus
            // 
            this.nudBonus.DecimalPlaces = 2;
            this.nudBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudBonus.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBonus.Location = new System.Drawing.Point(201, 161);
            this.nudBonus.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudBonus.Name = "nudBonus";
            this.nudBonus.Size = new System.Drawing.Size(120, 38);
            this.nudBonus.TabIndex = 2;
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnApply.Location = new System.Drawing.Point(87, 237);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(182, 50);
            this.btnApply.TabIndex = 3;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Наличные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Карта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(27, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Бонусы";
            // 
            // BuyerSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 321);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.nudBonus);
            this.Controls.Add(this.nudCard);
            this.Controls.Add(this.nudCash);
            this.Name = "BuyerSettingsForm";
            this.Text = "BuyerSettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBonus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudCash;
        private System.Windows.Forms.NumericUpDown nudCard;
        private System.Windows.Forms.NumericUpDown nudBonus;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}