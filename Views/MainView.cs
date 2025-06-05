    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MyShop.Models;
    using MyShop.Services;
    using MyShop.Views;
    using MyShop.Presenters;
    using System.Globalization;

namespace MyShop
    {
        public partial class MainView : Form, IMainView, ICartView
        {
            private MainPresenter presenter;

            // События из ICartView
            public event Action<Product, decimal> AddProductRequested;
            public event Action<CartItem> RemoveProductRequested;
            public event Action ClearCartRequested;


            // События из IMainView
            public event EventHandler OpenSettingsClicked;
            public event EventHandler AmountChanged;

            private CartPresenter cartPresenter;
            private Cart cart;

            private decimal totalBalance; // поле для общего баланса пользователя

            // Храним текущие элементы корзины, чтобы по индексу получать CartItem
            private IReadOnlyList<CartItem> cartItems;

            public MainView()
            {
                InitializeComponent();

                cart = new Cart();
                cartPresenter = new CartPresenter(this, cart);

                // Создаем презентер и передаем ему эту форму
                presenter = new MainPresenter(this);

                this.Load += MainView_Load;

                // Подпишемся на клики кнопок корзины:
                btnAddToCart.Click += BtnAddToCart_Click;
                btnRemoveFromCart.Click += BtnRemoveFromCart_Click;
                btnClearCart.Click += BtnClearCart_Click;

                // Подпишемся на настройку клиента
                btnOpenSettings.Click += (s, e) => OpenSettingsClicked?.Invoke(this, EventArgs.Empty);

                // Обработка кнопок оплаты
                btnPayCash.Click += BtnPayCash_Click;
                btnPayCard.Click += BtnPayCard_Click;
                btnPayBonus.Click += BtnPayBonus_Click;


                textBoxAmount.TextChanged += (s, e) => AmountChanged?.Invoke(this, EventArgs.Empty);

            AddProductRequested += (product, weight) =>
            {
                try
                {
                    presenter.Buyer.Cart.AddProduct(product, weight);
                    presenter.UpdateTotalToPayFromCart();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            RemoveProductRequested += item =>
            {
                presenter.Buyer.Cart.RemoveProduct(item);
                presenter.UpdateTotalToPayFromCart();
            };

            ClearCartRequested += () =>
            {
                presenter.Buyer.Cart.Clear();
                presenter.UpdateTotalToPayFromCart();
            };
        }

        private void MainView_Load(object sender, System.EventArgs e)
            {
                // При загрузке формы вызываем у презентера загрузку продуктов
                presenter.LoadProducts();
            }

            // Реализация интерфейсного метода — отображаем продукты в таблице
            public void DisplayProducts(List<Product> products)
            {
                dataGridViewProducts.AutoGenerateColumns = false;
                dataGridViewProducts.Columns.Clear();

                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Name",
                    HeaderText = "Название"
                });

                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Price",
                    HeaderText = "Цена"
                });

                dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Количество"
                });

                dataGridViewProducts.DataSource = products;
            }

            // Реализация методов ICartView

            public void DisplayCartItems(IReadOnlyList<CartItem> items)
            {
                // Сохраняем текущие элементы, чтобы по индексу получать CartItem
                cartItems = items;

                dataGridViewCart.AutoGenerateColumns = false;
                dataGridViewCart.Columns.Clear();

                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ProductName",
                    HeaderText = "Товар"
                });

                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Weight",
                    HeaderText = "Вес"
                });
                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Quantity",
                    HeaderText = "Количество"
                });

                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TotalPrice",
                        HeaderText = "Цена"
                    });
              

            dataGridViewCart.DataSource = null;
                dataGridViewCart.DataSource = items.Select(i => new
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Weight = i.Weight,
                    TotalPrice = i.TotalPrice
                }).ToList();
            }

            public void DisplayTotal(decimal totalPrice)
            {
                lblTotal.Text = $"Итого: {totalPrice} ₽";
            }

            // Обработчики кнопок корзины:

            private void BtnAddToCart_Click(object sender, EventArgs e)
            {
            if (dataGridViewProducts.CurrentRow == null)
                return;

            var product = (Product)dataGridViewProducts.CurrentRow.DataBoundItem;

            if (product == null)
                return;

            decimal weight = 1;

            if (product is WeightedProduct)
            {
                using (var weightForm = new WeightInputForm())
                {
                    if (weightForm.ShowDialog() == DialogResult.OK)
                    {
                        weight = weightForm.Weight;
                    }
                    else
                    {
                        return;
                    }
                }

                if (weight <= 0)
                {
                    MessageBox.Show("Вес должен быть больше 0.");
                    return;
                }
            }

            try
            {
                AddProductRequested?.Invoke(product, weight);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

            private void BtnRemoveFromCart_Click(object sender, EventArgs e)
            {
                if (dataGridViewCart.CurrentRow == null)
                    return;

                // Для удаления нам нужен объект CartItem, который не хранится напрямую в dataGridView.
                // Поэтому мы сохраняем текущий список элементов корзины в поле cartItems.
                // По индексу выбранной строки получаем нужный CartItem из cartItems и вызываем событие удаления.

                var index = dataGridViewCart.CurrentRow.Index;
                if (cartItems != null && index >= 0 && index < cartItems.Count)
                {
                    var item = cartItems[index];
                    RemoveProductRequested?.Invoke(item);
                }
            }

            private void BtnClearCart_Click(object sender, EventArgs e)
            {
                ClearCartRequested?.Invoke();
            }


            // Метод обновления баланса
            public void UpdateBalances(decimal cash, decimal card, decimal bonus)
            {
                lblCashBalance.Text = $"Наличные: {cash:C2}";
                lblCardBalance.Text = $"Карта: {card:C2}";
                lblBonusBalance.Text = $"Бонусы: {bonus:C2}";
            }

            // Метод для общего баланса пользователя
            public void UpdateTotalBalance(decimal totalBalance)
            {
                lblTotalBalance.Text = $"Общий баланс: {totalBalance:C2}";
            }


        private void TryPayWith(Func<decimal, ICommand> commandFactory)
        {

            if (presenter.Buyer.Cart.IsEmpty())
            {
                MessageBox.Show("Корзина пуста. Нечего оплачивать.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(textBoxAmount.Text, out decimal amount) && amount > 0)
            {
                try
                {
                    var command = commandFactory(amount);
                    presenter.ExecuteCommand(command, amount);
                    MessageBox.Show($"Оплата прошла успешно на сумму {amount:C2}", "Успех");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка оплаты: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректную сумму оплаты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BtnPayCash_Click(object sender, EventArgs e)
            {
                TryPayWith(amount =>
                    new PayByCashCommand(presenter.Buyer, amount));
            }

            private void BtnPayCard_Click(object sender, EventArgs e)
            {
                TryPayWith(amount =>
                    new PayByCardCommand(presenter.Buyer, amount));
            }

            private void BtnPayBonus_Click(object sender, EventArgs e)
            {
                TryPayWith(amount =>
                    new PayByBonusCommand(presenter.Buyer, amount));
            }

            public void UpdateRemaining(decimal remaining)
            {
                labelRemaining.Text = $"Осталось оплатить: {remaining} ₽";
            }


        public string GetEnteredAmount()
        {
            return textBoxAmount.Text;
        }


        public void UpdateStatus(string message)
        {
            labelStatus.Text = message;
        }

        public void LockPaymentButtons(bool locked)
        {
            btnPayCash.Enabled = !locked;
            btnPayCard.Enabled = !locked;
            btnPayBonus.Enabled = !locked;
        }

        public void ShowLowBalanceWarning()
        {
            MessageBox.Show("Недостаточно средств для оплаты всей корзины. Уберите товар.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



    }
}
