using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using IINTOS.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IINTOS.Models;
using IINTOS.Services;
using Microsoft.Extensions.Logging;

namespace IINTOS
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

			services.AddDbContext<IINTOSContext>(options =>
					options.UseSqlServer(
							Configuration.GetConnectionString("DefaultConnection")));

			services.AddDefaultIdentity<User>(options =>
			{
				options.Password.RequiredLength = 6;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
			})
					.AddRoles<IdentityRole>()
					.AddEntityFrameworkStores<IINTOSContext>();

			services.AddControllersWithViews();
			services.AddRazorPages();

			EmailSender emailServer = new EmailSender(Configuration["EmailSender:Host"],
			Configuration.GetValue<int>("EmailSender:Port"),
			Configuration.GetValue<bool>("EmailSender:EnableSSL"),
			Configuration["EmailSender:UserName"],
			Configuration["EmailSender:Password"]);

			services.AddTransient<EmailSender, EmailSender>(i =>
			emailServer
			);

			services.AddDataProtection();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseDatabaseErrorPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
									name: "default",
									pattern: "{controller=Home}/{action=Index}/{id?}");
				endpoints.MapRazorPages();
			});
		}
	}
}
