﻿using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class UpdateToDoListsDTO
{
    public Guid ListId { get; set; }

    public Boolean Statu { get; set; }
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int Priority_Id { get; set; }

    public int Assign_Id { get; set; }

    public int Project_Id { get; set; }
}
