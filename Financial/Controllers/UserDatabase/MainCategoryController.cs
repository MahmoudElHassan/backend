using Financial_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MainCategoryController : Controller
{

    private readonly IMainCategoryManager _mainCategoryManager;
    public MainCategoryController(IMainCategoryManager mainCategoryManager)
    {
        _mainCategoryManager = mainCategoryManager;
    }

    // GET: api/<MainCategoryController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadMainCategoryDTO>> GetMainCategory()
    {
        return _mainCategoryManager.GetAll();
    }

    // GET: api/<MainCategoryController>/5
    [HttpGet("{id:int}")]
    public ActionResult<ReadMainCategoryDTO> GetMainCategoryById(int id)
    {
        var mainCaategory = _mainCategoryManager.GetByintId(id);

        if (mainCaategory == null)
        {
            return NotFound();
        }

        return mainCaategory;
    }

    // POST: api/<MainCategoryController>
    [HttpPost]
    public ActionResult<ReadMainCategoryDTO> AddMainCategory(AddMainCategoryDTO addMainCategoryDTOS)
    {
        var readMainCategoryDTOS = _mainCategoryManager.Add(addMainCategoryDTOS);

        return CreatedAtAction("GetMainCategoryById", new { id = readMainCategoryDTOS.MCategoryId }, readMainCategoryDTOS);
    }

    // PUT: api/<MainCategoryController>
    [HttpPut]
    public IActionResult EditMainCategory(UpdateMainCategoryDTO mainCategory)
    {
        var mainCategoryDTO = _mainCategoryManager.Update(mainCategory);

        if (mainCategoryDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/<MainCategoryController>/5

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteMainCategory(int id)
    {
        _mainCategoryManager.Delete(id);

        return NoContent();
    }
}
