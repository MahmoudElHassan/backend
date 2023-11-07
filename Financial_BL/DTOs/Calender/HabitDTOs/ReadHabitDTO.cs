using Financial_DAL;

namespace Financial_BL;

public class ReadHabitDTO
{
    public int HabitId { get; set; }
    public string HabitName { get; set; }
    public IEnumerable<bool> Status { get; set; }
    public int Calender_Id { get; set; }
    public bool IsDelete { get; set; }
}
