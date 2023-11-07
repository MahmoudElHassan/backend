using NPoco;

namespace Financial_DAL;

public class TransactionsRepo : GenericRepo<Transaction>, ITransactionsRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public TransactionsRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public List<Transaction> GetExpenses()
    {
        return _context.Set<Transaction>().Where(x => x.Categories.Sale_Id == 1).ToList();
    }

    public List<Transaction> GetRevnue()
    {
        return _context.Set<Transaction>().Where(x => x.Categories.Sale_Id != 1).ToList();
    }

    //public List<Transaction> GetExpensesInOrder()
    //{
    //    var dbTransactions = _context.Set<Transaction>()
    //        .Where(x => x.Categories.Sale_Id == 1)
    //        .OrderBy(a => a.Amount).ToList();

    //    return dbTransactions;
    //}

    //public List<Transaction> GetExpensesInOrderDescending()
    //{
    //    var dbTransactions = _context.Set<Transaction>()
    //        .Where(x => x.Categories.Sale_Id == 1)
    //        .OrderByDescending(a => a.Amount).ToList();

    //    return dbTransactions;
    //}

    //public List<Transaction> GetRevenuInOrder()
    //{
    //    var dbTransactions = _context.Set<Transaction>()
    //        .Where(x => x.Categories.Sale_Id != 1)
    //        .OrderBy(a => a.Amount).ToList();

    //    return dbTransactions;
    //}

    //public List<Transaction> GetRevenuInOrderDescending()
    //{
    //    var dbTransactions = _context.Set<Transaction>()
    //        .Where(x => x.Categories.Sale_Id != 1)
    //        .OrderByDescending(a => a.Amount).ToList();

    //    return dbTransactions;
    //}
    #endregion

}