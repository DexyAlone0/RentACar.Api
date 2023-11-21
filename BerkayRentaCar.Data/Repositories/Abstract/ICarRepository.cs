using BerkayRentaCar.Contract.Request.CarRequest;
using BerkayRentaCar.Contract.Response.CarResponse; 
using BerkayRentaCar.Domain.Entities;


namespace BerkayRentaCar.Data.Repositories.Abstract
{
    public interface ICarRepository 
    {
         Task<IReadOnlyCollection<CarDetailQueryResponse>> GetCarListAsync(CarQueryRequest request);
         Task<CarDetailQueryResponse?> GetCarDetailQueryAsync(CarDetailQueryRequest request);
         Task UpdateCarAsync (UpdateCarRequest request);

    }
}
