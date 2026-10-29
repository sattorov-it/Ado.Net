using Domain.Models;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    Task AddCategoryAsync(Categories category);
    Task UpdateCategoryAsync(Categories category);
    Task DeleteCategoryAsync(int id);
    Task<Categories> GetCategoryAsync(int id);
    Task<List<Categories>> GetCategoriesAsync();
    Task<int> GetAmountOfCategoriesAsync();
}