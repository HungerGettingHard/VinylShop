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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IOrderDestinationService, OrderDestinationService>();
            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GenreRequestDto>, GenreRequestValidator>();
            services.AddScoped<IValidator<PersonRequestDto>, PersonRequestValidator>();
            services.AddScoped<IValidator<RegisterPersonRequestDto>, RegisterPersonRequestValidator>();
            services.AddScoped<IValidator<ProductRequestDto>, ProductRequestValidator>();
            services.AddScoped<IValidator<UpdateShoppingCartRequestDto>, UpdateShoppingCartRequestValidator>();
            services.AddScoped<IValidator<AddShoppingCartRequestDto>, AddShoppingCartRequestValidator>();
            services.AddScoped<IValidator<OrderStatusRequestDto>, OrderStatusValidator>();
            services.AddScoped<IValidator<OrderDestinationRequestDto>, OrderDestinationValidator>();

            services.AddScoped<IValidationService<GenreRequestDto>, ValidationService<GenreRequestDto>>();
            services.AddScoped<IValidationService<PersonRequestDto>, ValidationService<PersonRequestDto>>();
            services.AddScoped<IValidationService<RegisterPersonRequestDto>, ValidationService<RegisterPersonRequestDto>>();
            services.AddScoped<IValidationService<ProductRequestDto>, ValidationService<ProductRequestDto>>();
            services.AddScoped<IValidationService<UpdateShoppingCartRequestDto>, ValidationService<UpdateShoppingCartRequestDto>>();
            services.AddScoped<IValidationService<AddShoppingCartRequestDto>, ValidationService<AddShoppingCartRequestDto>>();
            services.AddScoped<IValidationService<OrderStatusRequestDto>, ValidationService<OrderStatusRequestDto>>();
            services.AddScoped<IValidationService<OrderDestinationRequestDto>, ValidationService<OrderDestinationRequestDto>>();
            return services;
        }
    }
}
