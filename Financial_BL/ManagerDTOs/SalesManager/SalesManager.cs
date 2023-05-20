using AutoMapper;
using Financial_BL.DTOs.SalesDTO;
using Financial_DAL;

namespace Financial_BL;

public class SalesManager : ISalesManager
{
    #region Field
    private readonly ISalesRepo _salesRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public SalesManager(ISalesRepo salesRepo, IMapper maapper)
    {
        _salesRepo = salesRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadSaleDTO> GetAll()
    {
        var dbSales = _salesRepo.GetAll();

        return _mapper.Map<List<ReadSaleDTO>>(dbSales);
    }
    #endregion
}
