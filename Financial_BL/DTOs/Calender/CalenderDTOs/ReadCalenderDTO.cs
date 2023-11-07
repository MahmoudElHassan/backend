using Financial_DAL;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_BL;

public class ReadCalenderDTO
{
    public int CalenderId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int ArrayLength { get; set; }
    public IEnumerable<int> Days { get; set; }

    public bool IsDelete { get; set; }

    //public virtual IList<Habit> Habits { get; set; }
}
