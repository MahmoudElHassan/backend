using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class Payment
{
    [Key]
    public int PaymentId { get; set; }
    public string link { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("Transactions")]
    public Guid Transaction_Id { get; set; }
    public virtual Transaction Transactions { get; set; }
}
