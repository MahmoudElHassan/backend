using Financial_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers;

[Route("api/")]
[ApiController]
public class PaymentController : Controller
{
    private readonly IPaymentManager _paymentManager;


    public PaymentController(IPaymentManager paymentManager)
    {
        _paymentManager = paymentManager;
    }

    // GET: api/GetLinksByTransaction
    [HttpGet("GetLinksByTransaction")]
    public ActionResult<IEnumerable<ReadPaymentDTO>> GetLinksByTransaction(Guid transactionId)
    {
        return _paymentManager.GetLinksByTrans(transactionId);
    }

    // GET: api/GetLinkById/5
    [HttpGet("GetLinkById/{id}")]
    public ActionResult<ReadPaymentDTO> GetLinkById(int id)
    {
        var payment =  _paymentManager.GetById(id);

        if (payment == null)
        {
            return NotFound();
        }

        return payment;
    }

    // POST: api/AddLink
    [HttpPost("AddLink")]
    public ActionResult<ReadPaymentDTO> AddLink(AddPaymentDTO addPaymentDTO)
    {
        var readPaymentDTO = _paymentManager.Add(addPaymentDTO);

        return CreatedAtAction("GetLinkById", new { id = readPaymentDTO.PaymentId }, readPaymentDTO);
    }

    // PUT: api/EditLink
    [HttpPut("EditLink")]
    public IActionResult EditLink(UpdatePaymentDTO paymentDTO)
    {
        var dbModel = _paymentManager.Update(paymentDTO);

        if (dbModel)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteLink/5
    [HttpDelete("DeleteLink/{id}")]
    public async Task<IActionResult> DeleteLink(int id)
    {
        _paymentManager.Delete(id);

        return NoContent();
    }

}
