using Application.Dto.PatientPayor;
using Application.Dto.PVerify;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ExternalDependencies
{
    public interface IEligibilityAPIHandler
    {
        List<PayerDto> GetAllPayers();
        dynamic CheckEligibilitySummary(PatientPayor patientPayor, Provider provider);
        dynamic CheckEligibilityInquiry();
        dynamic GetEligibilityInquiry(string requestID);
        dynamic GetEligibilitySummary(string requestID);
    }
}
