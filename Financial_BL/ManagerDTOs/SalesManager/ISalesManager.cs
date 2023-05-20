using Financial_BL.DTOs.SalesDTO;

namespace Financial_BL;

public interface ISalesManager
{
    List<ReadSaleDTO> GetAll();
}
