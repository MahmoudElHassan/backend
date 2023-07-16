using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class AddToDoListsDTO
{
    public Boolean Statu { get; set; }
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime Date { get; set; } = DateTime.Now;

    public int Priority_Id { get; set; }

    public int Assign_Id { get; set; }
}
