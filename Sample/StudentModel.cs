namespace ToDoModels
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string? Title { get; set; } // Nullable Title
        public bool IsCompleted { get; set; }
    }
}
