using BerkayRentaCar.Contract.Request.ModelRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Application.FileService
{
    public interface IFileService
    {
        Task<Domain.Entities.File> GetFileByIdAsync(int id);
    }
}
