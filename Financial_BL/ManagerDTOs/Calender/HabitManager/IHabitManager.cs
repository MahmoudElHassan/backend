namespace Financial_BL;

public interface IHabitManager
{
    List<ReadHabitDTO> GetAll();
    ReadHabitDTO GetById(int id);
    ReadHabitDTO Add(AddHabitDTO habitDTO);
    bool Update(UpdateHabitDTO habitDTO);
    void Delete(int id);
}
