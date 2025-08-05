using Application.Abstractions.Repositories;
using Application.Repositories;
using Core.Errors;
using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository(AppDbContextMS appDbContext) : ICategoryRepository
{
    private readonly AppDbContextMS _context = appDbContext;

    public async Task<long> InsertCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category.Id;
    }


    public async Task DeleteAsync(long id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null)
        {
            throw new NotFoundException($"Not found category: {id}");
        }
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> SelectAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> SelectByIdAsync(long id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<Category?> SelectCategoryByNameAsync(string name)
    {
        return await _context.Categories
            .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }

    public async Task<IEnumerable<Category>> SelectWithVideosAsync()
    {
        return await _context.Categories
            .Include(c => c.Videos)
            .ToListAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}
