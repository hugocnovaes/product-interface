using MediatR;
using medTC.Infrastructure.Repositorys.Implementations;
using medTC.Infrastructure.Repositorys.Interfaces;
using medTC.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace medTC.ZAPI.DependencyInjectionEssentials
{
    public static class DI
    {
        public static void DoInjections(this IServiceCollection services)
        {
            // BASE
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AppDomain.CurrentDomain.Load("medTC.ZAPI")));
            services.AddScoped<IMSSQLDatabaseConnection, MSSQLDatabaseConnection>();
            services.AddScoped<IMediator, Mediator>();

            //REPOSITORY
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
