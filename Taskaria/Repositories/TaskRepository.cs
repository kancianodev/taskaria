using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taskaria.Data;

namespace Taskaria.Repositories
{
    public class TaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Taskaria.Models.Task> GetAllTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        public Taskaria.Models.Task GetTaskById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Taskaria.Models.Task task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

        public void UpdateTask(Taskaria.Models.Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            if (taskToDelete != null)
            {
                _dbContext.Tasks.Remove(taskToDelete);
                _dbContext.SaveChanges();
            }
        }
    }
}
