using BerkayRentaCar.Application.ModelService;
using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;
using Microsoft.AspNetCore.Mvc;

namespace BerkayRentaCar.Controllers
{
    public class ModelController : ControllerBase
    {
        private readonly IModelService modelService;
       
        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        [Route("model/{brandId}")]
        [HttpGet]
        public async Task<IReadOnlyList<ModelQueryResponse>> GetByBrandId(ModelQueryRequest modelQueryRequest)
        {
            return await modelService.GetByBrandIdAsync(modelQueryRequest);
        }
        [Route("model")]
        [HttpPost]
        public async Task CreateModel(CreateModelCommandRequest request)
        {
            await this.modelService.CreateModelAsync(request);
        }

    }
}
