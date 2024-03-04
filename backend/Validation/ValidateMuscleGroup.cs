using backend.Constants;
using System.ComponentModel.DataAnnotations;

namespace backend.Validation
{
    public class ValidateMuscleGroup : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null || !Enum.IsDefined(typeof(MuscleGroup), value))
            {
                return new ValidationResult("Invalid muscle group.");
            }

            return ValidationResult.Success;
        }
    }
}
