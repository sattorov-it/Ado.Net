using Domain.Models;

namespace Domain.Interfaces;

public interface ICategoryRepository
{
    void AddCategory(Categories name);
    void UpdateCategory(Categories name);
    void DeleteCategory(int id);
    Categories GetCategory(int id);
    List<Categories> GetCategories();
}