namespace Financial_DAL;

public class StatusRepo : GenericRepo<Statu>, IStatusRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public StatusRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
