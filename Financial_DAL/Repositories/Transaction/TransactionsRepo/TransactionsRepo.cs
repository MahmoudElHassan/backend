namespace Financial_DAL;

public class TransactionsRepo : GenericRepo<Transaction>, ITransactionsRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public TransactionsRepo(ApplicationDbContext context) :base(context)
    {
        _context= context;
    }
    #endregion

    #region Method
    #endregion

}