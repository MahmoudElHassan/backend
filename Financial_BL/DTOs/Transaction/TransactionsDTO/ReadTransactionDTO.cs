using Financial_DAL;
using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class ReadTransactionDTO
{
    public Guid TransactionId { get; set; }

    public string Description { get; set; } = string.Empty;

    public decimal Amount { get; set; } = decimal.Zero;

    public int Taxes { get; set; } = 0;

    public string Address1 { get; set; } = string.Empty;

    public string Address2 { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public int Zip { get; set; } = 0;

    public string InvoiceID { get; set; }

    public bool Paid { get; set; }

    public bool IsDelete { get; set; }


    public string Country { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public Guid Category_Id { get; set; }

    public virtual List<ReadPaymentDTO> Payments { get; set; }

    //public ReadTransactionDTO()
    //{
    //    Payments= new List<ReadPaymentDTO>();
    //}
}
