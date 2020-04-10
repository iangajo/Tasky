using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasky2.Data;
using Tasky2.Models;
using Task = Tasky2.Entities.Task;

namespace Tasky2.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskListViewModel>> GetAllTaskByUserId(int userId)
        {
            var data = from t in _dbContext.Task
                       join u in _dbContext.User on t.UserId equals u.UserId into ug
                       from x in ug.DefaultIfEmpty()
                       where x.UserId == userId
                       select new
                       {
                           TaskId = t.Id,
                           Name = $"{x.FirstName} {x.LastName}",
                           t.TaskName,
                           t.TaskDescription,
                           t.IsCompleted,

                       };

            return await data.Select(s => new TaskListViewModel()
            {
                TaskId = s.TaskId,
                Name = s.Name,
                TaskName = s.TaskName,
                TaskDescription = s.TaskDescription,
                IsCompleted = s.IsCompleted

            }).ToListAsync();
        }

        public async Task<int> Create(TaskViewModel viewModel, int userId)
        {
            await _dbContext.Task.AddAsync(new Task()
            {
                UserId = userId,
                TaskName = viewModel.TaskName,
                TaskDescription = viewModel.TaskDescription,
                IsCompleted = false,

            });

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> CompleteTask(int taskId)
        {
            var task = _dbContext.Task.Find(taskId);

            if (task == null) return 0;

            task.IsCompleted = true;

            _dbContext.Task.Update(task);

            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> DeleteTask(int taskId)
        {
            var task = _dbContext.Task.Find(taskId);

            if (task == null) return 0;

            _dbContext.Task.Remove(task);

            return await _dbContext.SaveChangesAsync();
        }
    }
}
