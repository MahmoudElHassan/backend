using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Sale
{
    public int SaleId { get; set; }

    [MaxLength(50)]
    [Required]
    public string Category_Type { get; set; } = string.Empty;

    //public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
}
