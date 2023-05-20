using Financial_BL;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{

    private readonly IStatusManager _statusManager;

    public StatusController(IStatusManager statusManager)
    {
        _statusManager = statusManager;
    }

    // GET: api/<StatusController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadStatusDTOs>> GetSales()
    {
        return this._statusManager.GetAll();
    }
}
