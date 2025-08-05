
using Application.Mappers;
using Application.Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Core.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Principal;

namespace Application.Services.ServiceImplementations
{
    public class VideoService : IVideoService

    {

        private readonly IVideoRepository videoRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IChannelRepository instructorRepository;
        private readonly IConfiguration configuration;
        private readonly Cloudinary _cloudinary;

        public VideoService(IConfiguration configuration, IVideoRepository videoRepository, ICategoryRepository categoryRepository, IChannelRepository instructorRepository, Cloudinary cloudinary)
        {
            this.videoRepository = videoRepository;
            this.categoryRepository = categoryRepository;
            this.instructorRepository = instructorRepository;
            _cloudinary = cloudinary;
        }


        public async Task<string> UploadImageToCloudinaryAsync(IFormFile file)
        {
            await using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "Videos"
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Cloudinary upload failed: " + uploadResult.Error?.Message);
            }
            return uploadResult.SecureUrl.ToString();
        }





        public async Task<long> AddVideoAsync(VideoCreateDto dto,IFormFile file)
        {
            var category = await categoryRepository.SelectByIdAsync(dto.CategoryId)
                ?? throw new NotFoundException("Category not found");

            var instructor = await instructorRepository.SelectByIdAsync(dto.InstructorId)
                ?? throw new NotFoundException("Instructor not found");

            var video = VideoMapper.ToVideoEntity(dto);
            video.VideoUrl =await UploadImageToCloudinaryAsync(file);
            video.MB =(int) file.Length;
            return await videoRepository.InsertAsync(video);
        }

        public async Task DeleteVideoAsync(long videoId)
        {
            await videoRepository.DeleteAsync(videoId);
        }

        public async Task<VideoGetDto> GetVideoByIdAsync(long videoId)
        {
            var video = await videoRepository.SelectVideoByIdAsync(videoId)
                ?? throw new NotFoundException("video not found");

            return VideoMapper.ToVideoGetDto(video);
        }

        public async Task<IEnumerable<VideoGetDto>> GetAllVideosAsync()
        {
            var videos = await videoRepository.SelectAllVideosAsync();
            return videos.Select(VideoMapper.ToVideoGetDto).ToList();
        }

        public async Task<IEnumerable<VideoGetDto>> GetVideosByInstructorAsync(long instructorId)
        {
            var videos = await videoRepository.SelectVideoByInstructorIdAsync(instructorId);
            return videos.Select(VideoMapper.ToVideoGetDto).ToList();
        }

        public async Task<IEnumerable<VideoGetDto>> GetVideosByCateforyIdAsync(long categoryid)
        {
            var videos = await videoRepository.SelectVideosByCategoryIdAsync(categoryid);
            return videos.Select(VideoMapper.ToVideoGetDto).ToList();
        }

        public async Task UpdateVideoasync(long videoId, VideoUpdateDto dto)
        {
            var existingVideo = await videoRepository.SelectVideoByIdAsync(videoId);

                if (existingVideo is null) throw new NotFoundException($"Video with {videoId} not found");
            else
            {
                existingVideo.Name = dto.Name;
                existingVideo.Description = dto.Description;
                existingVideo.Price = dto.Price;
                await videoRepository.UpdateAsync(existingVideo);
            }
        }
    }
}
