using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;


namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public void AddCategory(Categories category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "insert into categories (name) values (@name)";
        connection.Execute(query, category);
    }
    public void DeleteCategory(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "delete from categories where id = @id";
        connection.Execute(query, new { id });
    }

    public void UpdateCategory(Categories category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "update categories set name = @name where id = @id";
        connection.Execute(query, category);
    }


    public Categories GetCategory(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from categories where id = @id";
        var category = connection.QuerySingle<Categories>(query, new { id });
        return category;
    }

    public List<Categories> GetCategories()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from categories";
        var categories = connection.Query<Categories>(query);
        return categories.ToList();
    }

    public int GetAmountOfCategories()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select count(*) from categories";
        var amount = connection.ExecuteScalar<int>(query);
        return amount;
    }
}