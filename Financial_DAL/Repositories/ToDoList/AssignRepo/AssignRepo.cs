namespace Financial_DAL;

public class AssignRepo : GenericRepo<Assign>, IAssignRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public AssignRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
