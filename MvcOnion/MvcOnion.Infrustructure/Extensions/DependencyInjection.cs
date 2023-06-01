using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcOnion.Domain.IRepositories;
using MvcOnion.Infrustructure.ModelContext;
using MvcOnion.Infrustructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Infrustructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfDependencyResolver(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                string connectionString = configuration.GetConnectionString(ApplicationDbContext._connectionString);

                x.UseSqlServer(connectionString);
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>()
                    .AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
