namespace Financial_DAL;

public class UserDatabaseRepo : GenericRepo<UserDatabase> , IUserDatabaseRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public UserDatabaseRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

}
