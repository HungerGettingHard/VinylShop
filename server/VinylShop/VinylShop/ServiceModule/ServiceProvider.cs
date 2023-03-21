using Application.Common.DbContext;
using Application.Common.Interfaces;
using Application.Interfaces;
using Persistence.Services;
using Persistence.DbContext;
using Persistence.Repository;

namespace VinylShop.ServiceModule
{
    public static class RegistrationModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddRepository();
            services.AddCrudServices();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<VinylShopDbContext>();
            services.AddScoped<IVinylShopDbContext, VinylShopDbContext>();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddCrudServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
            return services;
        }
    }
}
