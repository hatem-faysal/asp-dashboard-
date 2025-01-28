using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testcrud.Models;

namespace testcrud.Data
{
    public class EcommerceDbContext : IdentityDbContext<ApplicationUser>
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {


        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PublicUser> PublicUsers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<JobService> JobServices { get; set; }
        public DbSet<JobRecruitment> JobRecruitments { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
    }
}
