namespace Financial_DAL;

public class AreatRepo : GenericRepo<Area>, IAreaRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public AreatRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
