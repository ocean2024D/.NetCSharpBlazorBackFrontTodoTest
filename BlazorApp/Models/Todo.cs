namespace BlazorApp.Models
{
    public class Todo
    {
        public string Id { get; set; } = string.Empty;
        public string Task { get; set; } = string.Empty;  // Varsayılan boş string
        public bool IsCompleted { get; set; }
    }
}
