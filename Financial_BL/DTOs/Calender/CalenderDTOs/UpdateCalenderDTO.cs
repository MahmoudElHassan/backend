using Financial_DAL;

namespace Financial_BL;

public class UpdateCalenderDTO
{
    public int CalenderId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int ArrayLength { get; set; }
    public IEnumerable<int> Days { get; set; }

    //public virtual IList<Habit> Habits { get; set; }
}
