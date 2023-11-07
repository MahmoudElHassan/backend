namespace Financial_BL;

public class ReadToDoListsDTO
{
    public Guid ListId { get; set; }

    public Boolean Statu { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool TodayTask { get; set; }
    public bool Due { get; set; }
    public bool IsDelete { get; set; }

    public int Priority_Id { get; set; }

    public int Assign_Id { get; set; }

    public int Project_Id { get; set; }
}
