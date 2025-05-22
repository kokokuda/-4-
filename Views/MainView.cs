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

namespace MyShop
{
    public partial class MainView : Form, IMainView
    {
        private MainPresenter presenter;

        public MainView()
        {
            InitializeComponent();

            // Создаем презентер и передаем ему эту форму
            presenter = new MainPresenter(this);

            this.Load += MainView_Load;
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

            dataGridViewProducts.DataSource = products;
        }
    }
}
