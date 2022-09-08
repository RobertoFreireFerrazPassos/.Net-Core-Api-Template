using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Services;
using Product.Domain.Repositories;
using Product.Domain.Services;
using Product.Infra.DataAccess;

namespace Product.Infra.CrossCutting.Ioc
{
    public static class IoCExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(opt => opt.UseInMemoryDatabase("DataBase"));

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
