namespace Financial_DAL;

public class MainCategoryRepo : GenericRepo<MainCategory>, IMainCatregoryRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public MainCategoryRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
