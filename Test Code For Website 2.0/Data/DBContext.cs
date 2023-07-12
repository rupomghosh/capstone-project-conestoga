using Test_Code_For_Website_2._0.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Test_Code_For_Website_2._0.Data
{
    public class DBContext : IdentityDbContext
    {
        public DbSet<LoopClass> LoopClass { get; set; }

        public DBContext() 
        {
            
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoopClass>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

        }
    }
}
