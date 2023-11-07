namespace Financial_BL;

public interface ICalenderManager
{
    List<ReadCalenderDTO> GetAll();
    ReadCalenderDTO GetById(int id);
    ReadCalenderDTO Add(AddCalenderDTO calenderDTO);
    bool Update(UpdateCalenderDTO calenderDTO);
    void Delete(int id);
}
