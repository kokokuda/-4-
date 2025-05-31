using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShop.Views
{
    public partial class BuyerSettingsForm : Form, IBuyerSettingsView
    {
        // Свойство для получения значения из поля "Наличные"
        public decimal CashAmount => nudCash.Value;

        // Свойство для получения значения из поля "Карта"
        public decimal CardAmount => nudCard.Value;

        // Свойство для получения значения из поля "Бонусы"
        public decimal BonusAmount => nudBonus.Value;

        // Событие, которое будет вызвано при нажатии кнопки "Применить"
        public event EventHandler ApplyClicked;

        public BuyerSettingsForm()
        {
            InitializeComponent();

            // Подписка на нажатие кнопки — вызывает событие ApplyClicked,
            // которое будет обработано в презентере
            btnApply.Click += (s, e) => ApplyClicked?.Invoke(this, EventArgs.Empty);
        }

        // Метод для закрытия формы из презентера
        public void CloseForm() => this.Close();
    }

}
