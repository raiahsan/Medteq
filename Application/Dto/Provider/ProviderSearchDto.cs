using Application.CustomValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Provider
{
    public class ProviderSearchDto
    {
        public int? ProviderID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NPINumber { get; set; }
    }
    public class ProviderSearchDtoValidator : AbstractValidator<ProviderSearchDto>
    {
        public ProviderSearchDtoValidator()
        {
            List<string> sortedColumns = new List<string>
           {
               {"CreatedDate" },
               {"FirstName" },
               {"LastName" },
           };
            RuleFor(x => x.FirstName)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .MaximumLength(50);

            RuleFor(x => x.Email)
                .MaximumLength(50);
        }
    }
}
