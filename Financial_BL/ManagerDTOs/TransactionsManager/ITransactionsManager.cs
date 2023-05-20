using Financial_BL.DTOs;
using Financial_BL.DTOs.TransactionsDTO;
using Financial_DAL;

namespace Financial_BL;

public interface ITransactionsManager
{
    List<ReadTransactionDTO> GetAll();
    ReadTransactionDTO? GetById(Guid id);
    ReadTransactionDTO Add(AddTrasnactionDTO transaction);
    bool Update(UpdateTransactionDTO transaction);
    void Delete(Guid id);

}
