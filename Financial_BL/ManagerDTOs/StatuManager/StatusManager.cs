using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class StatusManager : IStatusManager
{
    #region Field
    private readonly IStatusRepo _statusRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public StatusManager(IStatusRepo statusRepo, IMapper maapper)
    {
        _statusRepo = statusRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadStatusDTOs> GetAll()
    {
        var dbStatus = _statusRepo.GetAll();

        return _mapper.Map<List<ReadStatusDTOs>>(dbStatus);
    }
    #endregion
}
