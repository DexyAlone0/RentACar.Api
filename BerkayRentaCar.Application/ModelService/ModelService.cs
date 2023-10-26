using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;
using BerkayRentaCar.Data.Repositories.Abstract;
using Microsoft.AspNetCore.Http;

namespace BerkayRentaCar.Application.ModelService
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository modelRepository;
        private readonly IFileRepository fileRepository;
        public ModelService(IModelRepository modelRepository, IFileRepository fileRepository)
        {
            this.modelRepository = modelRepository;
            this.fileRepository = fileRepository;
        }


        public async Task CreateModelAsync(CreateModelCommandRequest request)
        {
            var fileid = await this.fileRepository.CreateFileAsync(await GetFile(request.File));
            await this.modelRepository.CreateModelAsync(request, fileid);
        }

        private async Task<Domain.Entities.File> GetFile(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);


                return new Domain.Entities.File()
                {
                    Data = memoryStream.ToArray(),
                    ContentType = formFile.ContentType,
                    Name = formFile.FileName,
                };
            }
        }

        public async Task<IReadOnlyList<ModelQueryResponse>> GetAllAsync()
        {
            var modelList = await this.modelRepository.GetAllAsync();
            return modelList.Select(m => new ModelQueryResponse
            {
                Id = m.Id,
                Name = m.Name,
            }).ToList();
        }

        public async Task<IReadOnlyList<ModelQueryResponse>> GetByBrandIdAsync(ModelQueryRequest request)
        {
            var modelList = await this.modelRepository.GetByBrandIdAsync(request);
            return modelList.Select(m => new ModelQueryResponse
            {
                Id = m.Id,
                Name = m.Name,
            }).ToList();
        }
    }
}
