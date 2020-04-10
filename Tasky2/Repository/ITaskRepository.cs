using System.Collections.Generic;
using System.Threading.Tasks;
using Tasky2.Models;

namespace Tasky2.Repository
{
    public interface ITaskRepository
    {
        Task<List<TaskListViewModel>> GetAllTaskByUserId(int userId);

        Task<int> Create(TaskViewModel viewModel, int userId);

        Task<int> CompleteTask(int taskId);

        Task<int> DeleteTask(int taskId);
    }
}
