using BerkayRentaCar.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Contract.Request.ModelRequest
{
    public class ModelUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CaseTypeId { get; set; }
        public int FuelTypeId { get; set; }
        public int GearTypeId { get; set; }
        public CountOfSeat CountOfSeats { get; set; }
        
    }
}
