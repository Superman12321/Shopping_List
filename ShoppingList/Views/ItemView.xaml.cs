namespace ShoppingList.Views;
using ShoppingList.Models;

public partial class ItemView : ContentView
{
    public ItemView()
    {
        InitializeComponent();
    }

    private void add(object sender, EventArgs e)
    {
        var product = (Product)((Button)sender).CommandParameter;

        if (!product.IsChecked)
        {
            product.QuantityProduct++;
            Category.SaveCategories();
        }
    }

    private void subtract(object sender, EventArgs e)
    {
        var product = (Product)((Button)sender).CommandParameter;

        if (!product.IsChecked && product.QuantityProduct > 1)
        {
            product.QuantityProduct--;
            Category.SaveCategories();
        }
    }

    private void delete(object sender, EventArgs e)
    {
        var product = (Product)((Button)sender).CommandParameter;

        var category = Category.Categories.FirstOrDefault(c => c.Products.Contains(product));
        if (category != null)
        {
            category.Products.Remove(product);
            Category.SaveCategories();
        }
    }

    private void unCheck(object sender, EventArgs e)
    {
        var product = (Product)((Button)sender).CommandParameter;

        product.IsChecked = !product.IsChecked;

        Category.SortProductsInCategory();
        Category.SaveCategories();
    }
}
