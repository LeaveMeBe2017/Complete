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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test1.Pages;

namespace Test1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //кнопка гость
        {
            Goods goods = new Goods();
            goods.Show();
            Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //кнопка войти
        {
            string login = loginElem.Text;
            string password = passElem.Password;

            User user = Helpers.Auth(login, password);

            if (user == null)
            {
                return;
            }
            Store.user = user;

            if(user.UserRole == 1)
            {
                new GoodsAdmin().Show();
                Close();
            }

            else
            {
                new GoodsClient().Show();
                Close();
            }
        }
    }
}
