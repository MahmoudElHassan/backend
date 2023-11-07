using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class ToDoList
{
    [Key]
    public Guid ListId { get; set; }

    public bool Statu { get; set; } = false;
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; } = new DateTime();
    public DateTime EndDate { get; set; } = new DateTime();

    public bool TodayTask { get; set; }
    public bool Due { get; set; }
    public bool IsDelete { get; set; }

    [ForeignKey("Priority")]
    public int Priority_Id { get; set; }
    public virtual Priority Priority { get; set; }

    [ForeignKey("Assigns")]
    public int Assign_Id { get; set; }
    public virtual Assign Assigns { get; set; }

    [ForeignKey("Projects")]
    public int Project_Id { get; set; }
    public virtual Project Projects { get; set; }

}
