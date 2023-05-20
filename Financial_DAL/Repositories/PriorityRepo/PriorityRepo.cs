
namespace Financial_DAL;

public class PriorityRepo : GenericRepo<Priority>, IPriorityrepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public PriorityRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
