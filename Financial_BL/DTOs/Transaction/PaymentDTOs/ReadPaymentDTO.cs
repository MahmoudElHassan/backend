using Financial_DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_BL;

public class ReadPaymentDTO
{
    public int PaymentId { get; set; }
    public string link { get; set; }

    public Guid Transaction_Id { get; set; }
}
