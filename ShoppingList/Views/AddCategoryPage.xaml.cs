namespace ShoppingList;
using ShoppingList.Models;
public partial class AddCategoryPage : ContentPage
{
	public AddCategoryPage()
	{
		InitializeComponent();
	}
    private void addCategory(object sender, EventArgs e)
    {
        Category.Categories.Add(new Category
        {
            CategoryName = nameCategory.Text
        });
        Category.SaveCategories();
    }
}