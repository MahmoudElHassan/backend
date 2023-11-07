using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class Goal
{
    [Key]
    public int GoalId { get; set; }
    public string GoalName { get; set; }
    public string DailyHabits { get; set; }
    public string WeeklyHabits { get; set; }
    public string MonthlyHabits { get; set; }
    public bool Status { get; set; }
    public bool IsDelete { get; set; }

    [ForeignKey("Areas")]
    public int Area_Id { get; set; }
    public virtual Area Areas { get; set; }
}
