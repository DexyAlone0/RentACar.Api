using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Domain.Entities;
using TnActivationCore.Repository.Mssql.GenericRepository;

namespace BerkayRentaCar.Data.Repositories.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IGenericRepository genericRepository;
        public BrandRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IReadOnlyList<Brand>> GetAllAsync()
        {
            return await this.genericRepository.GetListAsync<Brand>();
        }
    }
}
