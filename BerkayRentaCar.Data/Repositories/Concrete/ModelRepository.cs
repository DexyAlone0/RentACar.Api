using System.Linq.Expressions;
using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Domain.Entities;
using System.Runtime.InteropServices;
using BerkayRentaCar.Contract.Response.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using TnActivationCore.Repository.Mssql.GenericRepository;
using TnActivationRandevu.Common.Extensions;

namespace BerkayRentaCar.Data.Repositories.Concrete
{
    public class ModelRepository : IModelRepository
    {
        private readonly IGenericRepository genericRepository;


        public ModelRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IReadOnlyList<Model>> GetAllAsync()
        {
            return await this.genericRepository.GetListAsync<Model>();
        }

        public async Task<IReadOnlyList<Model>> GetByBrandIdAsync(ModelQueryRequest request)
        {
            return await this.genericRepository.GetListAsync<Model>(x => x.BrandId == request.BrandId);
        }

        public async Task<ModelResponse> GetByModelIdAsync(int modelId)
        {
            Expression<Func<Model, bool>> expression = LinqExpressionBuilder.New<Model>(x => x.Id == modelId);

            Func<IQueryable<Model>, IIncludableQueryable<Model, object>> includes = x =>
                x.Include(x => x.FuelType).Include(x => x.GearType).Include(x => x.Brand);
            var result = await this.genericRepository.GetAsync(expression, includes);
            return new ModelResponse()
            {
                Id = result.Id,
                Name = result.Name,
                FuelTypeName = result.FuelType.Name,
                GearTypeName = result.GearType.Name,
                BrandName = result.Brand.Name,
                FileId = result.FileId,
            };
        }

        public async Task CreateModelAsync(CreateModelCommandRequest request, int fileId)
        {
            var model = new Model
            {
                Name = request.Name,
                BrandId = request.BrandId,
                FuelTypeId = request.FuelTypeId,
                GearTypeId = request.GearTypeId,
                CountOfSeats = request.CountOfSeats,
                CaseTypeId = request.CaseTypeId,
                FileId = fileId
            };
            await this.genericRepository.AddAsync(model);
            await this.genericRepository.SaveChangesAsync();
        }

        public async Task UpdateModelAsync(ModelUpdateRequest model)
        {
            var modelUpdate = this.genericRepository.GetQueryable<Model>().FirstOrDefault(x => x.Id == model.Id);
            if (modelUpdate is null)
            {
                throw new Exception("Model bulunamadı");
            }

            modelUpdate.Name = model.Name;
            modelUpdate.BrandId = model.BrandId;
            modelUpdate.CaseTypeId = model.CaseTypeId;
            modelUpdate.GearTypeId = model.GearTypeId;
            modelUpdate.FuelTypeId = model.FuelTypeId;
            modelUpdate.CountOfSeats = model.CountOfSeats;

            // var carUpdate = new Model
            // {
            //     Name = model.Name,
            //     BrandId = model.BrandId,
            //     FuelTypeId = model.FuelTypeId,
            //     GearTypeId = model.GearTypeId,
            //     CountOfSeats = model.CountOfSeats,
            //     CaseTypeId = model.CaseTypeId,
            //     Id = model.Id,
            //     FileId = 1
            // };
            this.genericRepository.Update(modelUpdate);
            await this.genericRepository.SaveChangesAsync();
        }
    }
}