using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    void AddProducts(Products product);
    void UpdateProducts(Products product);
    void DeleteProducts(int id);
    Products GetProducts(int id);
    List<Products> GetProducts();
    List<Products> GetProductsByCategory(int categoryId);
    int GetAmountOfProducts();
    int GetAmountOfProductsByCategory(int categoryId);
    decimal GetMinPriceOfProductByCategory(int categoryId);
    decimal GetMaxPriceOfProductByCategory(int categoryId);
    decimal GetAveragePriceOfProductByCategory(int categoryId);
    decimal GetTotalPriceOfProducts();
}