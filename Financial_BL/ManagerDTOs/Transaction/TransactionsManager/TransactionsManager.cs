using AutoMapper;
using Financial_DAL;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NPoco.FluentMappings;
using System.Text;

namespace Financial_BL;

public class TransactionsManager : ITransactionsManager
{
    #region Field
    private readonly ITransactionsRepo _transactionsRepo;
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransactionsManager(
        ITransactionsRepo transactionsRepo,
        ICategoriesRepo categoriesRepo,
        IMapper maapper)
    {
        _transactionsRepo = transactionsRepo;
        _categoriesRepo = categoriesRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method

    public List<ReadTransactionDTO> GetAll()
    {
        var dbTransactions = _transactionsRepo.GetAll().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadTransactionDTO>>(dbTransactions);
    }

    public List<ReadTransactionDTO> GetAllExpenses()
    {
        var dbTransactions = _transactionsRepo.GetExpenses().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadTransactionDTO>>(dbTransactions);
    }

    public List<ReadTransactionDTO> GetAllRevnue()
    {
        var dbTransactions = _transactionsRepo.GetRevnue().Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadTransactionDTO>>(dbTransactions);
    }

    public ReadTransactionDTO GetById(Guid id)
    {
        var dbTransactions = _transactionsRepo.GetById(id);

        if (dbTransactions == null)
            return null;

        return _mapper.Map<ReadTransactionDTO>(dbTransactions);
    }

    public ReadTransactionDTO Add(AddTrasnactionDTO transaction)
    {
        var dbModel = _mapper.Map<Transaction>(transaction);
        dbModel.TransactionId = Guid.NewGuid();
        dbModel.Paid = false;
        dbModel.Date = transaction.Date.ToUniversalTime().Date;

        // Create InvoiceID
        Random rnd = new Random();
        dbModel.InvoiceID = "#" + rnd.Next(10000000, 100000000).ToString();

        _transactionsRepo.Add(dbModel);
        _transactionsRepo.SaveChanges();

        return _mapper.Map<ReadTransactionDTO>(dbModel);
    }

    public bool Update(UpdateTransactionDTO transactionDTO)
    {
        var dbTransaction = _transactionsRepo.GetById(transactionDTO.TransactionId);

        if (dbTransaction == null)
            return false;

        _mapper.Map(transactionDTO, dbTransaction);

        _transactionsRepo.Update(dbTransaction);
        _transactionsRepo.SaveChanges();

        return true;
    }

    public void Delete(Guid id)
    {
        _transactionsRepo.DeleteById(id);
        _transactionsRepo.SaveChanges();
    }

    public TransactionChart GetChart(int year)
    {
        // Models Lists
        var dbModel = new TransactionChart();
        var dbExpenses = GetAllExpenses().Where(d => d.Date.Year == year).ToList();
        var dbRevenu = GetAllRevnue().Where(d => d.Date.Year == year).ToList();

        // Variables 
        List<decimal> expAmount = new List<decimal>();
        List<decimal> revAmount = new List<decimal>();
        List<decimal> profitAmount = new List<decimal>();
        List<int> topSalesMonths = new List<int>();
        List<decimal> topSalesAmount = new List<decimal>();
        List<int> lowSalesMonths = new List<int>();
        List<decimal> lowSalesAmount = new List<decimal>();
        List<int> topProfitMonths = new List<int>();
        List<decimal> topProfitAmount = new List<decimal>();
        List<int> lowProfitMonths = new List<int>();
        List<decimal> lowProfitAmount = new List<decimal>();
        List<string> categoryName = new List<string>();
        List<decimal> categoryAmount = new List<decimal>();
        decimal sum = 0;


        for (int i = 1; i <= 12; i++)
        {
            // Expenses Arrays
            var expenses = dbExpenses.Where(d => d.Date.Month == i).ToList();
            foreach (var item in expenses)
            {
                sum += item.Amount;
            }
            expAmount.Add(sum);
            sum = 0;

            // Revenu Arrays
            var revenu = dbRevenu.Where(d => d.Date.Month == i).ToList();
            foreach (var item in revenu)
            {
                sum += item.Amount;
            }
            revAmount.Add(sum);
            sum = 0;

            // Profit Arrays
            profitAmount.Add(revAmount[i - 1] - expAmount[i - 1]);
        }
        dbModel.ExpensesAmounts = expAmount;
        dbModel.RevenuAmounts = revAmount;
        dbModel.ProfitAmounts = profitAmount;

        // Tob 3 Sales
        List<decimal> topSalesArray = new List<decimal>();
        foreach (var item in revAmount)
        {
            topSalesArray.Add(item);
        }
        for (int i = 0; i < 12; i++)
        {
            decimal maxValue = topSalesArray.Max();
            if (maxValue == 0)
            {
                topSalesArray.Remove(maxValue);
            }
            else
            {
                int maxIndex = revAmount.FindIndex(a => a == maxValue);
                topSalesMonths.Add(maxIndex + 1);
                topSalesAmount.Add(maxValue);
                topSalesArray.Remove(maxValue);
            }
        }
        dbModel.TopSalesMonths = topSalesMonths;
        dbModel.TopSalesAmount = topSalesAmount;
        



        // Lowast 3 Sales
        List<decimal> lowSalesArray = new List<decimal>();
        foreach (var item in revAmount)
        {
            lowSalesArray.Add(item);
        }
        for (int i = 0; i < 12; i++)
        {
            decimal minValue = lowSalesArray.Min();
            if (minValue == 0)
            {
                lowSalesArray.Remove(minValue);
            }
            else
            {
                int minIndex = revAmount.FindIndex(a => a == minValue);
                lowSalesMonths.Add(minIndex + 1);
                lowSalesAmount.Add(minValue);
                lowSalesArray.Remove(minValue);
            }
        }
        dbModel.LowSalesMonths = lowSalesMonths;
        dbModel.LowSalesAmount = lowSalesAmount;


        // Tob 3 Profit
        List<decimal> topProfitArray = new List<decimal>();
        foreach (var item in profitAmount)
        {
            topProfitArray.Add(item);
        }
        for (int i = 0; i < 12; i++)
        {
            decimal maxValue = topProfitArray.Max();
            if (maxValue == 0)
            {
                topProfitArray.Remove(maxValue);
            }
            else
            {
                int maxIndex = profitAmount.FindIndex(a => a == maxValue);
                topProfitMonths.Add(maxIndex + 1);
                topProfitAmount.Add(maxValue);
                topProfitArray.Remove(maxValue);
            }
        }
        dbModel.TopProfitMonths = topProfitMonths;
        dbModel.TopProfitAmount = topProfitAmount;


        // Lowast 3 Profit
        List<decimal> lowProfitArray = new List<decimal>();
        foreach (var item in profitAmount)
        {
            lowProfitArray.Add(item);
        }
        for (int i = 0; i < 12; i++)
        {
            decimal minValue = lowProfitArray.Min();
            if (minValue == 0)
            {
                lowProfitArray.Remove(minValue);
            }
            else
            {
                int minIndex = profitAmount.FindIndex(a => a == minValue);
                lowProfitMonths.Add(minIndex + 1);
                lowProfitAmount.Add(minValue);
                lowProfitArray.Remove(minValue);
            }
        }
        dbModel.LowProfitMonths = lowProfitMonths;
        dbModel.LowProfitAmount = lowProfitAmount;


        // Total Expenses foreach Category
        var category = _categoriesRepo.GetAll().Where(x => x.Sale_Id == 1 && x.IsDelete == false).ToList();
        foreach (var categ in category)
        {
            
            foreach (var expens in dbExpenses)
            {
                if (categ.CategoryId == expens.Category_Id)
                {
                    sum += expens.Amount;
                }
            }
            if (sum > 0)
            {
                categoryName.Add(categ.Category_Name);
                categoryAmount.Add(sum);
                sum = 0;
            }
        }
        dbModel.CategoryName = categoryName;
        dbModel.CategoryAmount = categoryAmount;

        return dbModel;
    }

    #endregion
}