namespace ShoppingList;
using ShoppingList.Models;
public partial class CategoryPage : ContentPage
{
    public CategoryPage()
    {
        InitializeComponent();
        categoryPicker.ItemsSource = Category.Categories;
    }
    private void loadProducts(object sender, EventArgs e)
    {
        var selectedCategory = categoryPicker.SelectedItem as Category;

        if (selectedCategory == null) return;

        productsList.ItemsSource = selectedCategory.Products;
        currentCategoryLabel.Text = $"Aktualna lista: {selectedCategory.CategoryName}";
    }
}
