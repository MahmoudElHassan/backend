using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class MainCategory
{
    [Key]
    public int MCategoryId { get; set; }

    [MaxLength(100)]
    public string MCategoryName { get; set; } = string.Empty;

    public bool IsDelete { get; set; }

    public virtual ICollection<SubCategory> SubCategories { get; set; } = new HashSet<SubCategory>();
    public virtual ICollection<UserDatabase> UserDatabases { get; set; } = new HashSet<UserDatabase>();

}
