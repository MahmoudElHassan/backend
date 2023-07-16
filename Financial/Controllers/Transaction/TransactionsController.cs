using Microsoft.AspNetCore.Mvc;
using Financial_BL.DTOs.TransactionsDTO;
using Financial_BL;

namespace Financial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionsManager _transactionsManager;

    public TransactionsController(ITransactionsManager transactionsManager)
    {
        _transactionsManager = transactionsManager;
    }



    // GET: api/Transactions
    [HttpGet]
    public ActionResult<IEnumerable<ReadTransactionDTO>> GetTransactions()
    {
        return _transactionsManager.GetAll();
    }

    // GET: api/Transactions/5
    [HttpGet("{id}")]
    public ActionResult<ReadTransactionDTO> GetTransactionById(Guid id)
    {
        var transaction = _transactionsManager.GetById(id);

        if (transaction == null)
        {
            return NotFound();
        }

        return transaction;
    }

    // POST: api/Transactions
    [HttpPost]
    public ActionResult<ReadTransactionDTO> AddTransaction(AddTrasnactionDTO addTransactionDto)
    {
        var readTransactionDto = _transactionsManager.Add(addTransactionDto);

        return CreatedAtAction("GetTransactionById", new { id = readTransactionDto.TransactionId }, readTransactionDto);
    }

    // PUT: api/Transactions
    [HttpPut]
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

    // DELETE: api/Transactions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        _transactionsManager.Delete(id);

        return NoContent();
    }

}
