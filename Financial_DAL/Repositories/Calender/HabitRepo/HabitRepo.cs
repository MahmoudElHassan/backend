namespace Financial_DAL;

public class HabitRepo : GenericRepo<Habit>, IHabitRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public HabitRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method

    #endregion
}
