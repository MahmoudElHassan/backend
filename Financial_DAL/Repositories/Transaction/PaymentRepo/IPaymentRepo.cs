namespace Financial_DAL;

public interface IPaymentRepo : IGenericRepo<Payment>
{
    List<Payment> GetLinksByTrans(Guid transactioId);
}
