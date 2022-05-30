using HR_Platform_Internship.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HR_Platform_Internship.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<JobCandidate> JobCandidates { get; set; }
        public DbSet<JobCandidateSkill> JobCandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobCandidateSkill>()
                .HasKey(jck => new { jck.JobCandidateId, jck.SkillId });

            modelBuilder.Entity<JobCandidateSkill>()
                .HasOne(bc => bc.Skill)
                .WithMany(b => b.JobCandidates)
                .HasForeignKey(bc => bc.SkillId);

            modelBuilder.Entity<JobCandidateSkill>()
                .HasOne(bc => bc.JobCandidate)
                .WithMany(c => c.Skills)
                .HasForeignKey(bc => bc.JobCandidateId);
        }
    }
}
