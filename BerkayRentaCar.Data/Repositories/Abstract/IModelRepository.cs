using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;
using BerkayRentaCar.Domain.Entities;

namespace BerkayRentaCar.Data.Repositories.Abstract
{
    public interface IModelRepository
    {
        Task<IReadOnlyList<Model>> GetAllAsync();
        Task<IReadOnlyList<Model>> GetByBrandIdAsync(ModelQueryRequest request);
        Task <ModelResponse> GetByModelIdAsync(int modelId);
        Task CreateModelAsync(CreateModelCommandRequest request,int fileId);
        Task UpdateModelAsync(ModelUpdateRequest model);
    }
}
