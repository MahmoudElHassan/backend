namespace Financial_BL;

public interface IProjectManager
{
    List<ReadProjectDTO> GetAll();
    ReadProjectDTO GetById(int id);
    ReadProjectDTO Add(AddProjectDTO todolist);
    bool Update(UpdateProjectDTO todolist);
    void Delete(int id);
}
