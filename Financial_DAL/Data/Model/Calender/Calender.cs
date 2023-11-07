using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class Calender
{
    [Key]
    public int CalenderId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int ArrayLength { get; set; }
    public IEnumerable<int> Days { get; set; }

    public bool IsDelete { get; set; }
    public virtual IList<Habit> Habits { get; set; }
}
