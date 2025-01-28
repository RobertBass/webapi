using webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace webapi;

public class TaskContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<ToDoTask> Tasks { get; set; }

    public TaskContext(DbContextOptions<TaskContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Actividades pendientes", Level = 20});
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Actividades personales", Level = 50});

        modelBuilder.Entity<Category>(category => 
        {
            category.ToTable("Categories");
            category.HasKey(c => c.CategoryId);

            category.Property(c => c.Name).IsRequired().HasMaxLength(150);
            category.Property(c => c.Description);
            category.Property(c => c.Level);
            category.HasData(categoriesInit);
        });

        string now = DateTime.Now.ToString("yyyy-MM-dd");

        List<ToDoTask> tasksInit = new List<ToDoTask>();
        tasksInit.Add(new ToDoTask() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Title = "Hacer el diseño de la aplicación", Description = "Diseñar la aplicación", TaskPriority = Priority.High, CreatedDate = DateTime.Parse(now)});
        tasksInit.Add(new ToDoTask() { TaskId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Title = "Hacer ejercicios", Description = "Hacer ejercicios en el gimnasio", TaskPriority = Priority.Medium, CreatedDate = DateTime.Parse(now)});

        modelBuilder.Entity<ToDoTask>(task =>
        {
            task.ToTable("Tasks");
            task.HasKey(t => t.TaskId);
            task.HasOne(t => t.Category).WithMany(c => c.Tasks).HasForeignKey(c => c.CategoryId);

            task.Property(t => t.Title).IsRequired().HasMaxLength(200);
            task.Property(t => t.Description).IsRequired(false);
            task.Property(t => t.TaskPriority);
            task.Property(t => t.CreatedDate);
            task.Ignore(t => t.Resumen);
            task.HasData(tasksInit);
        });
    }

}