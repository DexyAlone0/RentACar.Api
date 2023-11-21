namespace BerkayRentaCar.Contract.Response.Model;

public class ModelResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string FuelTypeName { get; set; } = string.Empty;
    public string GearTypeName { get; set; } = string.Empty;
    public int FileId { get; set; }
        
}