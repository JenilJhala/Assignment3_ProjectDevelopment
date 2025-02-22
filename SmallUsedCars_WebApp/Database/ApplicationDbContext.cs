using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallUsedCars_WebApp.Entities;
using SmallUsedCars_WebApp.Models;

namespace SmallUsedCars_WebApp.Database
{
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Identity Tables (Do NOT explicitly define Identity-related DbSets)

        public DbSet<VehicleViewModel> Vehicles { get; set; } // Custom table
    }
}
