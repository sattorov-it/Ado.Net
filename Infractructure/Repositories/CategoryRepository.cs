
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public async Task AddCategoryAsync(Categories category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "insert into categories (name) values (@name)";
        await connection.ExecuteAsync(query, category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "delete from categories where id = @id";
        await connection.ExecuteAsync(query, new { id });
    }

    public async Task UpdateCategoryAsync(Categories category)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "update categories set name = @name where id = @id";
        await connection.ExecuteAsync(query, category);
    }

    public async Task<Categories> GetCategoryAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select * from categories where id = @id";
        var category = await connection.QuerySingleOrDefaultAsync<Categories>(query, new { id });
        return category;
    }

    public async Task<List<Categories>> GetCategoriesAsync()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select * from categories";
        var categories = await connection.QueryAsync<Categories>(query);
        return categories.ToList();
    }

    public async Task<int> GetAmountOfCategoriesAsync()
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "select count(*) from categories";
        var amount = await connection.ExecuteScalarAsync<int>(query);
        return amount;
    }
}
