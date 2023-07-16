namespace Financial_BL;

public class UpdateBoysDTO
{
    public Guid UserId { get; set; }
    public string BoyName { get; set; } = string.Empty;
    public DateTime BoyBirthday { get; set; } = DateTime.Now;
    public string BoyBirthPlace { get; set; } = string.Empty;
    public string Question { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;

    public int SCategory_Id { get; set; }
    public int MCategory_Id { get; set; }

}
