using BerkayRentaCar.Contract.Request.CarRequest;
using BerkayRentaCar.Contract.Response.CarResponse;

namespace BerkayRentaCar.Application.CarQueryService
{
    public interface ICarQueryService
    {
        IReadOnlyCollection<CarDetailQueryResponse> GetCarQuery (CarQueryRequest request);
        Task<CarDetailQueryResponse?> GetCarDetailQuery(CarDetailQueryRequest request);
    }
}
