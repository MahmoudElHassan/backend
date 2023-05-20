using Microsoft.AspNetCore.Mvc;
using Financial_BL;
using Financial_BL.DTOs;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesManager _categoriesManager;


    public CategoriesController(ICategoriesManager categoriesManager)
    {
        _categoriesManager = categoriesManager;
    }

    // GET: api/Transactions
    [HttpGet]
    public ActionResult<IEnumerable<ReadCateoriesDTOS>> GetCategories()
    {
        return _categoriesManager.GetAll();
    }

    // GET: api/Transactions/5
    [HttpGet("{id}")]
    public ActionResult<ReadCateoriesDTOS> GetCategoryById(Guid id)
    {
        var cateory = _categoriesManager.GetById(id);

        if (cateory == null)
        {
            return NotFound();
        }

        return cateory;
    }

    // POST: api/Transactions
    [HttpPost]
    public ActionResult<ReadCateoriesDTOS> AddCategory(AddCateoriesDTOS addCateoriesDTOS)
    {
        var readCateoriesDTOS = _categoriesManager.Add(addCateoriesDTOS);

        return CreatedAtAction("GetCategoryById", new { id = readCateoriesDTOS.CategoryId }, readCateoriesDTOS);
    }

    // PUT: api/Transactions/5
    [HttpPut]
    public IActionResult EditCatoegory( UpdateCateoriesDTOS cateory)
    {
        //if (id != cateory.CategoryId)
        //{
        //    return BadRequest();
        //}

        var categoryDTO = _categoriesManager.Update(cateory);

        if (categoryDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/Transactions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        _categoriesManager.Delete(id);

        return NoContent();
    }
}
