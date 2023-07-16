using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Assign
{
    [Key]
    public int AssignId { get; set; }

    public string AssignedTo { get; set; } = string.Empty;

    public virtual ICollection<ToDoList> ToDoLists { get; set; } = new HashSet<ToDoList>();

}
