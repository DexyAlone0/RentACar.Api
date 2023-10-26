 using System.ComponentModel.DataAnnotations.Schema;


namespace BerkayRentaCar.Domain.Entities
{
    public class Car  
    {
        public int Id { get; set; }
        public int  ModelId { get; set; }
      
        public int Year { get; set; }
        public string EngineCapacity { get; set; }
        public bool HesAirConditioning { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        public virtual User User { get; set; } 
        public virtual Model Model { get; set; }
    }
}
