using Application.Dtos;
using Application.Mappers;
using Application.Repositories;
using Core.Errors;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Application.Services.ServiceImplementations;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<long> AddCategoryAsync(CategoryCreateDto categoryCreateDto)
    {
        var category = new Category()
        {
            Name = categoryCreateDto.Name,
        };

        return await categoryRepository.InsertCategoryAsync(category);
    }

    public async Task DeleteCategoryAsync(long categoryId) 
    {
        await categoryRepository.DeleteAsync(categoryId);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCatigoriesAsync()
    {
        var categories = await categoryRepository.SelectAllAsync();
        return categories.Select(CategoryMapper.ToCategoryDto).ToList();
    }

    public async Task<CategoryDto> GetCategoryByNameAsync(string categoryName)
    {
        var category = await categoryRepository.SelectCategoryByNameAsync(categoryName);
        return CategoryMapper.ToCategoryDto(category);


    }

    public async Task UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto, long categoryId)
    {
        var category = await categoryRepository.SelectByIdAsync(categoryId);
        if (category is null) throw new NotFoundException($"Category with id : {categoryId} not found");
        else
        {
            categoryUpdateDto.CategoryName = category.Name;
        }
    }
}
