using Domain.Entities;

namespace Application.Repositories;

public interface ICategoryRepository
{
    Task<Category?> SelectByIdAsync(long id);
    Task<Category?> SelectCategoryByNameAsync(string name);
    Task<IEnumerable<Category>> SelectAllAsync();
    Task<IEnumerable<Category>> SelectWithVideosAsync();
    Task <long>InsertCategoryAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(long id);
}
    