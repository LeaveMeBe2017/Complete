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
    /// Логика взаимодействия для GoodsClient.xaml
    /// </summary>
    public partial class GoodsClient : Window
    {
        Model1 connection = new Model1();
        private User user = Store.user;
        public GoodsClient()
        {
            InitializeComponent();
            fioElem.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";
            goodsListElem.ItemsSource = Helpers.connection.Product.ToList();

            // Получаем список строк
            List<string> manufacturers = new List<string>();
            manufacturers.Add("Все производители");
            manufacturers.AddRange(Helpers.connection.Product.Select(x => x.ProductManufacturer).Distinct().ToList());

            manufacturersElem.ItemsSource = manufacturers;
        }

        private void Button_Click(object sender, RoutedEventArgs e) //кнопка на главную
        {
            new MainWindow().Show();
            Close();
        }

        private void searchElem_TextChanged(object sender, TextChangedEventArgs e) //поиск
        {
            List<Product> products = Helpers.connection.Product.Where(WhereMethod).ToList();

            goodsListElem.ItemsSource = products;
        }

        private bool WhereMethod(Product x)
        {
            return x.ProductName.Contains(searchElem.Text);
        }

        private void manufacturersElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string manufacturer = manufacturersElem.SelectedItem.ToString();

            List<Product> products;

            if (manufacturer == "Все производители")
            {
                products = Helpers.connection.Product.ToList();
            }
            else
            {
                products = Helpers.connection.Product.Where(x => x.ProductManufacturer == manufacturer).ToList();
            }

            goodsListElem.ItemsSource = products;
        }
    }
}
