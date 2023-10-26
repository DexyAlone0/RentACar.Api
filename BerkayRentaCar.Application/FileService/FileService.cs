using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Data.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Application.FileService
{
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public async Task<Domain.Entities.File> GetFileByIdAsync(int id)
        {
            return await this.fileRepository.GetFileByIdAsync(id);
        }
    }
}

