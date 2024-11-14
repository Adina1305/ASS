using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Tasks> Tasks { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentTask> StudentTask { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTask>()
            .Property(s => s.Grade)
            .HasColumnType("decimal(5, 2)");

        modelBuilder.Entity<Tasks>()
            .HasOne(t => t.Teacher)
            .WithMany()
            .HasForeignKey(t => t.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);  

        modelBuilder.Entity<StudentTask>()
            .HasOne(st => st.Student)
            .WithMany()
            .HasForeignKey(st => st.StudentId)
            .OnDelete(DeleteBehavior.NoAction);  

        modelBuilder.Entity<StudentTask>()
            .HasOne(st => st.Tasks)
            .WithMany(t => t.StudentTask)
            .HasForeignKey(st => st.TasksId)
            .OnDelete(DeleteBehavior.Cascade);  
    }

}
