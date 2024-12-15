using app1.Filtters;
using app1.Models;
using app1.Reposatory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace app1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options=>options.Filters.Add(new HandleErrorMetaData()));
			builder.Services.AddSession(x=>x.IdleTimeout=TimeSpan.FromMinutes(15));
            builder.Services.AddDbContext<ITIContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
				option => {
					option.Password.RequireLowercase = false;
					option.Password.RequireUppercase = false;
					option.Password.RequireNonAlphanumeric = false;
					option.Password.RequireDigit = false;
					option.Password.RequiredLength=4;
					
					
					}
				


				)
			.AddEntityFrameworkStores<ITIContext>();
			builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
			builder.Services.AddScoped<IEmployeRepo, EmplyeeRepo>();
			var app = builder.Build();
			#region MyRegion


			//app.Use(async (httpContext, Next) =>
			//{
			//	await httpContext.Response.WriteAsync("1)Middle Ware One\n");
			//	await Next.Invoke();
			//	await httpContext.Response.WriteAsync("1)Middle//////// Ware One\n");



			//});
			//app.Use(async (httpContext, Next) =>
			//{
			//	await httpContext.Response.WriteAsync("2)Middle Ware Two\n");
			//	await Next.Invoke();
			//	await httpContext.Response.WriteAsync("2)Middle||||||||| Ware Two\n");


			//});
			//app.Run(async (httpContext) =>
			//{
			//	await httpContext.Response.WriteAsync("3)Middle Ware three\n");


			//});

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
            //app.MapControllerRoute("route1", "r1/{name}/{age:int:max(50)}", new { Controller = "Route", Action = "Method1" });
			app.MapControllerRoute(name: "route2", "r/{action=Method1}", new { Controller = "Route" });


            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=account}/{action=login}/{id?}");


			#endregion
			app.Run();

		}
	}
}
