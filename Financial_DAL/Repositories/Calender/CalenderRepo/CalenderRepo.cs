namespace Financial_DAL;

public class CalenderRepo : GenericRepo<Calender>, ICalenderRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public CalenderRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public Calender FindCalenderByYearMonth(int year, int month)
    {
        var dbCalender = _context.Set<Calender>()
            .Where(x => x.Year == year && x.Month == month).FirstOrDefault();

        return dbCalender;
    }
    #endregion
}
