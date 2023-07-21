using Financial_DAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class ReadSubCategoryDTO
{
    public int SCategoryId { get; set; }
    public string SCategoryName { get; set; } = string.Empty;
    public bool IsDelete { get; set; }


    public int MCategory_Id { get; set; }
}
