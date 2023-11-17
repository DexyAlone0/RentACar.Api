using BerkayRentaCar.Data.Context;
using BerkayRentaCar.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JWTToken:ValidIssuer"],
        ValidAudience = builder.Configuration["JWTToken:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();
var app = builder.Build();
app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyOrigin();
});
// Configure the HTTP request pipeline.
app.UseSwaggerWithUi(env);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
