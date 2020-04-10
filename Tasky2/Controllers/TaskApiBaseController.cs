using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasky2.ServiceFilter;

namespace Tasky2.Controllers
{
    [Route("api")]
    [ApiController, Authorize]
    [ServiceFilter((typeof(ClaimServiceFilter)))]
    public class TaskApiBaseController : ControllerBase
    {
        public int UserId { get; set; }
    }
}