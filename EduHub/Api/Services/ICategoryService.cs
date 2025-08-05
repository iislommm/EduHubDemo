using Application.Dtos;

namespace Application.Services;

public interface ICategoryService
{
    Task<long> AddCategoryAsync(CategoryCreateDto categoryCreateDto);
    Task DeleteCategoryAsync(long categoryId);
    Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto, long categoryid);
    Task<IEnumerable<CategoryDto>> GetAllCatigoriesAsync();
    Task<CategoryDto> GetCategoryByNameAsync(string categoryName);
}
