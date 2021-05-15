using System;
using TypecastAPI.Application.Interfaces;
using TypecastAPI.Application.Services;
using TypecastAPI.Domain.Interfaces;
using TypecastAPI.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using TypecastAPI.Domain.Models;

namespace TypecastAPI.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IRepository<Basket>, Repository<Basket>>();
            services.AddScoped<IBasketService, BasketService>();

        }
    }
}
