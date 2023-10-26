
using BerkayRentaCar.Contract.Response.Brand;

namespace BerkayRentaCar.Application.BrandService
{
    public interface IBrandService
    {
        Task<IReadOnlyList<BrandQueryResponse>> GetAllAsync();
    }
}
