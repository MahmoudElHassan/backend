using Financial_BL.DTOs.TransactionsDTO;

namespace Financial_BL;

public interface IToDoListManager
{
    List<ReadToDoListsDTO> GetAll();
    ReadToDoListsDTO? GetById(Guid id);
    ReadToDoListsDTO Add(AddToDoListsDTO todolist);
    bool Update(UpdateToDoListsDTO todolist);
    void Delete(Guid id);
}
