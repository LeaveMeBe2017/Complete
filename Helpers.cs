using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Test1
{
    public class Helpers
    {
        public static Model1 connection = new Model1();

        public static User Auth(string login, string password) //метод авторизация
        {
            User user = connection.User.FirstOrDefault(x => x.UserLogin == login);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден!");
                return null;
            }

            if (user.UserPassword != password)
            {
                MessageBox.Show("Неверный пароль!");
                return null;
            }

            return user;

        }

        public static bool AddProduct(string article, string name, string description, string category, string manufacturer, int price, int discount, int quantity) //метод добавления продукта
        {
            Product newProduct = connection.Product.FirstOrDefault(x => x.ProductName == name && x.ProductManufacturer == manufacturer);

            if (newProduct != null)
            {
                MessageBox.Show("Товар с таким наименованием уже есть в базе!");
                return false;
            }

            Product product = new Product();

            product.ProductArticleNumber = article;
            product.ProductName = name;
            product.ProductDescription = description;
            product.ProductManufacturer = manufacturer;
            product.ProductCost = price;
            product.ProductDiscountAmount = discount;
            product.ProductQuantityInStock = quantity;
            product.ProductCategory = category;

            connection.Product.Add(product);
            connection.SaveChanges();

            return true;

        }

    }

}
