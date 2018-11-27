using CFSAspnetCoreService.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CFSAspnetCoreService
{
	public class Program
    {
        public static void Main(string[] args)
        {
	        var host = CreateWebHostBuilder(args).Build();
				Migrate(host).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

	    public static IWebHost Migrate(IWebHost webhost)
	    {
		    using (var scope = webhost.Services.GetService<IServiceScopeFactory>().CreateScope())
		    {
			    using (var dbContext = scope.ServiceProvider.GetRequiredService<CfsContext>())
			    {
				    if (dbContext.Database.EnsureCreated())
						dbContext.Database.Migrate();
				}
		    }
		    return webhost;
	    }
	}
}
