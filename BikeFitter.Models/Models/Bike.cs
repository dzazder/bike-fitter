using BikeFitter.Models.ApiModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BikeFitter.Models.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string? Uri { get; set; }

        // parts
        public virtual Cassette Cassette { get; set; }
        public virtual Crankset Crankset { get; set; }
        public virtual Derailleur Derailleur { get; set; }
        public virtual Fork Fork { get; set; }
        public virtual Shifter Shifter { get; set; }
        public virtual Stem Stem { get; set; }

        public virtual Brake Brakes { get; set; }
        public virtual Rim Rims { get; set; }
        public virtual Tire Tires { get; set; }

        public decimal SumPoints()
        {
            return Cassette.Price + Crankset.Price + Derailleur.Price + Fork.Price + Shifter.Price + Stem.Price + Brakes.Price + Rims.Price + Tires.Price;
        }

        public ApiBike GetApiBike()
        {
            try
            {
                return new ApiBike
                {
                    Id = Id,
                    ModelName = ModelName,
                    Price = Price,
                    Uri = Uri,
                    BrakesId = Brakes.Id,
                    CassetteId = Cassette.Id,
                    CranksetId = Crankset.Id,
                    DerailleurId = Derailleur.Id,
                    ForkId = Fork.Id,
                    ManufacturerId = Manufacturer.Id,
                    RimsId = Rims.Id,
                    ShifterId = Shifter.Id,
                    StemId = Stem.Id,
                    TiresId = Tires.Id,
                    Weight = Weight
                };
            }
            catch (Exception) { }

            return new ApiBike();
        }
    }
}
