using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace formatApi
{
    [Route("api/[controller]/[action]")]
    public class MainController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            string[] info;
            try
            {
                info = await new UploadHendler().Uploads(file);
                string UploadPath = info[0];
                string Extension = info[1];
                AbstractFormat fileObj = FormatFactory.getFormat(Extension, UploadPath);
                string fileContent = fileObj.sanitizeFile();
                return Ok(fileContent);
            }

            catch (Exception e)
            {
                throw new Exception("Exception", e);
            }

        }
    }
}