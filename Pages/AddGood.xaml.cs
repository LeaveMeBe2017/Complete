using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Test1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddGood.xaml
    /// </summary>
    public partial class AddGood : Window
    { 
        public AddGood()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)categoryElem.SelectedItem;
            string category = item.Content.ToString();
            string article = articleElem.Text;
            string name = nameElem.Text;
            string description = descriptElem.Text;
            string manufacturer = manufactElem.Text;
            int price;
            int discount;

            if (!int.TryParse(priceElem.Text, out price))
            {
                MessageBox.Show("Значение цена не число");
                return;
            }

            if (!int.TryParse(discontElem.Text, out discount))
            {
                MessageBox.Show("Значение скидки не цена");
                return;
            } 


            int quantity = int.Parse(quantityElem.Text);

            bool result = Helpers.AddProduct(article, name, description, category, manufacturer, price, discount, quantity); //через метод в классе Helpers

            if (result == true)
            {
                MessageBox.Show("Товар добавлен");
            }

            new GoodsAdmin().Show();
            Close();


            
        }
    }
}
