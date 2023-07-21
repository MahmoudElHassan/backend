using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [StringLength(50)]
    [Required]
    public string Category_Name { get; set; } = string.Empty;

    public bool IsDelete { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

    [ForeignKey("Sales")]
    public int Sale_Id { get; set; }
    public virtual Sale? Sales { get; set; }
}
