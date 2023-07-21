using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class AddCustomersDTOs
{
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Company { get; set; } = string.Empty;

    [MaxLength(100)]
    public string WorkFunction { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public decimal Sales { get; set; } = decimal.Zero;

    [MaxLength(100)]
    public string NextAction { get; set; } = string.Empty;

    public DateTime LastContact { get; set; } = DateTime.Now;


    public DateTime NextContact { get; set; } = DateTime.Now;

    [MaxLength(1000)]
    public string Notes { get; set; } = string.Empty;

    //[MaxLength(50)]
    //public string Owner { get; set; } = string.Empty;
    public bool IsDelete { get; set; }



    public int Statu_Id { get; set; }

    public int Source_Id { get; set; }
}
