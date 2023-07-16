using Financial_BL;
using Financial_BL.DTOs.SalesDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly ISalesManager _salesManager;

    public SalesController(ISalesManager salesManager)
    {
        _salesManager = salesManager;
    }



    // GET: api/<SalesController>
    [HttpGet]
    public ActionResult<IEnumerable<ReadSaleDTO>> GetSales()
    {
        return this._salesManager.GetAll();
    }
}
