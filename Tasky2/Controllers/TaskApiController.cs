using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tasky2.Models;
using Tasky2.Repository;

namespace Tasky2.Controllers
{
    public class TaskApiController : TaskApiBaseController
    {
        private readonly ITaskRepository _taskRepository;
        public TaskApiController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost ("task/create")]
        public async Task<IActionResult> CreateTask([FromBody] TaskViewModel viewModel)
        {
            var rowResult = await _taskRepository.Create(viewModel, UserId);

            if (rowResult > 0)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    StatusName = "Success"
                });
            }

            return BadRequest(new
            {
                StatusCode = 400,
                StatusName = "Something went wrong."
            });
        }

    }
}