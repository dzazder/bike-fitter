namespace BikeFitter.Api.Models
{
    /// <summary>
    /// Przerzutka
    /// </summary>
    public class Derailleur
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Uri { get; set; }
    }
}
