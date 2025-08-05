using Domain.Entities;

namespace Application.Repositories;

public interface IVideoRepository
{
    Task<long> InsertAsync(Video video);
    Task UpdateAsync(Video video);
    Task DeleteAsync(long videoId);
    Task<IEnumerable<Video>> SelectVideosByPriceAsync(decimal price);
    Task<Video?> SelectVideoByIdAsync(long videoId);
    Task<Video?> SelectVideoByNameAsync(string name);
    Task<IEnumerable<Video>> SelectAllVideosAsync();

    Task<IEnumerable<Video>> SelectVideosByCategoryIdAsync(long categoryId);
    Task<IEnumerable<Video>> SelectVideoByInstructorIdAsync(long instructorId);

    Task<IEnumerable<Video>> SelectWithCategoryAsync();         
    Task<IEnumerable<Video>> SelectVideoWithInstructorAsync();       

    Task IncrementViewsAsync(long videoId);                  
    Task<IEnumerable<Video>> SelectVideosBetweemPriceAsyncn(decimal minPrice, decimal maxPrice);        
}
