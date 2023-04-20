using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SongAPI.Services.Interface;

namespace SongAPI.Services
{
    public class ImageService: IImageService
    {
        private readonly Cloudinary _cloudinary;
        public ImageService()
        {
            var acc = new Account(
                "ddd8z6szf",
                "259388714665359",
                "Mi_vQCyhTWFHuXEWsZn-kHLaF-A"
            );
            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            string folder = "Songs/Images";
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Folder = folder
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }


    }
}
