namespace Financial_DAL;

public interface IGoalRepo : IGenericRepo<Goal>
{
    List<Goal> GetGoalsByArea(int areaId);
}
