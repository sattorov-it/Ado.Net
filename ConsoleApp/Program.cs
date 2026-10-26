using Domain.Models;
using Infractructure.Repositories;

var categoryRepo = new CategoryRepository();
var productRepo = new ProductRepository();

while (true)
{
    System.Console.WriteLine("===============================");
    System.Console.WriteLine(@"1 - Show all categories.
2 - Show category.
3 - Add new category.
4 - Update category.
5 - Delete category.
6 - Show all products.
7 - Show product.
8 - Add new product.
9 - Update product.
10 - Delete product.
0 - Exit.");

    var a = Console.ReadLine();

    System.Console.WriteLine("===============================");

    switch (a)
    {
        case "1":
            var allCategories = categoryRepo.GetCategories();

            foreach (var item in allCategories)
            {
                System.Console.WriteLine(item.Id + " " + item.Name);
            }
            break;

        case "2":
            System.Console.Write("Enter id of category: ");
            var categoryIdToShow = Convert.ToInt32(Console.ReadLine());

            var categoryToShow = categoryRepo.GetCategory(categoryIdToShow);
            System.Console.WriteLine(categoryToShow.Id + " " + categoryToShow.Name);
            break;

        case "3":
            System.Console.Write("Enter name: ");
            var categoryName = Console.ReadLine()!;

            var newCategory = new Categories()
            {
                Name = categoryName
            };

            categoryRepo.AddCategory(newCategory);
            break;

        case "4":
            System.Console.Write("Enter id: ");
            var categoryIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newCategoryName = Console.ReadLine()!;
            var categoryToUpdate = new Categories()
            {
                Id = categoryIdToUpdate,
                Name = newCategoryName
            };

            categoryRepo.UpdateCategory(categoryToUpdate);
            break;

        case "5":
            System.Console.Write("Enter id: ");
            var categoryIdToDelete = Convert.ToInt32(Console.ReadLine());

            categoryRepo.DeleteCategory(categoryIdToDelete);
            break;

        case "6":
            var allProducts = productRepo.GetProducts();

            foreach (var item in allProducts)
            {
                System.Console.WriteLine(item.Id + " " + item.Name + " " + item.Price);
            }
            break;

        case "7":
            System.Console.Write("Enter id of product: ");
            var productIdToShow = Convert.ToInt32(Console.ReadLine());

            var productToShow = productRepo.GetProducts(productIdToShow);
            System.Console.WriteLine(productToShow.Id + " " + productToShow.Name + " " + productToShow.Price);
            break;

        case "8":
            System.Console.Write("Enter name: ");
            var productName = Console.ReadLine()!;
            System.Console.Write("Enter price: ");
            var productPrice = Convert.ToDecimal(Console.ReadLine());

            var newProduct = new Products()
            {
                Name = productName,
                Price = productPrice
            };

            productRepo.AddProducts(newProduct);
            break;

        case "9":
            System.Console.Write("Enter id: ");
            var productIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newProductName = Console.ReadLine()!;
            System.Console.Write("Enter new price: ");
            var newProductPrice = Convert.ToDecimal(Console.ReadLine());

            var productToUpdate = new Products()
            {
                Id = productIdToUpdate,
                Name = newProductName,
                Price = newProductPrice
            };

            productRepo.UpdateProducts(productToUpdate);
            break;

        case "10":
            System.Console.Write("Enter id: ");
            var productIdToDelete = Convert.ToInt32(Console.ReadLine());

            productRepo.DeleteProducts(productIdToDelete);
            break;

        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}