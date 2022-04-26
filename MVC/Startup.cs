using Microsoft.AspNetCore.Builder;

namespace MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        //This Method gets called by the runtime. Use This method to add services to 
        public void ConfiguresServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }
        //This Method gets called by the runtime. Use This method to configure the HTTP request
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");   
                //The default HSTS is 30 days. you may want to change this for production
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "defauft",
                pattern: "{Controller=Home}/{action=Index}/{id?}");
            });
        }    
        
    }
}
