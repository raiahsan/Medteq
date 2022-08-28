using Application.CustomValidators;
using Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Patient
{
    public class PatientSearchDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int? PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }


    public class PatientSearchDtoValidator : AbstractValidator<PatientSearchDto>
    {
        public PatientSearchDtoValidator()
        {
            List<string> sortedColumns = new List<string>
           {
               {"CreatedDate" },
               {"FirstName" },
               {"LastName" },
           };
            RuleFor(x => x.PageIndex)
                .NotEmpty().WithMessage("PageIndex should be greater than 0");

            RuleFor(x => x.PageSize)
                .NotEmpty().WithMessage("PageSize should be greater than 0");

            RuleFor(x => x.FirstName)
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .MaximumLength(50);

            RuleFor(x => x.SortDirection)
                .IsValidSortDirection();

            RuleFor(x => x.SortColumn)
                .IsValidListMember(sortedColumns);

        }
    }
}
