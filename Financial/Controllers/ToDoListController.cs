using Financial_BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {

        private readonly IToDoListManager _todolistManager;
        public ToDoListController(IToDoListManager todolistManager)
        {
            _todolistManager = todolistManager;
        }



        // GET: api/<ToDoListController>
        [HttpGet]
        public ActionResult<IEnumerable<ReadToDoListsDTO>> GetToDoLists()
        {
            return _todolistManager.GetAll();
        }

        // GET api/<ToDoListController>/5
        [HttpGet("{id}")]
        public ActionResult<ReadToDoListsDTO> GetToDoListById(Guid id)
        {
            var todolist = _todolistManager.GetById(id);

            if (todolist == null)
            {
                return NotFound();
            }

            return todolist;
        }

        // POST api/<ToDoListController>
        [HttpPost]
        public ActionResult<ReadToDoListsDTO> AddToDoList(AddToDoListsDTO addToDoListDTOS)
        {
            var readToDoListTOS = _todolistManager.Add(addToDoListDTOS);

            return CreatedAtAction("GetToDoListById", new { id = readToDoListTOS.ListId }, readToDoListTOS);
        }

        // PUT api/<ToDoListController>/5
        [HttpPut]
        public IActionResult EditToDoList(UpdateToDoListsDTO todolist)
        {
            //if (id != cateory.CategoryId)
            //{
            //    return BadRequest();
            //}

            var todolistDTO = _todolistManager.Update(todolist);

            if (todolistDTO)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/<ToDoListController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(Guid id)
        {
            _todolistManager.Delete(id);

            return NoContent();
        }
    }
}
