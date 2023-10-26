namespace BerkayRentaCar.Data.Repositories.Abstract
{
    public interface IFileRepository
    {
        Task<int> CreateFileAsync(Domain.Entities.File file);
        Task<Domain.Entities.File> GetFileByIdAsync(int id);
    }
}
