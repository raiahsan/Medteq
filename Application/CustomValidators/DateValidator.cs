using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Application.CustomValidators
{
    public class DateValidator : ValidationAttribute
    {
        private string _errorMessage { get; set; }
        public DateValidator(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (!DateTime.TryParse(value as string, out DateTime result))
                {
                    return new ValidationResult(_errorMessage);
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
        }
    }
}
