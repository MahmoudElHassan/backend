using Financial_DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_BL;

public class ReadGoalDTO
{
    public int GoalId { get; set; }
    public string GoalName { get; set; }
    public string DailyHabits { get; set; }
    public string WeeklyHabits { get; set; }
    public string MonthlyHabits { get; set; }
    public bool Status { get; set; }
    public bool IsDelete { get; set; }

    public int Area_Id { get; set; }
}
