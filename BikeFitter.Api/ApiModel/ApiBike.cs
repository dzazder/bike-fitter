using BikeFitter.Api.Models;

namespace BikeFitter.Api.ApiModel
{
    public class ApiBike
    {
        public int Id { get; set; }
        public int ManufacturerId { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string? Uri { get; set; }

        // parts
        public int CassetteId { get; set; }
        public int CranksetId { get; set; }
        public int DerailleurId { get; set; }
        public int ForkId { get; set; }
        public int ShifterId { get; set; }
        public int StemId { get; set; }

        public int BrakesId { get; set; }
        public int RimsId { get; set; }
        public int TiresId { get; set; }
    }
}
