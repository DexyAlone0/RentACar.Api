namespace BerkayRentaCar.Contract.Request.CarRequest;

public class UpdateCarRequest
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int ModelId { get; set; }
    public bool HesAirConditioning { get; set; }
}