namespace BerkayRentaCar.Contract.Response.File;

public class FileQueryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Data { get; set; }
}