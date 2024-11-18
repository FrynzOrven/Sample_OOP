using System.Collections.Generic; // Required for IEnumerable

namespace ToDoListManager.Services
{
    public interface ITaskService
    {
        IEnumerable<ToDoModels.ToDoTask> GetAllTasks(); 
        ToDoModels.ToDoTask? GetTaskById(int id); 
        void AddTask(ToDoModels.ToDoTask task); 
        void UpdateTask(int id, ToDoModels.ToDoTask task); 
        void DeleteTask(int id);
    }
}
