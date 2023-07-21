using System.ComponentModel.DataAnnotations;

namespace Financial_BL.DTOs.TransactionsDTO;

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

    public bool IsDelete { get; set; }


    public string Country { get; set; } = string.Empty;

    public DateTime Date { get; set; } = DateTime.Now;

    public Guid Category_Id { get; set; }
}
