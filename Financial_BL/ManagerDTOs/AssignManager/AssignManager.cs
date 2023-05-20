using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class AssignManager : IAssignManager
{
    #region Field
    private readonly IAssignRepo _assignRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public AssignManager(IAssignRepo assginRepo, IMapper maapper)
    {
        _assignRepo = assginRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadAssignsDTO> GetAll()
    {
        var dbAssign = _assignRepo.GetAll();

        return _mapper.Map<List<ReadAssignsDTO>>(dbAssign);
    }
    #endregion
}
