using EntityTypeConfigExample.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityTypeConfigExample.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Add the DbSet for the Person model.
        // Tell Entity Framework that the Person model is a table in the database.
        public DbSet<Person> People { get; set; }
        // Override the OnModelCreating method to apply the EntityTypeConfiguration.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method to apply the Identity Tables from the IdentityDbContext.
            base.OnModelCreating(modelBuilder);  // Apply the Identity Tables from the IdentityDbContext.
            // Continue with the applications tables.
            // This Applys each table in a way that allows the ForeignKeys to be set.
            modelBuilder.ApplyConfiguration(new Person());
        }
        // Add the constructor to pass the DbContextOptions to the base class.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}