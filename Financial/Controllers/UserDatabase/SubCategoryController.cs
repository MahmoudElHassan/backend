using Financial_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers;

[Route("api/")]
[ApiController]
public class SubCategoryController : Controller
{
    private readonly ISubCategoryManager _subCategoryManager;
    public SubCategoryController(ISubCategoryManager subCategoryManager)
    {
        _subCategoryManager = subCategoryManager;
    }


    // GET: api/GetAllSubCategory
    [HttpGet("GetAllSubCategory")]
    public ActionResult<IEnumerable<ReadSubCategoryDTO>> GetSubCategory()
    {
        return _subCategoryManager.GetAll();
    }

    // GET: api/GetSubCategoryById/5
    [HttpGet("GetSubCategoryById/{id:int}")]
    public ActionResult<ReadSubCategoryDTO> GetSubCategoryById(int id)
    {
        var subCaategory = _subCategoryManager.GetByintId(id);

        if (subCaategory == null)
        {
            return NotFound();
        }

        return subCaategory;
    }

    // POST: api/AddSubCategory
    [HttpPost("AddSubCategory")]
    public ActionResult<ReadSubCategoryDTO> AddSubCategory(AddSubCategoryDTO addSubCategoryDTOS)
    {
        var readSubCategoryDTOS = _subCategoryManager.Add(addSubCategoryDTOS);

        return CreatedAtAction("GetSubCategoryById", new { id = readSubCategoryDTOS.SCategoryId }, readSubCategoryDTOS);
    }

    // PUT: api/EditSubCategory
    [HttpPut("EditSubCategory")]
    public IActionResult EditSubCategory(UpdateSubCategoryDTO subCategory)
    {
        var subCategoryDTO = _subCategoryManager.Update(subCategory);

        if (subCategoryDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteSubCategory/5

    [HttpDelete("DeleteSubCategory/{id:int}")]
    public async Task<IActionResult> DeleteSubCategory(int id)
    {
        _subCategoryManager.Delete(id);

        return NoContent();
    }

}
