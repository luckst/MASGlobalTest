namespace MasGlobal.Test.Web.DependencyInjection
{
    using MasGlobal.Test.Application.Services;
    using MasGlobal.Test.Domain.Services;
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

        }
    }
}
