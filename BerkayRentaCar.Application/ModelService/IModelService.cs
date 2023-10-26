using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;

namespace BerkayRentaCar.Application.ModelService
{
    public interface IModelService
    {
        Task<IReadOnlyList<ModelQueryResponse>> GetAllAsync();
        Task<IReadOnlyList<ModelQueryResponse>> GetByBrandIdAsync(ModelQueryRequest request);

        Task CreateModelAsync(CreateModelCommandRequest request);
    }
}
