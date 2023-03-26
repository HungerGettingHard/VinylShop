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
            services.AddApplicationServices();
            services.AddValidators();
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<VinylShopDbContext>();
            services.AddScoped<IVinylShopDbContext, VinylShopDbContext>();
            return services;
        }

        private static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GenreRequestDto>, GenreRequestValidator>();
            services.AddScoped<IValidator<PersonRequestDto>, PersonRequestValidator>();
            services.AddScoped<IValidator<RegisterPersonRequestDto>, RegisterPersonRequestValidator>();

            services.AddScoped<IValidationService<GenreRequestDto>, ValidationService<GenreRequestDto>>();
            services.AddScoped<IValidationService<PersonRequestDto>, ValidationService<PersonRequestDto>>();
            services.AddScoped<IValidationService<RegisterPersonRequestDto>, ValidationService<RegisterPersonRequestDto>>();
            return services;
        }
    }
}
