using Financial_BL;
using Microsoft.AspNetCore.Mvc;

namespace Financial;

[Route("api/")]
[ApiController]

public class AreaController : Controller
{
    #region Field
    private readonly IAreaManager _areaManager;
    #endregion

    #region Ctor
    public AreaController(IAreaManager areaManager)
    {
        _areaManager = areaManager;
    }
    #endregion

    #region Methods

    // GET: api/GetAllArea
    [HttpGet("GetAllArea")]
    public ActionResult<IEnumerable<ReadAreaDTO>> GetAllArea()
    {
        return _areaManager.GetAll();
    }

    // GET: api/GetAreaById/5

    [HttpGet("GetAreaById/{id}")]
    public ActionResult<ReadAreaDTO> GetAreaById(int id)
    {
        var area = _areaManager.GetById(id);

        if (area == null)
        {
            return NotFound();
        }

        return area;
    }

    // POST: api/AddArea
    [HttpPost("AddArea")]
    public ActionResult<ReadAreaDTO> AddArea(AddAreaDTO addAreaDTO)
    {
        var readAreaDto = _areaManager.Add(addAreaDTO);

        return CreatedAtAction("GetAreaById", new { id = readAreaDto.AreaId }, readAreaDto);
    }

    // PUT: api/EditArea
    [HttpPut("EditArea")]
    public IActionResult EditArea(UpdateAreaDTO updateAreaDTO)
    {
        var areaDTO = _areaManager.Update(updateAreaDTO);

        if (areaDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteArea/5
    [HttpDelete("DeleteArea/{id}")]
    public async Task<IActionResult> DeleteArea(int id)
    {
        _areaManager.Delete(id);

        return NoContent();
    }

    #endregion
}
