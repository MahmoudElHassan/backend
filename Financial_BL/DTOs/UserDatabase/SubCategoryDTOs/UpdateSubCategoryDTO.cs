namespace Financial_BL;

public class UpdateSubCategoryDTO
{
    public int SCategoryId { get; set; }
    public string SCategoryName { get; set; } = string.Empty;
    public bool IsDelete { get; set; }

    public int MCategory_Id { get; set; }
}
