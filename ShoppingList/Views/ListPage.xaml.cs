namespace ShoppingList;
using ShoppingList.Models;
public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }
    private void ShowProducts_Clicked(object sender, EventArgs e)
    {
        RefreshProductsList();
    }
    private void RefreshProductsList()
    {
        var allProducts = new List<Product>();

        for (int i = 0; i < Category.Categories.Count; i++)
        {
            var category = Category.Categories[i];

            for (int j = 0; j < category.Products.Count; j++)
            {
                var product = category.Products[j];
                allProducts.Add(product);
            }
        }

        productsList.ItemsSource = null;
        productsList.ItemsSource = allProducts;
    }
}