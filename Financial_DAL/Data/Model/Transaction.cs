using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Financial_DAL.Validations;

namespace Financial_DAL;

public class Transaction
{
    [Key]
    public Guid TransactionId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Address1 { get; set; } = string.Empty;

    [MaxLength(200)]
    public string Address2 { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string State { get; set; } = string.Empty;

    [Required]
    //[MaxLength(10)]
    public int Zip { get; set; } = 0;

    [Required]
    [MaxLength(20)]
    public string Country { get; set; } = string.Empty;


    [Required]
    public decimal Amount { get; set; } = decimal.Zero;

    [Range(0,100)]
    public int Taxes { get; set; } = 0;

    [DataType(DataType.Date)]
    [Required]
    //[OpenDateValidation]
    public DateTime Date { get; set; } = DateTime.Now;

    [ForeignKey("Categories")]
    public Guid Category_Id { get; set; }
    public virtual Category? Categories { get; set; }
}
