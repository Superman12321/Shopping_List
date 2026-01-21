using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace ShoppingList.Models
{
    public class Category
    {
        public string CategoryName { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        public static ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public static void SortProductsInCategory()
        {
            for (int i = 0; i < Categories.Count; i++)
            {
                var products = Categories[i].Products;
                Categories[i].Products = new ObservableCollection<Product>(Categories[i].Products.OrderBy(p => p.IsChecked));
            }
        }

        public static void SaveCategories()
        {
            string json = JsonSerializer.Serialize(Categories);
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "shoppinglist.json");
            File.WriteAllText(filePath, json);
        }
        public static void LoadCategories()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "shoppinglist.json");
            Debug.WriteLine("Plik kategorii zapisuje siê tutaj: " + filePath);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var loaded = JsonSerializer.Deserialize<List<Category>>(json);

                Categories.Clear();
                if (loaded != null)
                {
                    for (int i = 0; i < loaded.Count; i++)
                    {
                        Categories.Add(loaded[i]);
                    }
                }
            }
        }
    }
}
