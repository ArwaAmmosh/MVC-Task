using Microsoft.Extensions.Hosting;
using System.Net.NetworkInformation;
namespace Company.BLL.Helpers
{
    public static class ImageServices
    {
            private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png"];
            private static readonly string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UserImages");

            static ImageServices()
            {
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
            }

            public static string? UploadImage(IFormFile file)
            {
                if (file == null || file.Length == 0)
                    return null;
                string extension = Path.GetExtension(file.FileName).ToLower();
                if (!AllowedExtensions.Contains(extension))
                    return null;
                string uniqueFileName = $"{Guid.NewGuid()}_{DateTime.Now.Ticks}{extension}";
                string filePath = Path.Combine(FolderPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                     file.CopyToAsync(stream);
                }

                return Path.Combine("UserImages", uniqueFileName);
            }
        }
    
}



