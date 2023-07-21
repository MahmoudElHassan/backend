namespace Financial_BL;

public class UpdateMainCategoryDTO
{
    public int MCategoryId { get; set; }
    public string MCategoryName { get; set; } = string.Empty;
    public bool IsDelete { get; set; }

}
