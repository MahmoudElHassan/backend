using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class SubCategory
{
    [Key]
    public int SCategoryId { get; set; }
    [MaxLength(100)]
    public string SCategoryName { get; set; } = string.Empty;

    [ForeignKey("MainCategoryies")]
    public int MCategory_Id { get; set; }
    public bool IsDelete { get; set; }

    public virtual MainCategory MainCategoryies { get; set; }
    public virtual ICollection<UserDatabase> UserDatabases { get; set; } = new HashSet<UserDatabase>();
}
