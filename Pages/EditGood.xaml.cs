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
    /// Логика взаимодействия для EditGood.xaml
    /// </summary>
    public partial class EditGood : Window
    {
        Product product = null;
        public EditGood(Product _product)
        {
            InitializeComponent();
            articleElem.Text = _product.ProductArticleNumber;
            nameElem.Text = _product.ProductName;
            descriptElem.Text = _product.ProductDescription;
            categoryElem.SelectedItem = _product.ProductCategory;
            manufactElem.Text = _product.ProductManufacturer;
            priceElem.Text = _product.ProductCost.ToString();
            discountElem.Text = _product.ProductDiscountAmount.ToString();
            quantityElem.Text = _product.ProductQuantityInStock.ToString();

            product = _product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string article = articleElem.Text;
            string name = nameElem.Text;
            string description = descriptElem.Text;
            string manufacturer = manufactElem.Text;
            int price = int.Parse(priceElem.Text);
            int discont = int.Parse(discountElem.Text);
            int quantity = int.Parse(quantityElem.Text);
            ComboBoxItem item = (ComboBoxItem)categoryElem.SelectedItem;

            Product newProduct = Helpers.connection.Product.FirstOrDefault(x => x.ProductName == name && x.ProductManufacturer == manufacturer);

            if (newProduct != null)
            {
                MessageBox.Show("Товар с таким наименованием уже есть в базе!");
                return;
            }

            Product editGood = Helpers.connection.Product.FirstOrDefault(x => x.ProductArticleNumber == product.ProductArticleNumber);
            editGood.ProductName = name;
            editGood.ProductDescription = description;
            editGood.ProductManufacturer = manufacturer;
            editGood.ProductCost = price;
            editGood.ProductDiscountAmount = discont;
            editGood.ProductQuantityInStock = quantity;
            editGood.ProductCategory = item.Content.ToString();

            Helpers.connection.SaveChanges();

            MessageBox.Show("Товар отредактирован");
            new GoodsAdmin().Show();
            Close();

        }
    }
}
