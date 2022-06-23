using System.Text.RegularExpressions;

namespace BikeFitter.Api.Models
{
    public class Rim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Uri { get; set; }

    }
}
