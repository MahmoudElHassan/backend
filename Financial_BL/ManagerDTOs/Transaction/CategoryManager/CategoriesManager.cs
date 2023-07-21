using AutoMapper;
using Financial_BL.DTOs;
using Financial_DAL;

namespace Financial_BL.ManagerDTOs.Transaction.CategoryManager;

public class CategoriesManager : ICategoriesManager
{
    #region Field
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public CategoriesManager(ICategoriesRepo categoriesRepo, IMapper maapper)
    {
        _categoriesRepo = categoriesRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadCateoriesDTOS> GetAll()
    {
        var dbCaetgory = _categoriesRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadCateoriesDTOS>>(dbCaetgory);
    }

    public ReadCateoriesDTOS? GetById(Guid id)
    {
        var dbCategory = _categoriesRepo.GetById(id);

        if (dbCategory == null)
            return null;

        return _mapper.Map<ReadCateoriesDTOS>(dbCategory);
    }

    public ReadCateoriesDTOS Add(AddCateoriesDTOS category)
    {
        var dbModel = _mapper.Map<Category>(category);
        dbModel.CategoryId = Guid.NewGuid();
        dbModel.IsDelete = false;

        _categoriesRepo.Add(dbModel);
        _categoriesRepo.SaveChanges();

        return _mapper.Map<ReadCateoriesDTOS>(dbModel);
    }

    public bool Update(UpdateCateoriesDTOS categoyDto)
    {
        var dbCategory = _categoriesRepo.GetById(categoyDto.CategoryId);

        if (dbCategory == null)
            return false;

        if (dbCategory.IsDelete == true)
            return false;

        _mapper.Map(categoyDto, dbCategory);

        _categoriesRepo.Update(dbCategory);
        _categoriesRepo.SaveChanges();

        return true;
    }

    public void Delete(Guid id)
    {
        _categoriesRepo.DeleteById(id);
        _categoriesRepo.SaveChanges();
    }

    #endregion
}
