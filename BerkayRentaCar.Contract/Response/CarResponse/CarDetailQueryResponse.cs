using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Contract.Response.CarResponse
{
    public class CarDetailQueryResponse
    {
        public int CarId { get; set; }
        public int ModelId { get; set; }
        public int Year{ get; set; }
        public bool HesAirConditioning { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string FuelTypeName { get; set; } = string.Empty;
        public string GearTypeName { get; set; } = string.Empty;
        public string EngineCapacityName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int FileId { get; set; }
        public string ModelName { get; set; } = string.Empty;
    }
}
