using Domain;
using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Enums = Domain.Enums;
using Newtonsoft.Json;
using Application.ServiceInterfaces;
using Application.RepositoryInterfaces;
using Application.Dto.Lead;
using Application.Dto.Patient;
using Application.Helper;
using Application.General.Dto;
using Application.ExternalDependencies;
using System.Linq;
using Application.ServiceInterfaces.IPatientServices;
using Application.RepositoryInterfaces.IPatientRepositories;

namespace Application.Services.PatientServices
{
    public class PayorService : IPayorService
    {
        private readonly IMapper _mapper;
        private readonly IPayorRepository _payorRepository;
        private readonly IEligibilityAPIHandler _eligibilityAPIHandler;

        public PayorService(
            IMapper mapper,
            IPayorRepository payorRepository,
            IEligibilityAPIHandler eligibilityAPIHandler)
        {
            _mapper = mapper;
            _payorRepository = payorRepository;
            _eligibilityAPIHandler = eligibilityAPIHandler;
        }

        public bool UpdatePayorList()
        {
            try
            {
                var pVerifyPayerList = _eligibilityAPIHandler.GetAllPayers();
                var payersInDB = _payorRepository.GetAll().Result.ToList();
                var payersToAdd = new List<Payor>();
                foreach (var item in pVerifyPayerList)
                {
                    Payor payor = payersInDB.Where(c => String.Equals(c.PayorCode, item.PayerCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (payor == null)
                    {
                        payor = new Payor();
                        payor.PayorGUID = Guid.NewGuid();
                        payersToAdd.Add(payor);
                    }
                    payor.PayorCode = item.PayerCode;
                    payor.PayorName = item.PayerName;
                    payor.Active = item.IsActive;
                    payor.IsEDIPayer = item.IsEDIPayer;
                    payor.IsSupportingClaims = item.IsSupportingClaims;
                    payor.IsSupportingEligibility = item.IsSupportingEligibility;
                    payor.RawData = JsonConvert.SerializeObject(item);
                }
                _payorRepository.AddRange(payersToAdd);
                _payorRepository.Complete();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
