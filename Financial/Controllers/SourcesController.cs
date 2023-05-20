using Financial_BL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SourcesController : ControllerBase
{

    private readonly ISourcesManager _sourceManager;

    public SourcesController(ISourcesManager sourcesManager)
    {
        _sourceManager = sourcesManager;
    }

    // GET: api/<SourcesController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadSourcesDTOs>> GetSales()
    {
        return this._sourceManager.GetAll();
    }

}
