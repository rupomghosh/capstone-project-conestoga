using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DefectTracking.Data;
using DefectTracking.Models;
using NToastNotify;

namespace DefectTracking
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();

        /// <summary>
        /// EF Core uses this method at design time to access the DbContext
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>()
                        .UseDefaultServiceProvider(options => options.ValidateScopes = false);
                    });
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Use this method to add services to program and for database connection string
        /// </summary>
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
            {
                ProgressBar = true,
                Timeout = 2000
            });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddHttpContextAccessor();
            services.AddDbContext<DefectTrackingContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefectTrackingContext")));
            

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<DefectTrackingContext>().AddDefaultTokenProviders();


        }

        /// <summary>
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseNToastNotify();
            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=LogIn}/{id?}");
            });
            
        }
    }
}
