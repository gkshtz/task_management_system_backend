using TaskManagement.Utils.Enums;

namespace TaskManagement.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public Status Status { get; set; }
        public TaskModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            StartDate = DateTime.MinValue;
            DueDate = DateTime.MinValue;
        }
    }
}
