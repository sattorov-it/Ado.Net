using Domain.Models;

namespace Domain.Interfaces;

public interface IProductRepository
{
    void AddProducts(Products name);
    void UpdateProducts(Products name);
    void DeleteProducts(int id);
    Products GetProducts(int id);
    List<Products> GetProducts();
}
