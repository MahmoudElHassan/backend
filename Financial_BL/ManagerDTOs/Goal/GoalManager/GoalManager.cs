using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class GoalManager : IGoalManager
{
    #region Field
    private readonly IGoalRepo _goalRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public GoalManager(IGoalRepo goalRepo, IMapper maapper)
    {
        _goalRepo = goalRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadGoalDTO> GetAll()
    {
        var dbGoal = _goalRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadGoalDTO>>(dbGoal);
    }

    public ReadGoalDTO GetById(int id)
    {
        var dbGoal = _goalRepo.GetByintId(id);

        if (dbGoal == null)
            return null;

        return _mapper.Map<ReadGoalDTO>(dbGoal);
    }

    public List<ReadGoalDTO> GetGoalsByArea(int areaId)
    {
        var dbGoal = _goalRepo.GetGoalsByArea(areaId)
            .Where(d => d.IsDelete == false).ToList();

        if (dbGoal == null)
            return null;

        return _mapper.Map<List<ReadGoalDTO>>(dbGoal);
    }

    public ReadGoalDTO Add(AddGoalDTO goalDTO)
    {
        var dbModel = _mapper.Map<Goal>(goalDTO);

        _goalRepo.Add(dbModel);
        _goalRepo.SaveChanges();

        return _mapper.Map<ReadGoalDTO>(dbModel);
    }

    public bool Update(UpdateGoalDTO goalDTO)
    {
        var dbGoal = _goalRepo.GetByintId(goalDTO.GoalId);

        if (dbGoal == null)
            return false;


        _mapper.Map(goalDTO, dbGoal);

        _goalRepo.Update(dbGoal);
        _goalRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _goalRepo.DeleteByintId(id);
        _goalRepo.SaveChanges();
    }

    #endregion
}
