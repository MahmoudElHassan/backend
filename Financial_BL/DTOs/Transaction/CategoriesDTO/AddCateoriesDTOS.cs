using System.ComponentModel.DataAnnotations;

namespace Financial_BL.DTOs;

public class AddCateoriesDTOS
{
    [StringLength(50)]
    public string Category_Name { get; set; } = string.Empty;
    public bool IsDelete { get; set; }

    public int Sale_Id { get; set; }
}
