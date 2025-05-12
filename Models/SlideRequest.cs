namespace SlideGeneratorAPI.Models
{
    public class SlideRequest
    {
        public string Title { get; set; } = string.Empty;
        public SlideContainer Slides { get; set; } = new();
    }

    public class SlideContainer {
        public string Title { get; set; } = string.Empty;
        public List<SlideData> Slides { get; set; } = new();
    }

    public class SlideData
    {
        public string Title { get; set; } = string.Empty;
        public List<string> Bullets { get; set; } = new();
    }
}
