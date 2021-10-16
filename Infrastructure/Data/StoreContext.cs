using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{

    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products {get;set;}
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            //because of sqlite doesn't support decimal :
            if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite")
            {
                //to getting entity types in modelBuilder
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                        var properties = entityType.ClrType.GetProperties()
                        .Where(p=>p.PropertyType == typeof(decimal));
                        foreach (var property in properties)
                        {
                            modelBuilder.Entity(entityType.Name).Property(property.Name)
                            .HasConversion<double>();
                        }
                    
                }
            }
        }
    }
}