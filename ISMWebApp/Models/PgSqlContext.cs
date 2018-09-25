using Amazon.RDS;
using Microsoft.EntityFrameworkCore;

namespace ISMWebApp.Models
{
    public class PgSqlContext : DbContext
    {
        public PgSqlContext(DbContextOptions<PgSqlContext> options) : base(options) { }

        public DbSet<Visas> Visas { get; set; }
        public DbSet<VisasCategory> VisasCategorys { get; set; }
        public DbSet<VisasPage> VisasPages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Institute> Institutes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<CourseInstitute> CourseInstitutes { get; set; }
        public DbSet<CourseLocation> CourseLocations { get; set; }
        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisasPage>()
                .HasKey(c => new { c.Id, c.Url });

            modelBuilder.Entity<VisasCategory>()
                .HasOne(p => p.VisasPage)
                .WithOne(i => i.VisasCategory)
                .HasForeignKey<VisasPage>(f => f.Url);

            modelBuilder.Entity<Visas>()
                .HasOne(p => p.VisasPage)
                .WithMany(m => m.Visas)
                .HasForeignKey(f => f.VisasPageId)
                .HasPrincipalKey(p => p.Id);

            modelBuilder.Entity<CourseInstitute>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<CourseInstitute>()
                .HasOne(pt => pt.Course)
                .WithMany(p => p.CourseInstitute)
                .HasForeignKey(pt => pt.CourseId);

            modelBuilder.Entity<CourseInstitute>()
                .HasOne(pt => pt.Institute)
                .WithMany(p => p.CourseInstitute)
                .HasForeignKey(pt => pt.InstitutionId);

            modelBuilder.Entity<Location>()
                .HasOne(p => p.Institute)
                .WithMany(b => b.Locations)
                .HasForeignKey(p => p.InstituteId);   

            modelBuilder.Entity<CourseLocation>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<CourseLocation>()
                .HasOne(pt => pt.CourseInstitute)
                .WithMany(p => p.CourseLocations)
                .HasForeignKey(pt => pt.CourseInstituteId);

            modelBuilder.Entity<CourseLocation>()
                .HasOne(pt => pt.Location)
                .WithMany(p => p.CourseLocations)
                .HasForeignKey(pt => pt.LocationId);
        }   
    }
}