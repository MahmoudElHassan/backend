using AutoMapper;
using Financial_DAL;
using System.Data.Common;

namespace Financial_BL;

public class SubCategoryManager : ISubCategoryManager
{
    #region Field
    private readonly ISubCategoryRepo _subCategoryRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SubCategoryManager(ISubCategoryRepo subCategoryRepo, IMapper maapper)
    {
        _subCategoryRepo = subCategoryRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadSubCategoryDTO> GetAll()
    {
        var dbSubCategory = _subCategoryRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadSubCategoryDTO>>(dbSubCategory);
    }

    public ReadSubCategoryDTO? GetByintId(int id)
    {
        var dbSubCategory = _subCategoryRepo.GetByintId(id);

        if (dbSubCategory == null)
            return null;

        return _mapper.Map<ReadSubCategoryDTO>(dbSubCategory);
    }

    public ReadSubCategoryDTO Add(AddSubCategoryDTO subCategory)
    {
        var dbModel = _mapper.Map<SubCategory>(subCategory);
        //dbModel.MCategoryId = Guid.NewGuid();
        dbModel.IsDelete = false;

        _subCategoryRepo.Add(dbModel);
        _subCategoryRepo.SaveChanges();

        return _mapper.Map<ReadSubCategoryDTO>(dbModel);
    }

    public bool Update(UpdateSubCategoryDTO subCategoryDTO)
    {
        var dbSubCategory = _subCategoryRepo.GetByintId(subCategoryDTO.SCategoryId);

        if (dbSubCategory == null)
            return false;

        if (dbSubCategory.IsDelete == true)
            return false;

        _mapper.Map(subCategoryDTO, dbSubCategory);

        _subCategoryRepo.Update(dbSubCategory);
        _subCategoryRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _subCategoryRepo.DeleteByintId(id);
        _subCategoryRepo.SaveChanges();
    }

    #endregion
}
