using Financial_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubCategoryController : Controller
{
    private readonly ISubCategoryManager _subCategoryManager;
    public SubCategoryController(ISubCategoryManager subCategoryManager)
    {
        _subCategoryManager = subCategoryManager;
    }


    // GET: api/<SubCategoryController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadSubCategoryDTO>> GetSubCategory()
    {
        return _subCategoryManager.GetAll();
    }

    // GET: api/<SubCategoryController>/5
    [HttpGet("{id:int}")]
    public ActionResult<ReadSubCategoryDTO> GetSubCategoryById(int id)
    {
        var subCaategory = _subCategoryManager.GetByintId(id);

        if (subCaategory == null)
        {
            return NotFound();
        }

        return subCaategory;
    }

    // POST: api/<SubCategoryController>
    [HttpPost]
    public ActionResult<ReadSubCategoryDTO> AddSubCategory(AddSubCategoryDTO addSubCategoryDTOS)
    {
        var readSubCategoryDTOS = _subCategoryManager.Add(addSubCategoryDTOS);

        return CreatedAtAction("GetSubCategoryById", new { id = readSubCategoryDTOS.SCategoryId }, readSubCategoryDTOS);
    }

    // PUT: api/<SubCategoryController>
    [HttpPut]
    public IActionResult EditSubCategory(UpdateSubCategoryDTO subCategory)
    {
        var subCategoryDTO = _subCategoryManager.Update(subCategory);

        if (subCategoryDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/<SubCategoryController>/5

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSubCategory(int id)
    {
        _subCategoryManager.Delete(id);

        return NoContent();
    }
}
