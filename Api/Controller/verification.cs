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
            // if (file == null || file.Length == 0)
            // {
            //     Console
            // }

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            try
            {
                await using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return new string[] { fullPath, extension };
            }
            catch (Exception e)
            {
                throw new Exception("Exception", e);
            }

        }

    }
}