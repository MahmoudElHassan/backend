using Microsoft.AspNetCore.Mvc;
using Financial_BL.DTOs.TransactionsDTO;
using Financial_BL;

namespace Financial.Controllers;

[Route("api/")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionsManager _transactionsManager;

    public TransactionsController(ITransactionsManager transactionsManager)
    {
        _transactionsManager = transactionsManager;
    }



    // GET: api/GetAllTransactions
    [HttpGet("GetAllTransactions")]
    public ActionResult<IEnumerable<ReadTransactionDTO>> GetTransactions()
    {
        return _transactionsManager.GetAll();
    }

    // GET: api/GetTransactionsById/5
    [HttpGet("GetTransactionsById/{id}")]
    public ActionResult<ReadTransactionDTO> GetTransactionById(Guid id)
    {
        var transaction = _transactionsManager.GetById(id);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

    // POST: api/AddTransactions
    [HttpPost("AddTransactions")]
    public ActionResult<ReadTransactionDTO> AddTransaction(AddTrasnactionDTO addTransactionDto)
    {
        var readTransactionDto = _transactionsManager.Add(addTransactionDto);

        return CreatedAtAction("GetTransactionById", new { id = readTransactionDto.TransactionId }, readTransactionDto);
    }

    // PUT: api/EditTransactions
    [HttpPut("EditTransactions")]
    public IActionResult EditTransaction(UpdateTransactionDTO transaction)
    {
        //if (id != transaction.TransactionId)
        //{
        //    return BadRequest();
        //}

        var transactionDTO = _transactionsManager.Update(transaction);

        if (transactionDTO)
        {
            return NoContent();
        }

        return NotFound();
    }

    // DELETE: api/DeleteTransactions/5
    [HttpDelete("DeleteTransactions/{id}")]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        _transactionsManager.Delete(id);

        return NoContent();
    }

}
