using Microsoft.EntityFrameworkCore;
using StaffPortal.Server.Models;

namespace StaffPortal.Server.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Gender)
                .WithMany()
                .HasForeignKey(s => s.GenderId);

            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Qualification)
                .WithMany()
                .HasForeignKey(s => s.QualificationId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Qualification>().ToTable("Qualification");
 
            modelBuilder.Seed();
        }
    }
}
