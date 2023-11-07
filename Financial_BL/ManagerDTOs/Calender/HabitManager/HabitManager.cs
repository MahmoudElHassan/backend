using AutoMapper;
using Financial_DAL;
using System.Globalization;

namespace Financial_BL;

public class HabitManager : IHabitManager
{
    #region Field
    private readonly IHabitRepo _habitRepo;
    private readonly ICalenderManager _calenderManager;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public HabitManager(IHabitRepo habitRepo,
        ICalenderManager calenderManager,
        IMapper maapper)
    {
        _habitRepo = habitRepo;
        _calenderManager = calenderManager;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadHabitDTO> GetAll()
    {
        var dbHabit = _habitRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadHabitDTO>>(dbHabit);
    }

    public ReadHabitDTO GetById(int id)
    {
        var dbHabit = _habitRepo.GetByintId(id);

        if (dbHabit == null)
            return null;

        return _mapper.Map<ReadHabitDTO>(dbHabit);
    }

    public ReadHabitDTO Add(AddHabitDTO habitDTO)
    {
        var dbModel = _mapper.Map<Habit>(habitDTO);

        //var data = dbModel.Calenders
        //    .FirstOrDefault(z => z.Habit_Id == dbModel.HabitId);

        var calender = _calenderManager.GetById(dbModel.Calender_Id);

        bool[] status = new bool[calender.ArrayLength];

        dbModel.Status = status;

        _habitRepo.Add(dbModel);
        _habitRepo.SaveChanges();

        return _mapper.Map<ReadHabitDTO>(dbModel);
    }

    public bool Update(UpdateHabitDTO habitDTO)
    {
        var dbHabit = _habitRepo.GetByintId(habitDTO.HabitId);

        if (dbHabit == null)
            return false;

        var calender = _calenderManager.GetById(dbHabit.Calender_Id);

        if (calender.ArrayLength != habitDTO.Status.ToArray().Length + 1)
        {
            bool[] status = new bool[calender.ArrayLength];

            dbHabit.Status = status;
        }

        _mapper.Map(habitDTO, dbHabit);

        _habitRepo.Update(dbHabit);
        _habitRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _habitRepo.DeleteByintId(id);
        _habitRepo.SaveChanges();
    }

    #endregion
}
