namespace Financial_BL;

public class ReadToDoListsDTO
{
    public Guid ListId { get; set; }

    public Boolean Statu { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public bool IsDelete { get; set; }

    public int Priority_Id { get; set; }

    public int Assign_Id { get; set; }
}
