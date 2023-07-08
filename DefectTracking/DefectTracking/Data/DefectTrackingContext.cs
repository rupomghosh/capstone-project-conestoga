using DefectTracking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DefectTracking.Data
{
    public class DefectTrackingContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Creates a default admin user
        /// </summary>
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Sesame123#";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            // if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        /// <summary>
        /// Creates a default employee user
        /// </summary>
        public static async Task CreateEmployeeUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string username = "SwagSter";
            string password = "SwagMaster123#";
            string roleName = "Employee";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            // if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        /// <summary>
        /// Creates a default supplier user
        /// </summary>
        public static async Task CreateSupplierUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string username = "SwagMaster";
            string password = "SwagSter123#";
            string roleName = "Supplier";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            // if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        //Manufacturing Defects DB Context (Adding into the database)
        public DbSet<ManufacturingDefects> ManufacturingDefects { get; set; }

        //Delivery Defects DB Context (Adding into the database)
        public DbSet<DeliveryDefects> DeliveryDefects { get; set; }

        //Warranty Defects DB Context (Adding into the database)
        public DbSet<WarrantyDefects> WarrantyDefects { get; set; }

        //Constructor for the Defect Tracking Context
        public DefectTrackingContext()
        {
            
        }

        public DefectTrackingContext(DbContextOptions<DefectTrackingContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ManufacturingDefects>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<DeliveryDefects>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<WarrantyDefects>(entity => 
            {
                entity.HasKey(x => x.Id);
            });
        }
       
    }
}
