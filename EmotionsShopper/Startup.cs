using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; 
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using EmotionsShopper.Repository;
using EmotionsShopper.Fakes;

namespace EmotionsShopper
{
    public class Startup
    {

        IConfigurationRoot Configuration; 

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build(); 
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //set up EF
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:EmotionsShopperProducts:ConnectionString"])); 
            services.AddTransient<IProductRepository,EFProductRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage(); //#TODO remove from deployed version. 
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: null, template: "{category}/Page{page:int}", defaults: new { controller = "Product", action = "List"});
                routes.MapRoute(name: null, template: "Page{page:int}", defaults: new { Controller = "Product", action = "List", page = 1 });
                routes.MapRoute(name: null, template: "{category}", defaults: new { Controller = "Product", action = "List", page = 1 });
                routes.MapRoute(name: null, template: "", defaults: new { Controller = "Product", action = "List", page = 1 });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            FakeSeedData.Populate(app); 
        }
    }
}
