
using Domain.Models;
using Infrastructure.Repositories;

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
11 - Show products by category.
12 - Show amount of products.
13 - Show amount of categories.
14 - Show amount of products by category.
15 - Show min price by category.
16 - Show max price by category.
17 - Show average price by category.
18 - Show total price of products.
0 - Exit.");

    var a = Console.ReadLine();

    System.Console.WriteLine("===============================");

    switch (a)
    {
        case "1":
            var allCategories = await categoryRepo.GetCategoriesAsync();

            foreach (var item in allCategories)
            {
                System.Console.WriteLine(item.Id + " " + item.Name);
            }
            break;

        case "2":
            System.Console.Write("Enter id of category: ");
            var categoryIdToShow = Convert.ToInt32(Console.ReadLine());

            var categoryToShow = await categoryRepo.GetCategoryAsync(categoryIdToShow);
            System.Console.WriteLine(categoryToShow.Id + " " + categoryToShow.Name);
            break;

        case "3":
            System.Console.Write("Enter name: ");
            var categoryName = Console.ReadLine()!;

            var newCategory = new Categories()
            {
                Name = categoryName
            };

            await categoryRepo.AddCategoryAsync(newCategory);
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

            await categoryRepo.UpdateCategoryAsync(categoryToUpdate);
            break;

        case "5":
            System.Console.Write("Enter id: ");
            var categoryIdToDelete = Convert.ToInt32(Console.ReadLine());

            await categoryRepo.DeleteCategoryAsync(categoryIdToDelete);
            break;

        case "6":
            var allProducts = await productRepo.GetProductsAsync();

            foreach (var item in allProducts)
            {
                System.Console.WriteLine(item.Id + " " + item.Name + " " + item.Price);
            }
            break;

        case "7":
            System.Console.Write("Enter id of product: ");
            var productIdToShow = Convert.ToInt32(Console.ReadLine());

            var productToShow = await productRepo.GetProductsAsync(productIdToShow);
            System.Console.WriteLine(productToShow.Id + " " + productToShow.Name + " " + productToShow.Price);
            break;

        case "8":
            System.Console.Write("Enter name: ");
            var productName = Console.ReadLine()!;
            System.Console.Write("Enter price: ");
            var productPrice = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("Enter category id: ");
            var productCategoryId = Convert.ToInt32(Console.ReadLine());

            var newProduct = new Products()
            {
                Name = productName,
                Price = productPrice,
                CategoryId = productCategoryId
            };

            await productRepo.AddProductsAsync(newProduct);
            break;

        case "9":
            System.Console.Write("Enter id: ");
            var productIdToUpdate = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter new name: ");
            var newProductName = Console.ReadLine()!;
            System.Console.Write("Enter new price: ");
            var newProductPrice = Convert.ToDecimal(Console.ReadLine());
            System.Console.Write("Enter new category id: ");
            var newProductCategoryId = Convert.ToInt32(Console.ReadLine());

            var productToUpdate = new Products()
            {
                Id = productIdToUpdate,
                Name = newProductName,
                Price = newProductPrice,
                CategoryId = newProductCategoryId
            };

            await productRepo.UpdateProductsAsync(productToUpdate);
            break;

        case "10":
            System.Console.Write("Enter id: ");
            var productIdToDelete = Convert.ToInt32(Console.ReadLine());

            await productRepo.DeleteProductsAsync(productIdToDelete);
            break;

        case "11":
            System.Console.Write("Enter category id: ");
            var idForProducts = Convert.ToInt32(Console.ReadLine());

            var productsByCategory = await productRepo.GetProductsByCategoryAsync(idForProducts);

            foreach (var item in productsByCategory)
            {
                System.Console.WriteLine(item.Id + " " + item.Name + " " + item.Price);
            }
            break;

        case "12":
            System.Console.WriteLine("Amount of products: " + await productRepo.GetAmountOfProductsAsync());
            break;

        case "13":
            System.Console.WriteLine("Amount of categories: " + await categoryRepo.GetAmountOfCategoriesAsync());
            break;

        case "14":
            System.Console.Write("Enter category id: ");
            var idForAmount = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Amount: " + await productRepo.GetAmountOfProductsByCategoryAsync(idForAmount));
            break;

        case "15":
            System.Console.Write("Enter category id: ");
            var idForMin = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Min price: " + await productRepo.GetMinPriceOfProductByCategoryAsync(idForMin));
            break;

        case "16":
            System.Console.Write("Enter category id: ");
            var idForMax = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Max price: " + await productRepo.GetMaxPriceOfProductByCategoryAsync(idForMax));
            break;

        case "17":
            System.Console.Write("Enter category id: ");
            var idForAvg = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Average price: " + await productRepo.GetAveragePriceOfProductByCategoryAsync(idForAvg));
            break;

        case "18":
            System.Console.WriteLine("Total price: " + await productRepo.GetTotalPriceOfProductsAsync());
            break;

        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}
