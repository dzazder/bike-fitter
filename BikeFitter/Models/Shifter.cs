namespace BikeFitter.Models
{
    /// <summary>
    /// Manetka przerzutki
    /// </summary>
    public class Shifter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Uri { get; set; }
    }
}
