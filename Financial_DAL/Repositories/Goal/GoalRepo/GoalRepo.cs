namespace Financial_DAL;

public class GoalRepo : GenericRepo<Goal>, IGoalRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public GoalRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public List<Goal> GetGoalsByArea(int areaId)
    {
        var dbGoals = _context.Set<Goal>()
            .Where(x => x.Area_Id == areaId).ToList();

        return dbGoals;
    }
    #endregion
}
