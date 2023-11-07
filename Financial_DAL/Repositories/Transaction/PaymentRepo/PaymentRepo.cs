namespace Financial_DAL;

public class PaymentRepo : GenericRepo<Payment>, IPaymentRepo
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public PaymentRepo(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    #endregion

    #region Methods
    public List<Payment> GetLinksByTrans(Guid transactioId)
    {
        return _context.Set<Payment>().Where(x => x.Transaction_Id == transactioId).ToList();
    }
    #endregion
}
