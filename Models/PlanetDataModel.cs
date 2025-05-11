namespace Easyweb.Models
{
    public class PlanetDataModel
    {
        public string Title { get; set; }
        public ThumbnailData Thumbnail { get; set; }
        public string Description { get; set; }
        public string Extract { get; set; }
    }

    public class ThumbnailData
    {
        public string Source { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}