using BerkayRentaCar.Application.FileService;
using BerkayRentaCar.Application.ModelService;
using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;
using Microsoft.AspNetCore.Mvc;

namespace BerkayRentaCar.Controllers
{
    public class FileController : ControllerBase
    {
        private readonly IFileService fileService;
       
        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [Route("file/{fileId}")]
        [HttpGet]
        public async Task<FileContentResult> GetByFileId(int fileId)
        {
            var file = await this.fileService.GetFileByIdAsync(fileId);
            return File(file.Data, file.ContentType, file.Name+".png");
        } 
    }
}
