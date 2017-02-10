using System;
using System.ComponentModel.DataAnnotations;

namespace ORMEntityFramework.Models.Helper
{
    public class MaiorDeIdadeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var data = (DateTime)value;
            var ticks = DateTime.Now.Ticks - data.Ticks;
            var dataIdade = new DateTime(ticks);
            if (!(dataIdade.Year >= 18))
            {
                return new ValidationResult("Diretor é menor de idade.");
            }
            return ValidationResult.Success;
        }
    }
}