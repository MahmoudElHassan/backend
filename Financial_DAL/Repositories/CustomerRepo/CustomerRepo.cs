namespace Financial_DAL;

public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public CustomerRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method

    #endregion
}
