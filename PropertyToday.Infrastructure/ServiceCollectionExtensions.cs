using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyToday.Application.Repositories;
using PropertyToday.Infrastructure.Context;
using PropertyToday.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            return services.AddTransient<IPropertyRepo,PropertyRepo>()
                           .AddDbContext<PropertyTodayDbContext>(o =>
                           {
                               o.UseSqlServer(configuration.GetConnectionString("Conn"));
                           });       
        }
    }
}
