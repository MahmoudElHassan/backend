using AutoMapper;
using Financial_DAL;
using Financial_DAL.Migrations;

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

        foreach (var item in dbToDoList)
        {
            item.Due = DueTime(item.EndDate);
            item.TodayTask = GetTodayTask(item.StartDate, item.EndDate);
        }

        return _mapper.Map<List<ReadToDoListsDTO>>(dbToDoList);
    }

    public List<ReadToDoListsDTO> GetTODoByProject(int projectId)
    {
        var dbToDoList = _todolistRepo.GetToDoByProject(projectId).Where(d => d.IsDelete == false);

        foreach (var item in dbToDoList)
        {
            item.Due = DueTime(item.EndDate);
            item.TodayTask = GetTodayTask(item.StartDate, item.EndDate);
        }

        return _mapper.Map<List<ReadToDoListsDTO>>(dbToDoList);
    }

    public ReadToDoListsDTO GetById(Guid id)
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
        dbModel.StartDate = ToDoList.StartDate.ToUniversalTime().Date;
        dbModel.EndDate = ToDoList.EndDate.ToUniversalTime().Date;

        dbModel.Due = DueTime(dbModel.EndDate);
        dbModel.TodayTask = GetTodayTask(dbModel.StartDate, dbModel.EndDate);

        _todolistRepo.Add(dbModel);
        _todolistRepo.SaveChanges();

        return _mapper.Map<ReadToDoListsDTO>(dbModel);
    }

    public bool Update(UpdateToDoListsDTO todolistDTO)
    {
        var dbToDoList = _todolistRepo.GetById(todolistDTO.ListId);

        if (dbToDoList == null)
            return false;

        if (dbToDoList.IsDelete == true)
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

    #region Provate Methods
    private bool DueTime(DateTime endDate)
    {
        DateTime date = DateTime.UtcNow;
        if (endDate.Date >= date.Date)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool GetTodayTask(DateTime startDate, DateTime endDate)
    {
        DateTime date = DateTime.UtcNow;
        if (startDate.Date <= date.Date && date.Date <= endDate.Date)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion
}
