using BerkayRentaCar.Domain.Entities;
using Microsoft.EntityFrameworkCore; 

namespace BerkayRentaCar.Data.Context
{
    public class BerkayRentaCarContext : DbContext
    {
        public BerkayRentaCarContext(DbContextOptions<BerkayRentaCarContext> options) : base(options)
        {

        }
         
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; } 
        public DbSet<CaseType> CaseTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<GearType> GearTypes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Domain.Entities.File> Files { get; set; }

    }
}
