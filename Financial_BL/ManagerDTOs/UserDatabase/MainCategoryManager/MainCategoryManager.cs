using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class MainCategoryManager : IMainCategoryManager
{
    #region Field
    private readonly IMainCatregoryRepo _mainCategoryRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public MainCategoryManager(IMainCatregoryRepo mainCategoryRepo, IMapper maapper)
    {
        _mainCategoryRepo = mainCategoryRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadMainCategoryDTO> GetAll()
    {
        var dbMainCategory = _mainCategoryRepo.GetAll();

        return _mapper.Map<List<ReadMainCategoryDTO>>(dbMainCategory);
    }

    public ReadMainCategoryDTO? GetByintId(int id)
    {
        var dbMainCategory = _mainCategoryRepo.GetByintId(id);

        if (dbMainCategory == null)
            return null;

        return _mapper.Map<ReadMainCategoryDTO>(dbMainCategory);
    }

    public ReadMainCategoryDTO Add(AddMainCategoryDTO mainCategory)
    {
        var dbModel = _mapper.Map<MainCategory>(mainCategory);
        //dbModel.MCategoryId = Guid.NewGuid();

        _mainCategoryRepo.Add(dbModel);
        _mainCategoryRepo.SaveChanges();

        return _mapper.Map<ReadMainCategoryDTO>(dbModel);
    }

    public bool Update(UpdateMainCategoryDTO mainCategoryDTO)
    {
        var dbMainCategory = _mainCategoryRepo.GetByintId(mainCategoryDTO.MCategoryId);

        if (dbMainCategory == null)
            return false;

        _mapper.Map(mainCategoryDTO, dbMainCategory);

        _mainCategoryRepo.Update(dbMainCategory);
        _mainCategoryRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _mainCategoryRepo.DeleteByintId(id);
        _mainCategoryRepo.SaveChanges();
    }


    #endregion
}
