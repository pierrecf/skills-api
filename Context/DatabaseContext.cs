using Bogus;
using Microsoft.EntityFrameworkCore;
using skills_api.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.UserSkills)
            .WithOne(us => us.User)
            .HasForeignKey(us => us.UserId);

        modelBuilder.Entity<Goal>()
            .HasOne(g => g.User)
            .WithMany(u => u.Goals)
            .HasForeignKey(g => g.UserId);

        modelBuilder.Entity<UserSkill>()
            .HasKey(us => new { us.UserId, us.SkillId });

        modelBuilder.Entity<UserSkill>()
            .HasOne(us => us.User)
            .WithMany(u => u.UserSkills)
            .HasForeignKey(us => us.UserId);

        modelBuilder.Entity<Skill>()
            .HasOne(s => s.Category)
            .WithMany(c => c.Skills)
            .HasForeignKey(s => s.CategoryId);


        //USERS
    }
}