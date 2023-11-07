using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class Habit
{
    [Key]
    public int HabitId { get; set; }
    public string HabitName { get; set; }
    public IEnumerable<bool> Status { get; set; }

    public bool IsDelete { get; set; }

    [ForeignKey("Calenders")]
    public int Calender_Id { get; set; }
    public virtual Calender Calenders { get; set; }
}
