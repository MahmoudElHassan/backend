using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class UserDatabase
{
    [Key]
    public Guid UserId { get; set; }
    [MaxLength(100)]
    public string BoyName { get; set; } = string.Empty;
    public DateTime BoyBirthday { get; set;} = DateTime.Now;
    [MaxLength(100)]
    public string BoyBirthPlace { get; set; } = string.Empty;
    [MaxLength(100)]
    public string GirlName { get; set; } = string.Empty;
    public DateTime GirlBirthday { get; set; } = DateTime.Now;
    [MaxLength(100)]
    public string GirlBirthPlace { get; set; } = string.Empty;
    [MaxLength(250)]
    public string Question { get; set; } = string.Empty;
    [MaxLength(250)]
    public string Comment { get; set; } = string.Empty;

    public bool IsDelete { get; set; } 


    [ForeignKey("SubCategories")]
    public int SCategory_Id { get; set; }
    public virtual SubCategory SubCategories { get; set; }

    [ForeignKey("MainCategories")]
    public int MCategory_Id { get; set; }
    public virtual MainCategory MainCategories { get; set; }
}
