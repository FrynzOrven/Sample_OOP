using SampleManager.Managers;
using SampleManager.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoListManager.Managers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        // Register services using a factory method to control the lifetime.
        builder.Services.Add(new ServiceDescriptor(typeof(IStudentService),
            sp => new StudentManager(), ServiceLifetime.Transient)); // or your chosen lifetime

        builder.Services.Add(new ServiceDescriptor(typeof(ITaskService),
            sp => new TaskManager(), ServiceLifetime.Transient)); // or your chosen lifetime

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
