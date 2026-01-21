using ShoppingList.Models;
using System.Text.Json;
using System.IO;

namespace ShoppingList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Category.LoadCategories();
            picker.ItemsSource = Category.Categories;
        }
        private void addProduct(object sender, EventArgs e)
        {
            var selectedCategory = picker.SelectedItem as Category;
            var selectedQuantity = pickerQuantity.SelectedItem as string;

            if (selectedCategory == null) return;

            string productName = nameProduct.Text;

            int quantityproducts = int.Parse(productQuantity.Text);
            selectedCategory.Products.Add(new Product
            {
                ProductName = productName,
                QuantityProduct = quantityproducts,
                QuantityCategory = selectedQuantity,
                IsOptimal = myCheckBox.IsChecked
            });

            Category.SaveCategories();

            nameProduct.Text = string.Empty;
            productQuantity.Text = string.Empty;
            pickerQuantity.SelectedItem = null;
        }
    }
}
