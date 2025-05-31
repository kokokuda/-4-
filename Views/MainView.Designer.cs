namespace MyShop
{
    partial class MainView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.dataGridViewCart = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCashBalance = new System.Windows.Forms.Label();
            this.lblCardBalance = new System.Windows.Forms.Label();
            this.lblBonusBalance = new System.Windows.Forms.Label();
            this.btnOpenSettings = new System.Windows.Forms.Button();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPayCash = new System.Windows.Forms.Button();
            this.btnPayCard = new System.Windows.Forms.Button();
            this.btnPayBonus = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(323, 42);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 24;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(355, 359);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // dataGridViewCart
            // 
            this.dataGridViewCart.AllowUserToAddRows = false;
            this.dataGridViewCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCart.Location = new System.Drawing.Point(716, 42);
            this.dataGridViewCart.Name = "dataGridViewCart";
            this.dataGridViewCart.ReadOnly = true;
            this.dataGridViewCart.RowHeadersWidth = 51;
            this.dataGridViewCart.RowTemplate.Height = 24;
            this.dataGridViewCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCart.Size = new System.Drawing.Size(365, 359);
            this.dataGridViewCart.TabIndex = 1;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Location = new System.Drawing.Point(436, 407);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(117, 64);
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.Text = "Добавить в корзину";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.Location = new System.Drawing.Point(716, 407);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(113, 64);
            this.btnRemoveFromCart.TabIndex = 3;
            this.btnRemoveFromCart.Text = "Удалить из корзины";
            this.btnRemoveFromCart.UseVisualStyleBackColor = true;
            // 
            // btnClearCart
            // 
            this.btnClearCart.Location = new System.Drawing.Point(847, 407);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(111, 64);
            this.btnClearCart.TabIndex = 4;
            this.btnClearCart.Text = "Очистить корзину";
            this.btnClearCart.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTotal.Location = new System.Drawing.Point(976, 433);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(105, 38);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Итого";
            // 
            // lblCashBalance
            // 
            this.lblCashBalance.AutoSize = true;
            this.lblCashBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCashBalance.Location = new System.Drawing.Point(12, 98);
            this.lblCashBalance.Name = "lblCashBalance";
            this.lblCashBalance.Size = new System.Drawing.Size(149, 32);
            this.lblCashBalance.TabIndex = 6;
            this.lblCashBalance.Text = "Наличные";
            // 
            // lblCardBalance
            // 
            this.lblCardBalance.AutoSize = true;
            this.lblCardBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCardBalance.Location = new System.Drawing.Point(12, 161);
            this.lblCardBalance.Name = "lblCardBalance";
            this.lblCardBalance.Size = new System.Drawing.Size(94, 32);
            this.lblCardBalance.TabIndex = 7;
            this.lblCardBalance.Text = "Карта";
            // 
            // lblBonusBalance
            // 
            this.lblBonusBalance.AutoSize = true;
            this.lblBonusBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBonusBalance.Location = new System.Drawing.Point(12, 222);
            this.lblBonusBalance.Name = "lblBonusBalance";
            this.lblBonusBalance.Size = new System.Drawing.Size(112, 32);
            this.lblBonusBalance.TabIndex = 8;
            this.lblBonusBalance.Text = "Бонусы";
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(18, 283);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.Size = new System.Drawing.Size(119, 60);
            this.btnOpenSettings.TabIndex = 12;
            this.btnOpenSettings.Text = "Настроить баланс";
            this.btnOpenSettings.UseVisualStyleBackColor = true;
            // 
            // labelRemaining
            // 
            this.labelRemaining.AutoSize = true;
            this.labelRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRemaining.Location = new System.Drawing.Point(720, 524);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(311, 38);
            this.labelRemaining.TabIndex = 13;
            this.labelRemaining.Text = "Осталось оплатить";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAmount.Location = new System.Drawing.Point(330, 556);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(223, 34);
            this.textBoxAmount.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 551);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 38);
            this.label1.TabIndex = 15;
            this.label1.Text = "Сколько списать:";
            // 
            // btnPayCash
            // 
            this.btnPayCash.Location = new System.Drawing.Point(18, 623);
            this.btnPayCash.Name = "btnPayCash";
            this.btnPayCash.Size = new System.Drawing.Size(119, 51);
            this.btnPayCash.TabIndex = 16;
            this.btnPayCash.Text = "Наличные";
            this.btnPayCash.UseVisualStyleBackColor = true;
            // 
            // btnPayCard
            // 
            this.btnPayCard.Location = new System.Drawing.Point(225, 623);
            this.btnPayCard.Name = "btnPayCard";
            this.btnPayCard.Size = new System.Drawing.Size(119, 51);
            this.btnPayCard.TabIndex = 17;
            this.btnPayCard.Text = "Карта";
            this.btnPayCard.UseVisualStyleBackColor = true;
            // 
            // btnPayBonus
            // 
            this.btnPayBonus.Location = new System.Drawing.Point(433, 623);
            this.btnPayBonus.Name = "btnPayBonus";
            this.btnPayBonus.Size = new System.Drawing.Size(119, 51);
            this.btnPayBonus.TabIndex = 18;
            this.btnPayBonus.Text = "Бонусы";
            this.btnPayBonus.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(835, 636);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(123, 38);
            this.labelStatus.TabIndex = 19;
            this.labelStatus.Text = "Статус";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 705);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnPayBonus);
            this.Controls.Add(this.btnPayCard);
            this.Controls.Add(this.btnPayCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.btnOpenSettings);
            this.Controls.Add(this.lblBonusBalance);
            this.Controls.Add(this.lblCardBalance);
            this.Controls.Add(this.lblCashBalance);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnClearCart);
            this.Controls.Add(this.btnRemoveFromCart);
            this.Controls.Add(this.btnAddToCart);
            this.Controls.Add(this.dataGridViewCart);
            this.Controls.Add(this.dataGridViewProducts);
            this.Name = "MainView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.DataGridView dataGridViewCart;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCashBalance;
        private System.Windows.Forms.Label lblCardBalance;
        private System.Windows.Forms.Label lblBonusBalance;
        private System.Windows.Forms.Button btnOpenSettings;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPayCash;
        private System.Windows.Forms.Button btnPayCard;
        private System.Windows.Forms.Button btnPayBonus;
        private System.Windows.Forms.Label labelStatus;
    }
}

