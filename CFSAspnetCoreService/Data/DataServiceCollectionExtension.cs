using CFSAspnetCoreService.Data.Repositories;
using CFSAspnetCoreService.Data.Repositories.Contracts;
using CFSAspnetCoreService.Data.UoW;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CFSAspnetCoreService.Data
{
    public static class DataServiceCollectionExtension
    {
        /// <summary>
		/// Registers unitofwork dependecies
		/// </summary>
		/// <param name="services">service collection object</param>
		public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>()
                    //lazy loading
                    .AddScoped(x => new Lazy<IUnitOfWork>(x.GetService<IUnitOfWork>));            
        }
    }
}
