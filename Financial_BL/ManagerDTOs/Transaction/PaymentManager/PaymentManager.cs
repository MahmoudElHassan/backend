using AutoMapper;
using Financial_DAL;

namespace Financial_BL;

public class PaymentManager : IPaymentManager
{
    #region Field
    private readonly IPaymentRepo _paymentRepo;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public PaymentManager(IPaymentRepo paymentRepo, IMapper maapper)
    {
        _paymentRepo = paymentRepo;
        _mapper = maapper;
    }
    #endregion

    #region Methods

    public List<ReadPaymentDTO> GetLinksByTrans(Guid transactionId)
    {
        var dbPayment = _paymentRepo.GetLinksByTrans(transactionId).Where(d => d.IsDelete == false);

        return _mapper.Map<List<ReadPaymentDTO>>(dbPayment);
    }

    public ReadPaymentDTO GetById(int id)
    {
        var dbPayment = _paymentRepo.GetByintId(id);

        if (dbPayment == null)
            return null;

        return _mapper.Map<ReadPaymentDTO>(dbPayment);
    }

    public ReadPaymentDTO Add(AddPaymentDTO paymentDTO)
    {
        var dbModel = _mapper.Map<Payment>(paymentDTO);

        //dbModel.Transaction_Id = transactionId;

        _paymentRepo.Add(dbModel);
        _paymentRepo.SaveChanges();

        return _mapper.Map<ReadPaymentDTO>(dbModel);
    }

    public bool Update(UpdatePaymentDTO paymentDTO)
    {
        var dbPayment = _paymentRepo.GetByintId(paymentDTO.PaymentId);

        if (dbPayment == null)
            return false;

        _mapper.Map(paymentDTO, dbPayment);

        _paymentRepo.Update(dbPayment);
        _paymentRepo.SaveChanges();

        return true;
    }

    public void Delete(int id)
    {
        _paymentRepo.DeleteByintId(id);
        _paymentRepo.SaveChanges();
    }
    #endregion
}
