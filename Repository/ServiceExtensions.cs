using AstudentApplication.Repository.Interface.Wrapper;
using AstudentApplication.Repository.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstudentApplication.Repository
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DatabaseConnectionString"];
            //services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
            services.AddDbContextPool<RepositoryContext>
                (options => options.UseSqlServer(connectionString, sqloptions =>
                {
                    sqloptions.EnableRetryOnFailure(
                                   maxRetryCount: 5,
                                   maxRetryDelay: TimeSpan.FromSeconds(30),
                                   errorNumbersToAdd: new List<int>() { });
                }));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
