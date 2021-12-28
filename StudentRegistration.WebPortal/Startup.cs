using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using StudentRegistration.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StudentRegistration.Services.Repository;
using StudentRegistration.Services.IRepository;
using Microsoft.Extensions.Logging;

//using Microsoft.AspNetCore.Identity.UI.Services;

namespace StudentRegistration.WebPortal
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //error start
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //entityframework configuration
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            //services.AddSingleton<IStuRegistration, StuRegistration>();
            //services.AddScoped<IStuRegistration, StuRegistration>();
            services.AddTransient<IStuRegistration, StuRegistration>();
            services.AddTransient<ISendSMS, SendSMS>();
            services.AddSession();
            services.AddMvc();
            services.AddMvcCore();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ApplicationDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            
            db.Database.EnsureCreated();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });
        }

    }
}
