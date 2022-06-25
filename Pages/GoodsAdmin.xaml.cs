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
using Test1.Pages;

namespace Test1.Pages
{
    /// <summary>
    /// Логика взаимодействия для GoodsAdmin.xaml
    /// </summary>
    public partial class GoodsAdmin : Window
    {
  
        private User user = Store.user;
        public GoodsAdmin()
        {
            InitializeComponent();

            fioElem.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";
            goodsListElem.ItemsSource = Helpers.connection.Product.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //кнопка на главную
        {
            new MainWindow().Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //кнопка добавления
        {
            new AddGood().Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) //кнопка редактирования
        {
            Product product = (Product)goodsListElem.SelectedItem;

            if(product == null)
            {
                MessageBox.Show("Выберите товар!");
                return;
            }
            new EditGood(product).Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) //кнопка удаление
        {
            Product product = (Product)goodsListElem.SelectedItem;

            if(product == null)
            {
                MessageBox.Show("Товар не выбран");
                return;
            }

            Helpers.connection.Product.Remove(product);
            Helpers.connection.SaveChanges();

            goodsListElem.ItemsSource = Helpers.connection.Product.ToList();


        }
    }
}
