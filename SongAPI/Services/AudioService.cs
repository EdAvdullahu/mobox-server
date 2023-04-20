using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SongAPI.Services.Interface;

namespace SongAPI.Services
{
    public class AudioService: IAudioService
    {
        private readonly Cloudinary _cloudinary;
        public AudioService()
        {
            var acc = new Account(
                "ddd8z6szf",
                "259388714665359",
                "Mi_vQCyhTWFHuXEWsZn-kHLaF-A"
            );
            _cloudinary = new Cloudinary(acc);
        }
        public async Task<VideoUploadResult> UploadAudioAsync(IFormFile file)
        {
            var uploadResult = new VideoUploadResult();
            string folder = "Songs/Audio";
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new VideoUploadParams()
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = folder
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }
        public async Task<DeletionResult> DeleteAudioAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
