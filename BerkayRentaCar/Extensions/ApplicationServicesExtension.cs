using BerkayRentaCar.Application.BrandService;
using BerkayRentaCar.Application.CarQueryService;
using BerkayRentaCar.Application.FileService;
using BerkayRentaCar.Application.ModelService;
using BerkayRentaCar.Application.TokenService;
using BerkayRentaCar.Application.UserService;
using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Data.Repositories.Concrete;

namespace BerkayRentaCar.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    { 
        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IBrandService, BrandService>();

        services.AddScoped<ITokenService , TokenService>(); 

        services.AddScoped<ICarQueryService, CarQueryService>();
        services.AddScoped<ICarRepository, CarRepository>();

        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IModelRepository, ModelRepository>();

        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IFileRepository, FileRepository>();
        
        services.AddScoped<IUserService , UserService>();
        services.AddScoped<IUserRepsitory, UserRepository>();

        return services;
    }

   
}