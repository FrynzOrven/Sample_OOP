using Microsoft.AspNetCore.Mvc;
using SampleManager.Services; // Adjust this based on your actual namespace
using System.Collections.Generic; // Required for IEnumerable
using ToDoModels; // Ensure this matches your project structure

namespace ToDoListManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetTasks() // Changed to TaskItem
    {
        var tasks = _taskService.GetAllTasks();
        if (tasks == null || !tasks.Any())
        {
            return NoContent(); // Return 204 No Content if the list is empty
        }
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTask(int id) // Changed to TaskItem
    {
        var task = _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound(new { Message = $"Task with ID {id} not found." });
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> AddTask([FromBody] TaskItem task) // Changed to TaskItem
    {
        if (task == null || string.IsNullOrEmpty(task.Title))
        {
            return BadRequest(new { Message = "Task data is invalid." });
        }

        _taskService.AddTask(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] TaskItem task) // Changed to TaskItem
    {
        if (task == null || string.IsNullOrEmpty(task.Title))
        {
            return BadRequest(new { Message = "Task data is invalid." });
        }

        var existingTask = _taskService.GetTaskById(id);
        if (existingTask == null)
        {
            return NotFound(new { Message = $"Task with ID {id} not found." });
        }

        _taskService.UpdateTask(id, existingTask);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound(new { Message = $"Task with ID {id} not found." });
        }

        _taskService.DeleteTask(id);
        return NoContent();
    }
}

// Changed class name to TaskItem
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
