using BerkayRentaCar.Contract.Request.CarRequest;
using BerkayRentaCar.Contract.Response.CarResponse;
using BerkayRentaCar.Data.Repositories.Abstract;

namespace BerkayRentaCar.Application.CarQueryService
{
    public class CarQueryService : ICarQueryService
    {
        private readonly ICarRepository carRepository;
        public CarQueryService(ICarRepository carRepository)
        {
                this.carRepository = carRepository;
        }

        public async Task<CarDetailQueryResponse?> GetCarDetailQuery(CarDetailQueryRequest request)
        {
            return await this.carRepository.GetCarDetailQueryAsync(request);
        }

        public async Task UpdateCarAsync(UpdateCarRequest request)
        {
             await this.carRepository.UpdateCarAsync(request);
        }

        public IReadOnlyCollection<CarDetailQueryResponse> GetCarQuery(CarQueryRequest request)
        {
             return this.carRepository.GetCarListAsync(request).Result;
        }


    }
}
