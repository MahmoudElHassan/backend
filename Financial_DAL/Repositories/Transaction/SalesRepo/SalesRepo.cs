namespace Financial_DAL;

public class SalesRepo : GenericRepo<Sale>, ISalesRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public SalesRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
