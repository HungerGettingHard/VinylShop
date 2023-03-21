using Application.Common.DbContext;
using Application.Common.Interfaces;
using Application.Interfaces;
using Persistence.Services;
using Persistence.DbContext;
using Persistence.Repository;
using FluentValidation;
using Application.Models.Validators;
using Application.Models.Requests;
using Persistence.Behaviours;

namespace VinylShop.ServiceModule
{
    public static class RegistrationModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDatabase();
            services.AddRepository();
            services.AddCrudServices();
            services.AddValidators();
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

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GenreRequestDto>, GenreRequestValidator>();

            services.AddScoped<IValidationService<GenreRequestDto>, ValidationService<GenreRequestDto>>();
            return services;
        }
    }
}
