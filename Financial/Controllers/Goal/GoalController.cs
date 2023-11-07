using Financial_BL;
using Microsoft.AspNetCore.Mvc;

namespace Financial;

[Route("api/")]
[ApiController]

public class GoalController : Controller
{
    #region Field
    private readonly IGoalManager _goalManager;
    #endregion

    #region Ctor
    public GoalController(IGoalManager goalManager)
    {
        _goalManager = goalManager;
    }
    #endregion

    #region Methods

    // GET: api/GetAllGoals
    [HttpGet("GetAllGoals")]
    public ActionResult<IEnumerable<ReadGoalDTO>> GetAllGoals()
    {
        return _goalManager.GetAll();
    }

    // GET: api/GetGoalById/5
    [HttpGet("GetGoalById/{id}")]
    public ActionResult<ReadGoalDTO> GetGoalById(int id)
    {
        var goal = _goalManager.GetById(id);

        if (goal == null)
        {
            return NotFound();
        }

        return goal;
    }

    // GET: api/GetGoalsByArea/5
    [HttpGet("GetGoalsByArea")]
    public ActionResult<IEnumerable<ReadGoalDTO>> GetGoalsByArea(int areaId)
    {
        var goal = _goalManager.GetGoalsByArea(areaId);

        if (goal == null)
        {
            return NotFound();
        }

        return goal;
    }

    // POST: api/AddGoal
    [HttpPost("AddGoal")]
    public ActionResult<ReadGoalDTO> AddGoal(AddGoalDTO addGoalDTO)
    {
        var readGoalDto = _goalManager.Add(addGoalDTO);

        return CreatedAtAction("GetGoalById", new { id = readGoalDto.GoalId }, readGoalDto);
    }

    // PUT: api/EditGoal
    [HttpPut("EditGoal")]
    public IActionResult EditGoals(UpdateGoalDTO updateGoal)
    {
        var goalDTO = _goalManager.Update(updateGoal);

        if (goalDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteGoal/5
    [HttpDelete("DeleteGoal/{id}")]
    public async Task<IActionResult> DeleteGoal(int id)
    {
        _goalManager.Delete(id);

        return NoContent();
    }

    #endregion
}
