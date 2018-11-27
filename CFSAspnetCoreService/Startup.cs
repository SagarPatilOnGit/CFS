using CFSAspnetCoreService.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CFSAspnetCoreService
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//Register mvc dependencies to collection
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			//Register swagger dependencies to collection
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "API"
				});				
			});
			//Register cors dependencies to collection
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder.WithOrigins("http://localhost:4200"));
			});
			//Register cfs db context 
			services.AddDbContext<CfsContext>(options => {
				options.UseSqlServer(@"Server=.; Database=CFS;Integrated Security=True;Trusted_Connection=True", 
					providerOptions => providerOptions.CommandTimeout(60))
					.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});
            //Add app repos
            services.AddRepositories();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseMvc();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
				c.RoutePrefix = string.Empty;
			});
			// Shows UseCors with named policy.
			app.UseCors("AllowSpecificOrigin");
		}
	}
}
