using System.ComponentModel.DataAnnotations;

namespace Financial_DAL.Validations;

public class OpenDateValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return value is DateTime openDate && openDate == DateTime.Now;
    }
}