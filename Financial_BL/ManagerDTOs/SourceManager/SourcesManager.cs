using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class SourcesManager : ISourcesManager
{
    #region Field
    private readonly ISourcesRepo _sourcesRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SourcesManager(ISourcesRepo sourcesRepo, IMapper maapper)
    {
        _sourcesRepo = sourcesRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadSourcesDTOs> GetAll()
    {
        var dbSources = _sourcesRepo.GetAll();

        return _mapper.Map<List<ReadSourcesDTOs>>(dbSources);
    }
    #endregion
}
