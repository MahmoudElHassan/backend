using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Area
{
    [Key]
    public int AreaId { get; set; }
    public string AreaName { get; set; }
    public bool IsDelete { get; set; }
}
