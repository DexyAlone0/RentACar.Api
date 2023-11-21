using BerkayRentaCar.Application.ModelService;
using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Response.Model;
using BerkayRentaCar.Domain.Entities;
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
        [Route("getModel/{modelId}")]
        [HttpGet]
        public async Task<ModelResponse> GetByModelId(int modelId)
        {
            return await modelService.GetByModelIdAsync(modelId);
        }
        [Route("allModel")]
        [HttpGet]
        public async Task<IReadOnlyList<ModelQueryResponse>> GetAll()
        {
            return await modelService.GetAllAsync();
        }
        [Route("model")]
        [HttpPost]
        public async Task CreateModel(CreateModelCommandRequest request)
        {
            await this.modelService.CreateModelAsync(request);
        }
        [Route("modelUpdate")]
        [HttpPut]
        public async Task ModelUpdate([FromBody]ModelUpdateRequest model)
        {
            await this.modelService.UpdateModelAsync(model);
        }


    }
}
