using Domain.Models;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    void AddCategory(Categories category);
    void UpdateCategory(Categories category);
    void DeleteCategory(int id);
    Categories GetCategory(int id);
    List<Categories> GetCategories();
    int GetAmountOfCategories();
}