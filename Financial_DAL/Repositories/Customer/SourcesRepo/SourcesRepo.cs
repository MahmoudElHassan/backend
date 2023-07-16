namespace Financial_DAL;

public class SourcesRepo : GenericRepo<Source> , ISourcesRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public SourcesRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
