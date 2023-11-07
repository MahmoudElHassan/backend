using Financial_BL;

namespace Financial_BL;

public interface IToDoListManager
{
    List<ReadToDoListsDTO> GetAll();
    List<ReadToDoListsDTO> GetTODoByProject(int projectId);
    ReadToDoListsDTO GetById(Guid id);
    ReadToDoListsDTO Add(AddToDoListsDTO todolist);
    bool Update(UpdateToDoListsDTO todolist);
    void Delete(Guid id);
}
