using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskToGo.Models;

namespace TaskToGo.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<TodoTask> todoTasks { get; set; }
        public DbSet<TaskCategory> TaskCategories { get; set; }

    }
}
