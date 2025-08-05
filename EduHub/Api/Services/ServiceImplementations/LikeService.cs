using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Mappers;
using Application.Repositories;
using Core.Errors;

namespace Application.ServiceContracts.ServiceImplementations;

public class LikeService(
    ILikeRepository likeRepository,
    IUserRepository userRepository,
    IVideoRepository videoRepository) : ILikeService
{
    public async Task<long> AddLikeAsync(LikeCreateDto dto)
    {
        var user = await userRepository.SelectUserByIdAsync(dto.UserId)
                   ?? throw new NotFoundException("User not found.");

        var video = await videoRepository.SelectVideoByIdAsync(dto.VideoId)
                    ?? throw new NotFoundException("Video not found.");

        var like = new Like
        {
            UserId = dto.UserId,
            VideoId = dto.VideoId,

        };

        return await likeRepository.InsertAsync(like);
    }

    public async Task<IEnumerable<LikeDto>> GetLikesByVideoIdAsync(long videoId)
    {
        var likes = await likeRepository.SelectByVideoIdAsync(videoId);
        return likes.Select(LikeMapper.ToLikeDto).ToList();
    }

    public async Task DeleteLikeAsync(long contentId,long userId)
    {
         await likeRepository.DeleteAsync(contentId,userId);
    }


    public async Task<bool> HasUserLikedAsync(long userId, long videoId)
    {
        return await likeRepository.IsLiked(userId, videoId);
    }

}
