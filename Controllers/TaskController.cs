using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    protected readonly ITaskService taskService;

    public TaskController(ITaskService task)
    {
        taskService = task;
    }
    

    [HttpGet(Name = "GetTasks")]
    [Route("Get/tasks")]
    [Route("tasks")]
    public IActionResult Get()
    {
        return Ok(taskService.GetTasks());
    }


    [HttpPost]
    [Route("Post/tasks")]
    [Route("tasks")]
    public IActionResult Post([FromBody] ToDoTask task)
    {
        taskService.AddTask(task);
        return Ok(task);
    }


    [HttpPut("{id}")]
    [Route("Put/tasks/{id}")]
    [Route("tasks/{id}")]
    public IActionResult Put(Guid id, [FromBody] ToDoTask task)
    {
        taskService.UpdateTask(id, task);
        return Ok(task);
    }


    [HttpDelete("{id}")]
    [Route("Delete/tasks/{id}")]
    public IActionResult Delete(Guid id)
    {
        taskService.DeleteTask(id);
        return Ok();
    }
}