using BerkayRentaCar.Contract.Request.CarRequest;
using BerkayRentaCar.Contract.Response.CarResponse; 
using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using TnActivationCore.Repository.Mssql.GenericRepository;
using TnActivationRandevu.Common.Extensions;

namespace BerkayRentaCar.Data.Repositories.Concrete
{
    public class CarRepository : ICarRepository
    {
        private readonly IGenericRepository genericRepository;
        public CarRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<CarDetailQueryResponse?> GetCarDetailQueryAsync(CarDetailQueryRequest request)
        {
            return await this.genericRepository.GetQueryable<Car>().Where(x=>x.Id == request.CarId).Select(x=> new CarDetailQueryResponse
            {
                CarId = request.CarId,
                BrandName =x.Model.Brand.Name,
                EngineCapacityName = x.EngineCapacity,
                FuelTypeName = x.Model.FuelType.Name,
                GearTypeName = x.Model.GearType.Name,

            }).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<CarDetailQueryResponse>> GetCarListAsync(CarQueryRequest request)
        {
            Expression<Func<Car, bool>> expression = LinqExpressionBuilder.New<Car>(x => x.IsActive);


            if (request.FuelTypeId is not null)
            {
                expression = expression.And(x => x.Model.FuelTypeId == request.FuelTypeId);
            }

            if (request.GearTypeId is not null)
            {
                expression = expression.And(x => x.Model.GearTypeId == request.GearTypeId);
            }


            //EagerLoading
            Func<IQueryable<Car>, IIncludableQueryable<Car, object>> includes = x => x.Include(x => x.Model).Include(x => x.Model.FuelType).Include(x => x.Model.GearType).Include(x => x.Model.Brand);
            var result = await this.genericRepository.GetListAsync(expression, includes);

            ////LazyLoading
            //this.genericRepository.GetQueryable<Car>().Where(expression).Select(x => new CarQueryResponse
            //{
            //    Id = x.Id,
            //    BrandName = x.Model.Brand.Name,
            //    FuelTypeName = x.Model.FuelType.Name,
            //    GearTypeName = x.Model.GearType.Name,
            //    ModelName = x.Model.Name,
            //});

            return result.Select(x => new CarDetailQueryResponse
            {
                CarId= x.Id,
                BrandName = x.Model.Brand.Name,
                FuelTypeName = x.Model.FuelType.Name,
                GearTypeName = x.Model.GearType.Name,
                ModelName = x.Model.Name,
                CreatedDate = x.CreatedDate,
            }).ToList(); 
        }
    }
}
