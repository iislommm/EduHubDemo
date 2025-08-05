using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class CategoryMapper
{
    public static Category ToCategoryEntity(CategoryCreateDto dto)
    {
        return new Category
        {
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static CategoryDto ToCategoryDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            CreatedAt = category.CreatedAt
        };
    }
}
