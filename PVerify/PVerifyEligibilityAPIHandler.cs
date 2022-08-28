using System;
using System.Collections.Generic;
using Application.Configurations;
using Application.Dto.PatientPayor;
using Application.Dto.PVerify;
using Application.ExternalDependencies;
using Application.Helper;
using Domain.Constants;
using Domain.Entities;
using PVerify.Models.PVerify;
using PVerify.Models.PVerify.EligibilityInquiryRequest;
using PVerify.Models.PVerify.EligibilitySummaryRequest;
using PVerify.Models.PVerify.EligibilitySummaryResponse;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace PVerify
{
    public class PVerifyEligibilityAPIHandler : IEligibilityAPIHandler
    {
        private readonly PVerifyApiSettings _pVerifyApiSettings;
        private readonly IMemoryCache _memoryCache;
        public PVerifyEligibilityAPIHandler(IOptions<PVerifyApiSettings> options, IMemoryCache memoryCache)
        {
            _pVerifyApiSettings = options.Value;
            _memoryCache = memoryCache;
        }
        #region Eligibility Inquiry Endpoints
        public dynamic CheckEligibilityInquiry()
        {
            try
            {
                var request = new EligibilityInquiryRequest
                {
                    PayerCode = "00192",
                    PayerName = "United Healthcare",
                    Provider =
                    {
                        FirstName = "",
                        MiddleName = "",
                        LastName = "Test",
                        NPI = "1234567890",
                        PIN = "00000",
                        Taxonomy = ""
                    },
                    Subscriber =
                    {
                        FirstName = "Saad",
                        DOB = DateTime.Now.AddYears(-20).ToString("MM/dd/yyyy"),
                        LastName = "Nasir",
                        SSN = "",
                        MemberId = "2121312"
                    },
                    Dependent = null,
                    DOSStartDate = DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy"),
                    DOSEndDate = DateTime.Now.AddMonths(6).ToString("MM/dd/yyyy"),
                    IsSubscriberPatient = "True",
                    Location = "NY",
                    CustomerId = "",
                    IncludeTextResponse = false,
                    InternalId = "",
                    ReferenceId = "12312",
                    ServiceCodes = new string[] { ServiceCode.HealthBenefitPlanCoverage },
                };
                return APIRequest<dynamic>("API/EligibilityInquiry", Method.POST, request);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public dynamic GetEligibilityInquiry(string requestID)
        {
            try
            {
                return APIRequest<dynamic>($"API/GetEligibilityResponse/{requestID}", Method.GET, null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Eligibility Summary Endpoints
        public dynamic GetEligibilitySummary(string requestID)
        {
            try
            {
                return APIRequest<dynamic>($"API/GetEligibilitySummary/{requestID}", Method.GET, null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public dynamic CheckEligibilitySummary(PatientPayor patientPayor, Provider provider)
        {
            try
            {
                var request = new EligibilitySummaryRequest
                {
                    PayerCode = patientPayor.Payor?.PayorCode,
                    PayerName = patientPayor.Payor?.PayorName,
                    Provider =
                    {
                        FirstName = provider.FirstName,
                        MiddleName = null,
                        LastName = provider.LastName,
                        NPI = provider.NPINumber,
                        PIN = null,
                        Taxonomy = provider.TaxonomyCode
                    },
                    Subscriber =
                    {
                        FirstName = patientPayor.Patient?.FirstName,
                        DOB = patientPayor.Patient?.DOB?.ToString("MM/dd/yyyy"),
                        LastName = patientPayor.Patient?.LastName,
                        SSN = patientPayor.Patient?.SSN,
                        MemberId = patientPayor.Patient?.PatientGUID.ToString()
                    },
                    Dependent = null,
                    DOSStartDate = DateTime.UtcNow.ToString("MM/dd/yyyy"),
                    DOSEndDate = DateTime.UtcNow.ToString("MM/dd/yyyy"),
                    IsSubscriberPatient = "True",
                    Location = provider.State,
                    CustomerId = null,
                    IncludeTextResponse = false,
                    InternalId = null,
                    PracticeTypeCode = PracticeTypeCode.DME.GetHashCode().ToString(),
                    ReferenceId = patientPayor.Patient?.AccountNumber,
                };
                return APIRequest<dynamic>("API/EligibilitySummary", Method.POST, request);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Payers Endpoint
        public List<PayerDto> GetAllPayers()
        {
            try
            {
                return APIRequest<List<PayerDto>>("API/GetAllPayers", Method.GET, null);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        private T APIRequest<T>(string endpointURL, Method method, object postBody)
        {
            var client = new RestClient($"{_pVerifyApiSettings.ApiUrl}");
            var request = new RestRequest($"{endpointURL}", method);
            request.AddHeader("Authorization", GetAccessToken());
            request.AddHeader("Client-API-Id", _pVerifyApiSettings.ClientID);
            request.AddHeader("Content-Type", "application/json");
            if (method != Method.GET)
            {
                request.AddJsonBody(JsonConvert.SerializeObject(postBody));
            }
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<T>(response.Content);
                return content;
            }
            else
            {
                throw new Exception(response.Content);
            }
        }
        private string GetAccessToken()
        {
            if (!_memoryCache.TryGetValue(CacheKey.PVerifyToken, out string accessToken))
            {
                var client = new RestClient($"{_pVerifyApiSettings.ApiUrl}");
                var request = new RestRequest("token", Method.POST);
                request.AddParameter("Client_Id", _pVerifyApiSettings.ClientID);
                request.AddParameter("Client_Secret", _pVerifyApiSettings.ClientSecret);
                request.AddParameter("grant_type", "client_credentials");
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful)
                {
                    var content = JsonConvert.DeserializeObject<PAuthToken>(response.Content);
                    accessToken = $"{content.TokenType} {content.AccessToken}";

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                         .SetAbsoluteExpiration(TimeSpan.FromSeconds(content.ExpireTimeInSeconds - 10));

                    _memoryCache.Set(CacheKey.PVerifyToken, accessToken, cacheEntryOptions);
                }
                else
                {
                    throw new Exception(response.Content);
                }
            }
            return accessToken;
        }
    }
}
