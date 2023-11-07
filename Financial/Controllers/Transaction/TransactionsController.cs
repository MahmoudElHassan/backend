using Microsoft.AspNetCore.Mvc;
using Financial_BL;

namespace Financial.Controllers;

[Route("api/")]
[ApiController]
public class TransactionsController : ControllerBase
{
    #region Field
    private readonly ITransactionsManager _transactionsManager;
    #endregion

    #region Ctor
    public TransactionsController(ITransactionsManager transactionsManager)
    {
        _transactionsManager = transactionsManager;
    }
    #endregion

    #region Methods

    // GET: api/GetAllTransactions
    [HttpGet("GetAllTransactions")]
    public ActionResult<IEnumerable<ReadTransactionDTO>> GetTransactions()
    {
        return _transactionsManager.GetAll();
    }

    // GET: api/GetExpensesTransactions
    [HttpGet("GetExpensesTransactions")]
    public ActionResult<IEnumerable<ReadTransactionDTO>> GetExpensesTransactions()
    {
        return _transactionsManager.GetAllExpenses();
    }

    // GET: api/GetRevnueTransactions
    [HttpGet("GetRevnueTransactions")]
    public ActionResult<IEnumerable<ReadTransactionDTO>> GetRevnueTransactions()
    {
        return _transactionsManager.GetAllRevnue();
    }

    // GET: api/GetExpensesInOrder
    //[HttpGet("GetExpensesInOrder")]
    //public ActionResult<IEnumerable<ReadTransactionDTO>> GetExpensesInOrder()
    //{
    //    return _transactionsManager.GetExpensesInOrder();
    //}

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


    // GET: api/GetChart
    [HttpGet("GetChart")]
    public ActionResult<TransactionChart> GetChart(int year)
    {
        return _transactionsManager.GetChart(year);
    }

    #endregion
}
