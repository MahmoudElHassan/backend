namespace Financial_BL;

public interface ISubCategoryManager
{
    List<ReadSubCategoryDTO> GetAll();
    ReadSubCategoryDTO? GetByintId(int id);
    ReadSubCategoryDTO Add(AddSubCategoryDTO subCategory);
    bool Update(UpdateSubCategoryDTO subCategory);
    void Delete(int id);

}
