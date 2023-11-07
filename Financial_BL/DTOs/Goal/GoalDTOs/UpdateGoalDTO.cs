namespace Financial_BL;

public class UpdateGoalDTO
{
    public int GoalId { get; set; }
    public string GoalName { get; set; }
    public string DailyHabits { get; set; }
    public string WeeklyHabits { get; set; }
    public string MonthlyHabits { get; set; }
    public bool Status { get; set; }

    public int Area_Id { get; set; }
}
