using webapi.Models;

namespace webapi.Services;

public class TaskService: ITaskService
{
    TaskContext context;

    public TaskService(TaskContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<ToDoTask> GetTasks()
    {
        if (context == null)
        {
            throw new InvalidOperationException("CONTEXT_NOT_INITIALIZED");
        }
        return context.Tasks;
    }

    public async Task AddTask(ToDoTask task)
    {
        context.Tasks.Add(task);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTask(Guid taskId, ToDoTask task)
    {
        var taskToUpdate = context.Tasks.Find(taskId);
        if (taskToUpdate == null)
        {
            throw new InvalidOperationException("TASK_NOT_FOUND");
        }
        taskToUpdate.Title = task.Title;
        taskToUpdate.Description = task.Description;
        taskToUpdate.TaskPriority = task.TaskPriority;
        taskToUpdate.CreatedDate = task.CreatedDate;
        taskToUpdate.CategoryId = task.CategoryId;

        await context.SaveChangesAsync();
    }

    public async Task DeleteTask(Guid taskId)
    {
        var taskToDelete = context.Tasks.Find(taskId);
        if (taskToDelete == null)
        {
            throw new InvalidOperationException("TASK_NOT_FOUND");
        }
        context.Tasks.Remove(taskToDelete);
        await context.SaveChangesAsync();
    }
}

public interface ITaskService
{
    IEnumerable<ToDoTask> GetTasks();
    Task AddTask(ToDoTask task);
    Task UpdateTask(Guid taskId, ToDoTask task);
    Task DeleteTask(Guid taskId);
}