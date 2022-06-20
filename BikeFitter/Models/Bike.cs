using System.ComponentModel.DataAnnotations.Schema;

namespace BikeFitter.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string? Uri { get; set; }

        // parts
        public Cassette Cassette { get; set; }
        public Crankset Crankset { get; set; }
        public Derailleur Derailleur { get; set; }
        public Fork Fork { get; set; }
        public Shifter Shifter { get; set; }
        public Stem Stem { get; set; }

        public Brake Brakes { get; set; }
        public Rim Rims { get; set; }
        public Tire Tires { get; set; }

    }
}
