using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class ReadCateoriesDTOS
{
    public Guid CategoryId { get; set; }
    public string Category_Name { get; set; } = string.Empty;
    public int Sale_Id { get; set; }
    //public bool IsDelete { get; set; }
}
