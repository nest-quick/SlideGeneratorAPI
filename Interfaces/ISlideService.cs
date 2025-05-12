using SlideGeneratorAPI.Models;

namespace SlideGeneratorAPI.Interfaces
{
    public interface ISlideService
    {
        Task<string> GenerateSlidesAsync(SlideRequest request);
    }
}
