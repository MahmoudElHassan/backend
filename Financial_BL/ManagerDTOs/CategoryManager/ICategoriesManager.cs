using Financial_BL.DTOs;

namespace Financial_BL;

public interface ICategoriesManager
{
    List<ReadCateoriesDTOS> GetAll();
    ReadCateoriesDTOS? GetById(Guid id);
    ReadCateoriesDTOS Add(AddCateoriesDTOS category);
    bool Update(UpdateCateoriesDTOS categoy);
    void Delete(Guid id);
}
