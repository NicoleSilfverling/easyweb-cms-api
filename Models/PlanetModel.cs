namespace Easyweb.Models
{
    public class Planet
    {
        public string Name { get; set; }           // Display name (e.g. "Mercury")
        public string WikiName { get; set; }       // Used in API calls (e.g. "Mercury_(planet)")
        public double SizeFactor { get; set; }     // Size
        public string Color { get; set; }          // Color
        public bool HasRings { get; set; }         // For Saturn
    }
}