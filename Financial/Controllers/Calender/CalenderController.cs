using Financial_BL;
using Microsoft.AspNetCore.Mvc;

namespace Financial;

[Route("api/")]
[ApiController]

public class CalenderController : Controller
{
    #region Field
    private readonly ICalenderManager _calenderManager;
    #endregion

    #region Ctor
    public CalenderController(ICalenderManager calenderManager)
    {
        _calenderManager = calenderManager;
    }
    #endregion

    #region Methods

    // GET: api/GetAllCalenders
    [HttpGet("GetAllCalenders")]
    public ActionResult<IEnumerable<ReadCalenderDTO>> GetAllCalenders()
    {
        return _calenderManager.GetAll();
    }

    // GET: api/GetCalenderById/5
    [HttpGet("GetCalenderById/{id}")]
    public ActionResult<ReadCalenderDTO> GetCalenderById(int id)
    {
        var calender = _calenderManager.GetById(id);

        if (calender == null)
        {
            return NotFound();
        }

        return calender;
    }

    // POST: api/AddCalender
    [HttpPost("AddCalender")]
    public ActionResult<ReadCalenderDTO> AddCalender(AddCalenderDTO addCalenderDTO)
    {
        var readCalenderDto = _calenderManager.Add(addCalenderDTO);

        return CreatedAtAction("GetCalenderById", new { id = readCalenderDto.CalenderId }, readCalenderDto);
    }

    // PUT: api/EditCalender
    [HttpPut("EditCalender")]
    public IActionResult EditCalender(UpdateCalenderDTO updateCalender)
    {
        var calenderDTO = _calenderManager.Update(updateCalender);

        if (calenderDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteCalender/5
    [HttpDelete("DeleteCalender/{id}")]
    public async Task<IActionResult> DeleteCalender(int id)
    {
        _calenderManager.Delete(id);

        return NoContent();
    }

    #endregion
}
