using System.Collections.Generic; // Required for IEnumerable
using ToDoModels; // Ensure this namespace is included for ToDoTask
using ToDoListManager.Services; // Ensure this namespace is included for ITaskService

namespace ToDoListManager.Managers
{
    public class StudentManager : ITaskService
    {
        private readonly List<ToDoTask> _tasks = new List<ToDoTask>();

        public IEnumerable<ToDoTask> GetAllTasks() => _tasks;

        public ToDoTask? GetTaskById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void AddTask(ToDoTask task)
        {
            task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(task);
        }

        public void UpdateTask(int id, ToDoTask task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }

        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
