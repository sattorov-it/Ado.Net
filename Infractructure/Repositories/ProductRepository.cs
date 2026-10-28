using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    public void AddProducts(Products product)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "insert into products (name, price, categoryid) values (@name, @price, @categoryid)";
        connection.Execute(query, product);
    }

    public void UpdateProducts(Products product)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "update products set name = @name, price = @price, categoryid = @categoryid where id = @id";
        connection.Execute(query, product);
    }

    public void DeleteProducts(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "delete from products where id = @id";
        connection.Execute(query, new { id });
    }

    public Products GetProducts(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from products where id = @id";
        var product = connection.QuerySingle<Products>(query, new { id });
        return product;
    }

    public List<Products> GetProducts()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from products";
        var products = connection.Query<Products>(query);
        return products.ToList();
    }

    public List<Products> GetProductsByCategory(int categoryId)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from products where categoryid = @categoryId";
        var products = connection.Query<Products>(query, new { categoryId });
        return products.ToList();
    }

    public int GetAmountOfProducts()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select count(*) from products";
        var amount = connection.ExecuteScalar<int>(query);
        return amount;
    }

    public int GetAmountOfProductsByCategory(int categoryId)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select count(*) from products where categoryid = @categoryId";
        var amount = connection.ExecuteScalar<int>(query, new { categoryId });
        return amount;
    }

    public decimal GetMinPriceOfProductByCategory(int categoryId)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select min(price) from products where categoryid = @categoryId";
        var price = connection.ExecuteScalar<decimal>(query, new { categoryId });
        return price;
    }

    public decimal GetMaxPriceOfProductByCategory(int categoryId)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select max(price) from products where categoryid = @categoryId";
        var price = connection.ExecuteScalar<decimal>(query, new { categoryId });
        return price;
    }

    public decimal GetAveragePriceOfProductByCategory(int categoryId)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select avg(price) from products where categoryid = @categoryId";
        var price = connection.ExecuteScalar<decimal>(query, new { categoryId });
        return price;
    }

    public decimal GetTotalPriceOfProducts()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select sum(price) from products";
        var price = connection.ExecuteScalar<decimal>(query);
        return price;
    }
}