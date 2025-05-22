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

namespace MyShop
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private List<Product> products;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Загружаем товары из JSON
            products = ProductFactory.LoadProducts("products.json");

            // Отключаем автогенерацию колонок
            dataGridViewProducts.AutoGenerateColumns = false;
            // Очищаем старые колонки
            dataGridViewProducts.Columns.Clear();

            // Добавляем колонку Название
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Название"
            });

            // Добавляем колонку Цена
            dataGridViewProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Цена"
            });

            // Привязываем список товаров к таблице
            dataGridViewProducts.DataSource = products;
        }


    }
}
