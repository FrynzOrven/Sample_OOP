namespace SampleManager.Services // Ensure this matches your project structure
{
    public interface ITaskService
    {
        IEnumerable<ToDoModels.ToDoTask> GetAllTasks();
        ToDoModels.ToDoTask? GetTaskById(int id); // Keep nullable return type
        void AddTask(ToDoModels.ToDoTask newTask);
        void UpdateTask(int id, ToDoModels.ToDoTask updatedTask);
        void DeleteTask(int id);
    }
}
