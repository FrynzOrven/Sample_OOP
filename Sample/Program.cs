using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SampleApp
{
    // Models
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ToDoTask  // Renamed from Task to avoid conflict with System.Threading.Tasks.Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    // Interfaces
    public interface IStudentService
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetAllStudents();
    }

    public interface ITaskService
    {
        void AddTask(ToDoTask task);  // Updated the type to ToDoTask
        IEnumerable<ToDoTask> GetAllTasks();  // Updated the return type to ToDoTask
    }

    // Services (Implementing the interfaces)
    public class StudentManager : IStudentService
    {
        private readonly List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }
    }

    public class TaskManager : ITaskService
    {
        private readonly List<ToDoTask> _tasks = new List<ToDoTask>();  // Updated to use ToDoTask

        public void AddTask(ToDoTask task)  // Updated to use ToDoTask
        {
            _tasks.Add(task);
        }

        public IEnumerable<ToDoTask> GetAllTasks()  // Updated to return ToDoTask
        {
            return _tasks;
        }
    }

    // Controllers
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_studentService.GetAllStudents());
        }

        [HttpPost]
        public ActionResult AddStudent([FromBody] Student student)
        {
            _studentService.AddStudent(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }
    }

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
        public ActionResult<IEnumerable<ToDoTask>> Get()  // Updated to return ToDoTask
        {
            return Ok(_taskService.GetAllTasks());
        }

        [HttpPost]
        public ActionResult AddTask([FromBody] ToDoTask task)  // Updated to accept ToDoTask
        {
            _taskService.AddTask(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }
    }

    // Main Program
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register services for dependency injection
            builder.Services.AddTransient<IStudentService, StudentManager>();  // Register StudentManager as implementation for IStudentService
            builder.Services.AddTransient<ITaskService, TaskManager>();  // Register TaskManager as implementation for ITaskService

            // Add Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();  // Swagger UI for exploring the API
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map controllers to routes
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
