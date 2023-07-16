using Financial_BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {

        private readonly IPriorityManager _priorityManager;

        public PriorityController(IPriorityManager priorityManager)
        {
            _priorityManager = priorityManager;
        }


        // GET: api/<PriorityController>
        [HttpGet]
        public ActionResult<IEnumerable<ReadPriorityDTO>> GetPriorities()
        {
            return this._priorityManager.GetAll();
        }


    }
}
