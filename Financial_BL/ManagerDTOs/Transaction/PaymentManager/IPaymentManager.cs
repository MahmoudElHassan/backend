namespace Financial_BL;

public interface IPaymentManager
{
    List<ReadPaymentDTO> GetLinksByTrans(Guid transactionId);
    ReadPaymentDTO GetById(int id);
    ReadPaymentDTO Add(AddPaymentDTO paymentDTO);
    bool Update(UpdatePaymentDTO paymentDTO);
    void Delete(int id);
}
