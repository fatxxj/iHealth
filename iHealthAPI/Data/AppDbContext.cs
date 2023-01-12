using iHealthAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace iHealthAPI.Data
{
    public class AppDbContext : DbContext
    {
        private const string appUser = "SampleApplication";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            //Database.EnsureCreated();
            if (httpContextAccessor != null)
            {
                _httpContextAccessor = httpContextAccessor;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}





        public DbSet<User> User { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
    }
}
