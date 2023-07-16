using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class PriorityManager : IPriorityManager
{

    #region Field
    private readonly IPriorityrepo _priorityRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public PriorityManager(IPriorityrepo priorityRepo, IMapper maapper)
    {
        _priorityRepo = priorityRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadPriorityDTO> GetAll()
    {
        var dbPriority = _priorityRepo.GetAll();

        return _mapper.Map<List<ReadPriorityDTO>>(dbPriority);
    }
    #endregion
}