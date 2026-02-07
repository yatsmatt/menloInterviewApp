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
                Console.WriteLine(info[0]);
                Console.WriteLine(info[1]);
            }
            catch (System.Exception e)
            {

                throw;
            }
            return Ok(new { UploadPath = info[0], Extension = info[1] });
        }
    }
}