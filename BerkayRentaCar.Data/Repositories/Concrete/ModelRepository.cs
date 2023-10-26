using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Domain.Entities;
using TnActivationCore.Repository.Mssql.GenericRepository;

namespace BerkayRentaCar.Data.Repositories.Concrete
{
    public class ModelRepository : IModelRepository
    {
        private readonly IGenericRepository genericRepository;
        public ModelRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IReadOnlyList<Model>> GetAllAsync()
        {
            return await this.genericRepository.GetListAsync<Model>();
        }

        public async Task<IReadOnlyList<Model>> GetByBrandIdAsync(ModelQueryRequest request)
        {
            return await this.genericRepository.GetListAsync<Model>(x => x.BrandId == request.BrandId); 
        }
        public async Task CreateModelAsync(CreateModelCommandRequest request, int fileId)
        {
            var model = new Model
            {
                Name = request.Name,
                BrandId = request.BrandId,
                FuelTypeId = request.FuelTypeId,
                 GearTypeId = request.GearTypeId,
                 CountOfSeats = request.CountOfSeats,
                 CaseTypeId = request.CaseTypeId,
                 FileId = fileId
            };
            await this.genericRepository.AddAsync(model);
            await this.genericRepository.SaveChangesAsync();
        }
    }
}
