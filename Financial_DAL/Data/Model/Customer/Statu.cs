using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Statu
{
    [Key]
    public int StatutId { get; set; }

    [MaxLength(50)]
    [Required]
    public string StatutName { get; set;} = string.Empty;

    //public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
}
