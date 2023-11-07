using Financial_BL;
using Microsoft.AspNetCore.Mvc;

namespace Financial;

[Route("api/")]
[ApiController]

public class HabitController : Controller
{
    #region Field
    private readonly IHabitManager _habitManager;
    #endregion

    #region Ctor
    public HabitController(IHabitManager habitManager)
    {
        _habitManager = habitManager;
    }
    #endregion

    #region Methods

    // GET: api/GetAllHabits
    [HttpGet("GetAllHabits")]
    public ActionResult<IEnumerable<ReadHabitDTO>> GetAllHabits()
    {
        return _habitManager.GetAll();
    }

    // GET: api/GetHabitById/5
    [HttpGet("GetHabitById/{id}")]
    public ActionResult<ReadHabitDTO> GetHabitById(int id)
    {
        var habit = _habitManager.GetById(id);

        if (habit == null)
        {
            return NotFound();
        }

        return habit;
    }

    // POST: api/AddHabit
    [HttpPost("AddHabit")]
    public ActionResult<ReadHabitDTO> AddHabit(AddHabitDTO addHabitDTO)
    {
        var readHabitDto = _habitManager.Add(addHabitDTO);

        return CreatedAtAction("GetHabitById", new { id = readHabitDto.HabitId }, readHabitDto);
    }

    // PUT: api/EditHabit
    [HttpPut("EditHabit")]
    public IActionResult EditHabit(UpdateHabitDTO updateHabit)
    {
        var habitDTO = _habitManager.Update(updateHabit);

        if (habitDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteHabit/5
    [HttpDelete("DeleteHabit/{id}")]
    public async Task<IActionResult> DeleteHabit(int id)
    {
        _habitManager.Delete(id);

        return NoContent();
    }

    #endregion
}
