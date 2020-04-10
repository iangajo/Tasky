using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tasky2.Models;
using Tasky2.Repository;

namespace Tasky2.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IActionResult> MyTask()
        {
            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(s => s.Value).FirstOrDefault();

            var tasks = await _taskRepository.GetAllTaskByUserId(Convert.ToInt32(userId));

            return View("MyTask", tasks);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(TaskViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    StatusName = "Something went wrong."
                });
            }

            var userId = User.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(s => s.Value).FirstOrDefault();

            var rowResult = await _taskRepository.Create(viewModel, Convert.ToInt32(userId));

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


        [HttpPost]
        public async Task<IActionResult> CompleteTask(int taskId)
        {
            var rowResult = await _taskRepository.CompleteTask(taskId);

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


        [HttpPost]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var rowResult = await _taskRepository.DeleteTask(taskId);

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