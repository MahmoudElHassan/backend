using Financial_BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers
{

    [Route("api/")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {

        private readonly IToDoListManager _todolistManager;
        public ToDoListController(IToDoListManager todolistManager)
        {
            _todolistManager = todolistManager;
        }


        // GET: api/GetAllToDoList
        [HttpGet("GetAllToDoList")]
        public ActionResult<IEnumerable<ReadToDoListsDTO>> GetToDoLists()
        {
            return _todolistManager.GetAll();
        }

        // GET api/GetToDoListById/5
        [HttpGet("GetToDoListById/{id}")]
        public ActionResult<ReadToDoListsDTO> GetToDoListById(Guid id)
        {
            var todolist = _todolistManager.GetById(id);

            if (todolist == null)
            {
                return NotFound();
            }

            return todolist;
        }

        // POST api/AddToDoList
        [HttpPost("AddToDoList")]
        public ActionResult<ReadToDoListsDTO> AddToDoList(AddToDoListsDTO addToDoListDTOS)
        {
            var readToDoListTOS = _todolistManager.Add(addToDoListDTOS);

            return CreatedAtAction("GetToDoListById", new { id = readToDoListTOS.ListId }, readToDoListTOS);
        }

        // PUT api/EditToDoList/5
        [HttpPut("EditToDoList")]
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

        // DELETE api/DeleteToDoList/5
        [HttpDelete("DeleteToDoList/{id}")]
        public async Task<IActionResult> DeleteToDoList(Guid id)
        {
            _todolistManager.Delete(id);

            return NoContent();
        }

    }
}
