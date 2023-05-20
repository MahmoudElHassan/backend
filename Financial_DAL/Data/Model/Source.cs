using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Source
{
    [Key]
    public int SourceId { get; set; }

    [MaxLength(50)]
    [Required]
    public string SourceName { get; set; } = string.Empty;

    public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
}
