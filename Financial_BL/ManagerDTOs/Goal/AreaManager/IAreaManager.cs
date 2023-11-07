namespace Financial_BL;

public interface IAreaManager
{
    List<ReadAreaDTO> GetAll();
    ReadAreaDTO GetById(int id);
    ReadAreaDTO Add(AddAreaDTO areaDTO);
    bool Update(UpdateAreaDTO areaDTO);
    void Delete(int id);
}
