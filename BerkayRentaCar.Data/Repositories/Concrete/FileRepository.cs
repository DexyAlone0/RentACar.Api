using BerkayRentaCar.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnActivationCore.Repository.Mssql.GenericRepository;

namespace BerkayRentaCar.Data.Repositories.Concrete
{
    public class FileRepository : IFileRepository
    {
        private readonly IGenericRepository genericRepository;   
        public FileRepository(IGenericRepository genericRepository)
        {
                this.genericRepository = genericRepository;
        }

        public async Task<int> CreateFileAsync(Domain.Entities.File file)
        {
            await this.genericRepository.AddAsync(file);
            await this.genericRepository.SaveChangesAsync();
            return file.Id;
        }

        public async Task<Domain.Entities.File> GetFileByIdAsync(int id)
        {
            return await this.genericRepository.GetByIdAsync<Domain.Entities.File>(id);
        }
    }
}
