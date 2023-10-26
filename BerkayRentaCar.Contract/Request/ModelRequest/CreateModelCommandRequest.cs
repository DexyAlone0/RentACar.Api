using BerkayRentaCar.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Contract.Request.ModelRequest
{
    public class CreateModelCommandRequest
    {
        public string Name { get; set; } = string.Empty;
        public int CaseTypeId { get; set; }
        public int BrandId { get; set; }
        public int GearTypeId { get; set; }
        public CountOfSeat CountOfSeats { get; set; }
        public IFormFile File { get; set; }
        public int FuelTypeId { get; set; }
    }
}
