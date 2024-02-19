using System;
namespace Taskaria.Models
{
    public class TaskHistory
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Action { get; set; } 
        public DateTime Timestamp { get; set; }
    }
}

