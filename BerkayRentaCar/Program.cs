using BerkayRentaCar.Data.Context;
using BerkayRentaCar.Extensions;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using TnActivationCore.Repository.Mssql;
using TnActivationCore.Repository.Mssql.GenericRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
builder.Services.AddControllers();
var env = builder.Environment;
var connectionString = builder.Configuration.GetConnectionString("BerkayRentaCarContext");
builder.Services.AddGenericRepository<BerkayRentaCarContext>();
builder.Services.AddQueryRepository<BerkayRentaCarContext>();
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<BerkayRentaCarContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddSwagger(env);
var app = builder.Build();
app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyOrigin();
});
// Configure the HTTP request pipeline.
app.UseSwaggerWithUi(env);
app.UseAuthorization();

app.MapControllers();

app.Run();
