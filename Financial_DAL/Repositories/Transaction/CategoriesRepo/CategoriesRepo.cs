
namespace Financial_DAL;

public class CategoriesRepo : GenericRepo<Category>, ICategoriesRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public CategoriesRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method

    #endregion
}
