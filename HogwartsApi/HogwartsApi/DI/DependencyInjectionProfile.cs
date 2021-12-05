using HogwartsApi.Application;
using HogwartsApi.DataAccess;
using HogwartsApi.DataAccess.Repositories;
using HogwartsApi.DataAccess.Repositories.IRepositories;
using HogwartsApi.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsApi.DI
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyInjectionProfile
    {
        private readonly IConfiguration Configuration;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public DependencyInjectionProfile(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void InjectDependencies(IServiceCollection services)
        {
            services.AddDbContext<ApiDBContext>(options =>
            {
                options.UseInMemoryDatabase("Hogwarts");
            });

            #region Repositorios
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            #region Servicios de aplicación
            services.AddTransient<SolicitudAppService>();
            #endregion

            #region Servicios de dominio
            services.AddTransient<SolicitudDomainService>();
            #endregion

        }
    }
}
