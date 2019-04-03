namespace MasGlobal.Test.Web.DependencyInjection
{
    using MasGlobal.Test.Application.Services;
    using MasGlobal.Test.Domain.Services;
    using MasGlobal.Test.Infrastructure.Data.DBFactory;
    using MasGlobal.Test.Infrastructure.Data.EntityFramework;
    using MasGlobal.Test.Infrastructure.Data.Repositories;
    using MasGlobal.Test.Infrastructure.Framework.RepositoryPattern;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Resolver la dependencia de los servicios
        /// </summary>
        /// <param name="services"></param>
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(configuration);

            // Application
            services.AddScoped<IEmployeesApplicationService, EmployeesApplicationService>();

            // Domain
            services.AddScoped<IMasglobalTestApiService, MasglobalTestApiService>();

            // Infra - Data

            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<DbContext>(sp => sp.GetService<DBContext>());

            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                //options.UseOpenIddict();
            });
        }
    }
}
