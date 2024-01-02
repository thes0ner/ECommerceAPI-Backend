using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.ServiceRegistrations
{
    public static class ServiceRegistration
    {
        static public void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddDbContext<ECommerceAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            
            service.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
            service.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();

            service.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
            service.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

            service.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            service.AddScoped<IProductQueryRepository, ProductQueryRepository>();
        }
    }
}
