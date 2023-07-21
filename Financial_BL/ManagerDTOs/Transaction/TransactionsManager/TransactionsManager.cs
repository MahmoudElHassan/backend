using AutoMapper;
using Financial_BL.DTOs.TransactionsDTO;
using Financial_DAL;

namespace Financial_BL;

public class TransactionsManager : ITransactionsManager
{
    #region Field
    private readonly ITransactionsRepo _transactionsRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TransactionsManager(ITransactionsRepo transactionsRepo, IMapper maapper)
	{
        _transactionsRepo = transactionsRepo;
        _mapper = maapper;
    }
    #endregion

    #region Method
    public List<ReadTransactionDTO> GetAll()
    {
        var dbTransactions = _transactionsRepo.GetAll().Where(d=>d.IsDelete == false);

        return _mapper.Map<List<ReadTransactionDTO>>(dbTransactions);
    }

    public ReadTransactionDTO? GetById(Guid id)
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

        //if (dbModel.Description == null || dbModel.Address2 == null || dbModel.Taxes == null)
        //{
        //    dbModel.Description = "";
        //    dbModel.Address2 = "";
        //    dbModel.Taxes = 0;
        //}

        _transactionsRepo.Add(dbModel);
        _transactionsRepo.SaveChanges();

        return _mapper.Map<ReadTransactionDTO>(dbModel);
    }

    public bool Update(UpdateTransactionDTO transactionDTO)
    {
        var dbTransaction = _transactionsRepo.GetById(transactionDTO.TransactionId);

        if (dbTransaction == null) 
            return false;

        if (dbTransaction.IsDelete == true)
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

    #endregion
}