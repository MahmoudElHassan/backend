namespace Financial_DAL;

public class SubCategoryRepo : GenericRepo<SubCategory> , ISubCategoryRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public SubCategoryRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion
}
