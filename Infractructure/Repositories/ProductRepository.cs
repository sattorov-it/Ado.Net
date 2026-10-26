using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infractructure.Repositories;

public class ProductRepository : IProductRepository
{
    public void AddProducts(Products name)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "insert into products(name, price) values (@name, @price)";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", name.Name);
        cmd.Parameters.AddWithValue("price", name.Price);
        cmd.ExecuteNonQuery();
    }
    public void UpdateProducts(Products name)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update products set name = @name, price = @price where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", name.Name);
        cmd.Parameters.AddWithValue("price", name.Price);
        cmd.Parameters.AddWithValue("id", name.Id);
        cmd.ExecuteNonQuery();
    }

    public void DeleteProducts(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from products where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();
    }

    public Products GetProducts(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, name, price from products where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var reader = cmd.ExecuteReader();
        var product = new Products();
        while (reader.Read())
        {
            product.Id = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Price = reader.GetDecimal(2);
        }
        return product;
    }

    public List<Products> GetProducts()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, name, price from products";
        var cmd = new NpgsqlCommand(query, conn);
        var reader = cmd.ExecuteReader();
        var list = new List<Products>();
        while (reader.Read())
        {
            var product = new Products();
            product.Id = reader.GetInt32(0);
            product.Name = reader.GetString(1);
            product.Price = reader.GetDecimal(2);
            list.Add(product);
        }
        return list;
    }
}
