using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class Customer
{
    [Key]
    public Guid CustomerId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Company { get; set; } = string.Empty;

    [MaxLength(100)]
    public string WorkFunction { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public decimal Sales { get; set; } = decimal.Zero;

    [MaxLength(100)]
    public string NextAction { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime LastContact { get; set; } = DateTime.Now;

    [DataType(DataType.Date)]
    public DateTime NextContact { get; set; } = DateTime.Now;

    [MaxLength(1000)]
    public string Notes { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Owner { get; set; } = string.Empty;


    [ForeignKey("Status")]
    public int Statu_Id { get; set; }
    public virtual Statu? Status { get; set; }

    [ForeignKey("Sources")]
    public int Source_Id { get; set; }
    public virtual Source? Sources { get; set; }
}
