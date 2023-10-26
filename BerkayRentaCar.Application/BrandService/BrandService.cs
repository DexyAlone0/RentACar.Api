using BerkayRentaCar.Contract.Response.Brand;
using BerkayRentaCar.Data.Repositories.Abstract;

namespace BerkayRentaCar.Application.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
               this.brandRepository = brandRepository;
        }

        public async Task<IReadOnlyList<BrandQueryResponse>> GetAllAsync()
        {
           var brandList =  await this.brandRepository.GetAllAsync();
            return brandList.Select(b => new BrandQueryResponse
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }
    }
}
