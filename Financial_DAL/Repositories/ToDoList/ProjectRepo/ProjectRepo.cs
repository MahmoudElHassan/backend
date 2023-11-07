namespace Financial_DAL;

public class ProjectRepo : GenericRepo<Project>, IProjectRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public ProjectRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method

    #endregion
}
