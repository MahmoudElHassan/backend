using AutoMapper;
using Financial_BL.DTOs.TransactionsDTO;
using Financial_DAL;
using System.Data.Common;

namespace Financial_BL;

public class ToDoListManager : IToDoListManager
{
    #region Field
    private readonly IToDoListRepo _todolistRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public ToDoListManager(IToDoListRepo todolistRepo, IMapper maapper)
    {
        _todolistRepo = todolistRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadToDoListsDTO> GetAll()
    {
        var dbToDoList = _todolistRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadToDoListsDTO>>(dbToDoList);
    }

    public ReadToDoListsDTO? GetById(Guid id)
    {
        var dbToDoList = _todolistRepo.GetById(id);

        if (dbToDoList == null)
            return null;

        return _mapper.Map<ReadToDoListsDTO>(dbToDoList);
    }

    public ReadToDoListsDTO Add(AddToDoListsDTO ToDoList)
    {
        var dbModel = _mapper.Map<ToDoList>(ToDoList);
        dbModel.ListId = Guid.NewGuid();

        _todolistRepo.Add(dbModel);
        _todolistRepo.SaveChanges();

        return _mapper.Map<ReadToDoListsDTO>(dbModel);
    }

    public bool Update(UpdateToDoListsDTO todolistDTO)
    {
        var dbToDoList = _todolistRepo.GetById(todolistDTO.ListId);

        if (dbToDoList == null)
            return false;


        _mapper.Map(todolistDTO, dbToDoList);

        _todolistRepo.Update(dbToDoList);
        _todolistRepo.SaveChanges();

        return true;
    }

    public void Delete(Guid id)
    {
        _todolistRepo.DeleteById(id);
        _todolistRepo.SaveChanges();
    }

    #endregion
}
