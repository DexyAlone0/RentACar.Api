using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;
using BerkayRentaCar.Domain.Entities;

namespace BerkayRentaCar.Application.ModelService
{
    public interface IModelService
    {
        Task<IReadOnlyList<ModelQueryResponse>> GetAllAsync();
        Task<IReadOnlyList<ModelQueryResponse>> GetByBrandIdAsync(ModelQueryRequest request);
        Task <ModelResponse> GetByModelIdAsync(int modelId);
        Task CreateModelAsync(CreateModelCommandRequest request);
        Task UpdateModelAsync(ModelUpdateRequest model);
    }
}
