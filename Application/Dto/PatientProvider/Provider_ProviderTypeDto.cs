using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IProviderRepositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.PatientProvider
{
    public class Provider_ProviderTypeDto
    {
        public int ProviderID { get; set; }
        public int ProviderTypeID { get; set; }
    }

    public class Provider_ProviderTypeDtoValidator : AbstractValidator<Provider_ProviderTypeDto>
    {
        public Provider_ProviderTypeDtoValidator(IProviderTypeRepository providerTypeRepository)
        {
            RuleFor(x => x.ProviderID)
                .NotEmpty().WithMessage("ProviderID is required");

            RuleFor(x => x.ProviderTypeID)
                .NotEmpty().WithMessage("ProviderTypeID is required")
                .Must(c => providerTypeRepository.GetProviderType(c) != null)
                .WithMessage($"ProviderTypeID field should only contain one of the following values ({String.Join(',', providerTypeRepository.GetAllProviderTypes(true).Select(c => c.ID + " => " + c.Type))})");
        }
    }
}
