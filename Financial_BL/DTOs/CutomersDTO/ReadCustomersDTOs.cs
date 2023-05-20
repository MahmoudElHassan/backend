using Financial_DAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Financial_BL;

public class ReadCustomersDTOs
{
    public Guid CustomerId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Company { get; set; } = string.Empty;

    public string WorkFunction { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public decimal Sales { get; set; } = decimal.Zero;

    public string NextAction { get; set; } = string.Empty;

    public DateTime LastContact { get; set; } = DateTime.Now;

    
    public DateTime NextContact { get; set; } = DateTime.Now;

    public string Notes { get; set; } = string.Empty;

    //public string Owner { get; set; } = string.Empty;


    public int Statu_Id { get; set; }

    public int Source_Id { get; set; }
}
