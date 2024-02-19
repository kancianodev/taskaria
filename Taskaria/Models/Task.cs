using System;

namespace Taskaria.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
        public string Project { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }

        public Task()
        {
            CreatedAt = DateTime.Now;
            IsCompleted = false;
            Priority = "Normal"; 
        }

        public void MarkAsCompleted()
        {
            IsCompleted = true;
            CompletedAt = DateTime.Now;
        }

        public void MarkAsIncomplete()
        {
            IsCompleted = false;
            CompletedAt = null;
        }
    }
}
