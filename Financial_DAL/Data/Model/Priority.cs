using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Priority
{
    [Key]
    public int PriorityId { get; set; }

    public string PriorityName { get; set; } = string.Empty;

    public virtual ICollection<ToDoList> ToDoLists { get; set; } = new HashSet<ToDoList>();

}
