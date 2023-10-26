using BerkayRentaCar.Application.BrandService;
using BerkayRentaCar.Contract.Response.Brand;
using Microsoft.AspNetCore.Mvc;


namespace BerkayRentaCar.Controllers
{
    public class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }
        [Route("all")]
        [HttpGet]
        public async Task<IReadOnlyList<BrandQueryResponse>> GetAll()
        {
            return await brandService.GetAllAsync();
        }
    }
}
