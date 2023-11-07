using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class AreaManager : IAreaManager
{
    #region Field
    private readonly IAreaRepo _areaRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public AreaManager(IAreaRepo areaRepo, IMapper maapper)
    {
        _areaRepo = areaRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadAreaDTO> GetAll()
    {
        var dbArea = _areaRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadAreaDTO>>(dbArea);
    }

    public ReadAreaDTO GetById(int id)
    {
        var dbArea = _areaRepo.GetByintId(id);

        if (dbArea == null)
            return null;

        return _mapper.Map<ReadAreaDTO>(dbArea);
    }

    public ReadAreaDTO Add(AddAreaDTO areaDTO)
    {
        var dbModel = _mapper.Map<Area>(areaDTO);

        _areaRepo.Add(dbModel);
        _areaRepo.SaveChanges();

        return _mapper.Map<ReadAreaDTO>(dbModel);
    }

    public bool Update(UpdateAreaDTO areaDTO)
    {
        var dbArea = _areaRepo.GetByintId(areaDTO.AreaId);

        if (dbArea == null)
            return false;


        _mapper.Map(areaDTO, dbArea);

        _areaRepo.Update(dbArea);
        _areaRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _areaRepo.DeleteByintId(id);
        _areaRepo.SaveChanges();
    }

    #endregion
}
