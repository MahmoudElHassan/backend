using Financial_BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial;

[Route("api/[controller]")]
[ApiController]
public class AssignController : ControllerBase
{

    private readonly IAssignManager _assignManager;

    public AssignController(IAssignManager assignManager)
    {
        _assignManager = assignManager;
    }


    // GET: api/<AssignController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadAssignsDTO>> GetAssignes()
    {
        return this._assignManager.GetAll();
    }

}
