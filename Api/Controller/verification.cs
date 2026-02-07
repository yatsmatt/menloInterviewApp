using System.Text;
namespace formatApi
{
    public class UploadHendler
    {

        public async Task<string[]> Uploads(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName).ToLower();
            string fileName = Guid.NewGuid().ToString() + extension;
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            string fullPath = Path.Combine(uploadPath, fileName);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return new string[] { fullPath, extension };
        }

    }
}