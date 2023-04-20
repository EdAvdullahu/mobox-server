using CloudinaryDotNet.Actions;

namespace SongAPI.Services.Interface
{
    public interface IAudioService
    {
        Task<VideoUploadResult> UploadAudioAsync(IFormFile file);
        Task<DeletionResult> DeleteAudioAsync(string publicId);
    }
}
