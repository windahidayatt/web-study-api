using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using web_study_api.EntityFrameworks.Entities;

namespace web_study_api.EntityFrameworks.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MoleculeEntity>();
            modelBuilder.Entity<StudyStatusEntity>();
            modelBuilder.Entity<StudyEntity>();
        }
    }
}
