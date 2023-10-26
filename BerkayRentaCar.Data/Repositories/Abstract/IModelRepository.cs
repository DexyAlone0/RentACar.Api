using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Domain.Entities;

namespace BerkayRentaCar.Data.Repositories.Abstract
{
    public interface IModelRepository
    {
        Task<IReadOnlyList<Model>> GetAllAsync();
        Task<IReadOnlyList<Model>> GetByBrandIdAsync(ModelQueryRequest request);

        Task CreateModelAsync(CreateModelCommandRequest request,int fileId);
    }
}
