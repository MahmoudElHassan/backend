using System.ComponentModel.DataAnnotations;

namespace Financial_DAL;

public class Project
{
    [Key]
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public bool IsDelete { get; set; }
    //public virtual ICollection<ToDoList> ToDoLists { get; set; } = new HashSet<ToDoList>();
}
