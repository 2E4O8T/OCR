using ExpressV.Models;

namespace ExpressV.Services
{
    public class ImageService
    {
        private readonly PathService pathService;
        public ImageService(PathService pathService)
        {
            this.pathService = pathService;
        }
        public async Task<Photo> UploadAsync(Photo photo)
        {
            var uploadsPath = pathService.GetUploadsPath();

            var imageFile = photo.File;
            var imageFileName = GetRandomFileName(imageFile.FileName);
            var imageUploadPath = Path.Combine(uploadsPath, imageFileName);

            using (var fs = new FileStream(imageUploadPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fs);
            }
            photo.Name = imageFile.FileName;
            photo.Path = pathService.GetUploadsPath(imageFileName, withWebRootPath: false);

            return photo;
        }

        private string GetRandomFileName(string filename)
        {
            return Guid.NewGuid() + Path.GetExtension(filename);
        }
    }
}
