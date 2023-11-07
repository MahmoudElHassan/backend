namespace Financial_DAL;

public class ToDoListRepo : GenericRepo<ToDoList>, IToDoListRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public ToDoListRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Method

    public List<ToDoList> GetToDoByProject(int projectId)
    {
        return _context.Set<ToDoList>().Where(x => x.Project_Id == projectId).ToList();
    }
    #endregion
}
