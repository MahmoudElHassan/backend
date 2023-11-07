using Financial_DAL;
using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class UpdateTransactionDTO
{
    public Guid TransactionId { get; set; }

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; } = decimal.Zero;

    //[Range(0, 100)]
    public int Taxes { get; set; } = 0;

    [MaxLength(200)]
    public string Address1 { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Address2 { get; set; } = string.Empty;

    [MaxLength(20)]
    public string State { get; set; } = string.Empty;

    //[MaxLength(10)]
    public int Zip { get; set; } = 0;

    public string InvoiceID { get; set; }

    public bool Paid { get; set; }

    [MaxLength(20)]
    public string Country { get; set; } = string.Empty;

    public DateTime Date { get; set; }
    
    public Guid Category_Id { get; set; }

}
