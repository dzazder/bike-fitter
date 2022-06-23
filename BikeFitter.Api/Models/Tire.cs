namespace BikeFitter.Api.Models
{
    /// <summary>
    /// Opony
    /// </summary>
    public class Tire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Uri { get; set; }
    }
}
