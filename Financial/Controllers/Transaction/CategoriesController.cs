using Microsoft.AspNetCore.Mvc;
using Financial_BL.DTOs;
using Financial_BL.ManagerDTOs.Transaction.CategoryManager;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers;

[Route("api/")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesManager _categoriesManager;


    public CategoriesController(ICategoriesManager categoriesManager)
    {
        _categoriesManager = categoriesManager;
    }

    // GET: api/GetAllCategories
    [HttpGet("GetAllCategories")]
    public ActionResult<IEnumerable<ReadCateoriesDTOS>> GetCategories()
    {
        return _categoriesManager.GetAll();
    }

    // GET: api/GetCategoriesById/5
    [HttpGet("GetCategoriesById/{id}")]
    public ActionResult<ReadCateoriesDTOS> GetCategoryById(Guid id)
    {
        var cateory = _categoriesManager.GetById(id);

        if (cateory == null)
        {
            return NotFound();
        }

        return cateory;
    }

    // POST: api/AddCategories
    [HttpPost("AddCategories")]
    public ActionResult<ReadCateoriesDTOS> AddCategory(AddCateoriesDTOS addCateoriesDTOS)
    {
        var readCateoriesDTOS = _categoriesManager.Add(addCateoriesDTOS);

        return CreatedAtAction("GetCategoryById", new { id = readCateoriesDTOS.CategoryId }, readCateoriesDTOS);
    }

    // PUT: api/EditCategories/5
    [HttpPut("EditCategories")]
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

    // DELETE: api/DeleteCategories/5
    [HttpDelete("DeleteCategories/{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        _categoriesManager.Delete(id);

        return NoContent();
    }

}
