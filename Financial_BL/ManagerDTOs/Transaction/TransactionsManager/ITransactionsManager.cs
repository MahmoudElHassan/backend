namespace Financial_BL;

public interface ITransactionsManager
{
    List<ReadTransactionDTO> GetAll();
    List<ReadTransactionDTO> GetAllExpenses();
    List<ReadTransactionDTO> GetAllRevnue();
    //List<ReadTransactionDTO> GetExpensesInOrder();
    ReadTransactionDTO? GetById(Guid id);
    ReadTransactionDTO Add(AddTrasnactionDTO transaction);
    bool Update(UpdateTransactionDTO transaction);
    void Delete(Guid id);

    TransactionChart GetChart(int year);
}
