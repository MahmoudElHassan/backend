using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial_DAL;

public class ToDoList
{
    [Key]
    public Guid ListId { get; set; }

    public Boolean Statu { get; set; }
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;

    [ForeignKey("Priority")]
    public int Priority_Id { get; set; }
    public virtual Priority? Priority { get; set; }

    [ForeignKey("Assigns")]
    public int Assign_Id { get; set; }
    public virtual Assign? Assigns { get; set; }

}
