namespace Financial_BL;

public class UpdatePaymentDTO
{
    public int PaymentId { get; set; }
    public string link { get; set; }

    public Guid Transaction_Id { get; set; }
}
