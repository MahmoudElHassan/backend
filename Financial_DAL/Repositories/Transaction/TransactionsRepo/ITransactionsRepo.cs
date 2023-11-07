namespace Financial_DAL;

public interface ITransactionsRepo : IGenericRepo<Transaction>
{
    List<Transaction> GetExpenses();
    List<Transaction> GetRevnue();
    //List<Transaction> GetExpensesInOrder();
    //List<Transaction> GetExpensesInOrderDescending();
    //List<Transaction> GetRevenuInOrder();
    //List<Transaction> GetRevenuInOrderDescending();
}
