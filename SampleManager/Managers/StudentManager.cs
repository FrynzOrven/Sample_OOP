using SampleManager.Services;
using System.Collections.Generic;
using System.Linq;
using ToDoModels; // Ensure this matches your project structure

namespace SampleManager.Managers
{
    public class TaskManager : ITaskService
    {
        private readonly List<ToDoTask> _todoTaskList = new List<ToDoTask>
        {
            new ToDoTask { Id = 1, Title = "Complete project", IsCompleted = false },
            new ToDoTask { Id = 2, Title = "Prepare presentation", IsCompleted = false }
        };

        public IEnumerable<ToDoTask> GetAllTasks()
        {
            return _todoTaskList;
        }

        public ToDoTask? GetTaskById(int id)
        {
            return _todoTaskList.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(ToDoTask newTask)
        {
            newTask.Id = _todoTaskList.Any() ? _todoTaskList.Max(t => t.Id) + 1 : 1;
            _todoTaskList.Add(newTask);
        }

        public void UpdateTask(int id, ToDoTask updatedTask)
        {
            var existingTask = _todoTaskList.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.IsCompleted = updatedTask.IsCompleted;
            }
        }

        public void DeleteTask(int id)
        {
            var existingTask = _todoTaskList.FirstOrDefault(t => t.Id == id);
            if (existingTask != null)
            {
                _todoTaskList.Remove(existingTask);
            }
        }
    }
}
