namespace Financial_BL;

public interface IMainCategoryManager
{
    List<ReadMainCategoryDTO> GetAll();
    ReadMainCategoryDTO? GetByintId(int id);
    ReadMainCategoryDTO Add(AddMainCategoryDTO mainCategory);
    bool Update(UpdateMainCategoryDTO mainCategory);
    void Delete(int id);
}
