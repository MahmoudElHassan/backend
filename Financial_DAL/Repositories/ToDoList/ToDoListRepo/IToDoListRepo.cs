namespace Financial_DAL;

public interface IToDoListRepo : IGenericRepo<ToDoList>
{
    List<ToDoList> GetToDoByProject(int projectId);
}
