using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReserB.Middleware;
using ReserB.Services;
using ReserB.Services.Contracts;

namespace ReserB
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));
			services.AddDistributedMemoryCache();
			services.AddSession();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddSingleton<ICustomerRepository>(x =>
				ActivatorUtilities.CreateInstance<CustomerRepository>(x, "cliente")
			);
			services.AddSingleton<IProviderRepository>(x =>
				ActivatorUtilities.CreateInstance<ProviderRepository>(x, "proveedor")
			);
			services.AddSingleton<ISectorRepository>(x =>
				ActivatorUtilities.CreateInstance<SectorRepository>(x, "rubro")
			);
			services.AddSingleton<ICategoryRepository>(x =>
				ActivatorUtilities.CreateInstance<CategoryRepository>(x, "categoria")
			);
			services.AddSingleton<ISpaceRepository>(x =>
				ActivatorUtilities.CreateInstance<SpaceRepository>(x, "espacio")
			);
			services.AddSingleton<IReservationRepository>(x =>
				ActivatorUtilities.CreateInstance<ReservationRepository>(x, "reserva")
			);
			services.AddSingleton<LoginService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseCors("MyPolicy");
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseSession();
			app.UseAuthorization();
			app.UseMvc();
		}
	}
}
