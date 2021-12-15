using ApiMvcIp2021.Data.AppDbContext;
using ApiMvcIp2021.Data.Data.Interfaces;
using ApiMvcIp2021.Data.Data.Repositorio;
using ApiMvcIp2021.Data.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMvcIp2021
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
			byte[] securityKey = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));
			int minutosTiempoSesion = Configuration.GetValue<int>("MinutosTiempoSesion");
			string assemblyName = typeof(ApplicationDbContext).Namespace;

			services.AddControllers()
					.AddNewtonsoftJson();

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), optionsBuilder => 
					optionsBuilder.MigrationsAssembly(assemblyName)));

			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyMethod()
						   .AllowAnyHeader()
						   .Build();
					});
			});

			services.ConfigureApplicationCookie(o => {
				o.ExpireTimeSpan = TimeSpan.FromMinutes(minutosTiempoSesion);
				o.SlidingExpiration = true;
			});

			services.AddAuthentication(authConfig =>
			{
				authConfig.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				authConfig.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(securityKey),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			services.AddScoped<IUnidadTrabajo, UnidadTrabajo>();
			services.AddScoped<ISesionService, SesionService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseDefaultFiles();
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();
			app.UseCors("CorsPolicy");
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
