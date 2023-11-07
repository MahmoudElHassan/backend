namespace Financial_BL;

public interface IGoalManager
{
    List<ReadGoalDTO> GetAll();
    ReadGoalDTO GetById(int id);
    List<ReadGoalDTO> GetGoalsByArea(int areaId);
    ReadGoalDTO Add(AddGoalDTO goalDTO);
    bool Update(UpdateGoalDTO goalDTO);
    void Delete(int id);
}
