using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Images;
using OpenAI;

namespace AI_Image_Generator_WebAPI.Controllers
{

    [ApiController]
    public class AIImageController : ControllerBase
    {
        [Route("GenerateAIImage")]
        [HttpGet]

        public async Task<IActionResult> GenerateAIImage(string prompt , int count)
        {
            List<string> lstImg = new List<string>();

            string ApiKey = "YOUR_API_KEY_HERE";

            var _openAIClient = new OpenAIClient(new OpenAIAuthentication(ApiKey));
            var imageResult = await _openAIClient.ImagesEndPoint.GenerateImageAsync(prompt, count, ImageSize.Small);
            foreach (var image in imageResult)
            {
                lstImg.Add(image);
            }
            return Ok(lstImg);
        }
    }
}