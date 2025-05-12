using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Slides.v1;
using Google.Apis.Slides.v1.Data;
using Google.Apis.Services;
using SlideGeneratorAPI.Services;
using SlideGeneratorAPI.Models;
using SlideGeneratorAPI.Interfaces;

namespace SlideGeneratorAPI.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateSlides([FromBody] SlideRequest request)
        {
            try
            {
                var url = await _slideService.GenerateSlidesAsync(request);
                return Ok(new { url });
            }catch (Exception ex)
            {
                Console.WriteLine("Controller error: " + ex.Message);
                return StatusCode(500, new { error = "Failed to generate slides" });
            }

        }
    }
}
