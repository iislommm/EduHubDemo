using Domain.Entities;

namespace Application.Repositories;

public interface IChannelRepository
{
    Task<long> InsertAsync(Channel instructor);
    Task UpdateAsync(Channel instructor);
    Task DeleteAsync(long instructorId);
    Task<Channel?> SelectByIdAsync(long instructorId);
    Task<Channel?> SelectByLinkAsync(string email);
    Task<IEnumerable<Channel>> SelectAllAsync(long userId);
    Task<IEnumerable<Channel>> SelectWithVideosAsync();
}
