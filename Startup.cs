using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using React.AspNet;

namespace React.Sample.Webpack.CoreMvc
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddMvc();
			services.AddControllersWithViews();

			services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
				.AddChakraCore();

			services.AddReact();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			// Build the intermediate service provider then return it
			//services.BuildServiceProvider();
		}

		public void Configure(IApplicationBuilder app, IHostEnvironment env)
		{
			// Initialise ReactJS.NET. Must be before static files.
			app.UseReact(config =>
			{
				config
					.SetReuseJavaScriptEngines(true)
					.SetLoadBabel(false)
					.SetLoadReact(false)
					.SetReactAppBuildPath("~/dist");
			});

			if (env.IsDevelopment())
			{
					app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute("default", "{path?}", new { controller = "Home", action = "Index" });
                //endpoints.MapControllerRoute("comments-root", "comments", new { controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("comments", "comments/page-{page}", new { controller = "Home", action = "Comments" });
            });
		}
	}
}