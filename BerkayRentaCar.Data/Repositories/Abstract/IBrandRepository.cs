using BerkayRentaCar.Domain.Entities;

namespace BerkayRentaCar.Data.Repositories.Abstract
{
    public interface IBrandRepository
    {
        Task<IReadOnlyList<Brand>> GetAllAsync();
    }
}
