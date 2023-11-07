using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class UpdateCateoriesDTOS
{
    public Guid CategoryId { get; set; }

    [StringLength(50)]
    public string Category_Name { get; set; } = string.Empty;

    public int Sale_Id { get; set; }
}
