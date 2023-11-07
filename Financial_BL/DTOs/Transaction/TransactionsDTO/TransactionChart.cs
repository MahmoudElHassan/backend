namespace Financial_BL;

public class TransactionChart
{
    public List<decimal> ExpensesAmounts { get; set; }
    public List<decimal> RevenuAmounts { get; set; }
    public List<decimal> ProfitAmounts { get; set; }

    public List<int> TopSalesMonths { get; set; }
    public List<decimal> TopSalesAmount { get; set; }

    public List<int> LowSalesMonths { get; set; }
    public List<decimal> LowSalesAmount { get; set; }

    public List<int> TopProfitMonths { get; set; }
    public List<decimal> TopProfitAmount { get; set; }

    public List<int> LowProfitMonths { get; set; }
    public List<decimal> LowProfitAmount { get; set; }

    public List<string> CategoryName { get; set; }
    public List<decimal> CategoryAmount { get; set; }

}
