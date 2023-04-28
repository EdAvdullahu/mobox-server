using CloudinaryDotNet.Actions;

namespace PodcastAPI.Services.Interface
{
    public interface IFileService
    {
        Task<ImageUploadResult> AddImageAsync(IFormFile file);
        Task<VideoUploadResult> UploadMp3Async(IFormFile file);
        Task<DeletionResult> DeleteImageAsync(string publicId);

    }
}
