using Microsoft.Extensions.DependencyInjection;
using MvcOnion.Application.IServices;
using MvcOnion.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Application.Exstensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AppDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AutorService>()
                    .AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
