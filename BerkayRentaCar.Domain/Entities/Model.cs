using BerkayRentaCar.Common.Enums;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Domain.Entities
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaseTypeId { get; set; }
        public int BrandId { get; set; }
        public int GearTypeId { get; set; }
        public CountOfSeat CountOfSeats { get; set; }
        public int FileId { get; set; }
        public int FuelTypeId { get; set; } 
        public virtual FuelType FuelType { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }
        public virtual CaseType CaseType { get; set; }
        public virtual GearType GearType { get; set; }
        [ForeignKey(nameof(FileId))]
        public virtual File File { get; set; }

    }
}
