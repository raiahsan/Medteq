#region Imports

using Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Application.Dto.UserAccount;
using Application.Dto.Patient;
using Application.Dto.ContactType;
using Application.Dto.Branch;
using Application.Dto.Lead;
using Application.Dto.General;
using Application.Dto.PatientProvider;
using Application.Dto.PatientPayor;
using Application.Dto.Appointment;
using Application.Dto.Provider;

#endregion

namespace Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserUpsertDto>();
            CreateMap<UserUpsertDto, User>();
            CreateMap<ContactType, ContactTypeDto>();
            CreateMap<PatientProvider, PatientProviderDto>();
            CreateMap<Provider, GetProviderDto>();

            CreateMap<ContactType, ContactTypeDto>();
            CreateMap<Branch, BranchDto>();
            CreateMap<SystemSetting, SystemSettingDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<ProviderAvailability, ProviderAvailabilityDto>();
            CreateMap<ProviderUnavailability, ProviderUnavailabilityDto>();
            CreateMap<PatientDiagnosis, PatientDiagnosisDto>();
            CreateMap<Diagnosis, GetDiagnosisDto>();

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Roles, opts => opts.MapFrom(src => src.UserToRoles.Select(c => c.Role.RoleName).ToList() ?? new List<string>()));
            CreateMap<UserDto, User>();

            CreateMap<Patient, GetPatientDto>()
                .ForMember(dest => dest.Branch, opts => opts.MapFrom(src => src.Branch != null ? src.Branch.BranchName : null))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender != null ? src.Gender.Value : null))
                .ForMember(dest => dest.MaritalStatus, opts => opts.MapFrom(src => src.MaritalStatus != null ? src.MaritalStatus.Value : null));
            //CreateMap<Patient, GetPatientDto>();

            CreateMap<PatientAddress, PatientAddressDto>()
                .ForMember(dest => dest.AddressType, opts => opts.MapFrom(src => src.AddressType != null ? src.AddressType.TypeName : null))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State != null ? src.State.Name : null));
            //CreateMap<PatientAddress, PatientAddressDto>();

            CreateMap<PatientContact, PatientContactDto>()
                .ForMember(dest => dest.ContactType, opts => opts.MapFrom(src => src.ContactType != null ? src.ContactType.Type : null))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State != null ? src.State.Name : null));
            //CreateMap<PatientContact, PatientContact>();

            CreateMap<Branch, BranchDto>()
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.State != null ? src.State.Name : null));
            //CreateMap<Branch, BranchDto>();

            CreateMap<Lead, GetLeadDto>()
                .ForMember(dest => dest.LeadType, opts => opts.MapFrom(src => src.LeadType != null ? src.LeadType.Name : null))
                .ForMember(dest => dest.LeadSource, opts => opts.MapFrom(src => src.LeadSource != null ? src.LeadSource.Name : null))
                .ForMember(dest => dest.Branch, opts => opts.MapFrom(src => src.Branch != null ? src.Branch.BranchName : null))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender != null ? src.Gender.Value : null))
                .ForMember(dest => dest.BillingState, opts => opts.MapFrom(src => src.BillingState != null ? src.BillingState.Name : null));

            CreateMap<LeadContact, LeadContactDto>()
                .ForMember(dest => dest.ContactMethod, opts => opts.MapFrom(src => src.ContactMethod != null ? src.ContactMethod.Name : null));

            CreateMap<PatientDiagnosis, PatientDiagnosisDto>()
                .ForMember(dest => dest.PatientID, opts => opts.MapFrom(src => src.Patient != null ? src.Patient.ID : 0))
                .ForMember(dest => dest.DiagnosisID, opts => opts.MapFrom(src => src.Diagnosis != null ? src.Diagnosis.ID : 0));

            CreateMap<PatientPayor, GetPatientPayorDto>()
                .ForMember(dest => dest.PayorCode, opts => opts.MapFrom(src => src.Payor != null ? src.Payor.PayorCode : null))
                .ForMember(dest => dest.PayorLevel, opts => opts.MapFrom(src => src.PayorLevel != null ? src.PayorLevel.Name : null))
                .ForMember(dest => dest.PayorID, opts => opts.MapFrom(src => src.Payor != null ? src.Payor.ID : 0))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.InsuredState != null ? src.InsuredState.Name : null))
                .ForMember(dest => dest.StateId, opts => opts.MapFrom(src => src.InsuredState != null ? src.InsuredState.ID : 0))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.PolicyHolderGender != null ? src.PolicyHolderGender.Value : null))
                .ForMember(dest => dest.GenderID, opts => opts.MapFrom(src => src.PolicyHolderGender != null ? src.PolicyHolderGender.ID : 0))
                .ForMember(dest => dest.PatientID, opts => opts.MapFrom(src => src.Patient != null ? src.Patient.ID : 0));

            CreateMap<PatientProvider, GetPatientProviderDto>()
               .ForMember(dest => dest.ProviderType, opts => opts.MapFrom(src => src.ProviderType != null ? src.ProviderType.Type : null))
               .ForMember(dest => dest.ProviderID, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.ID : 0))
               .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.FirstName : null))
               .ForMember(dest => dest.Note, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Note : null))
               .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.LastName : null))
               .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Title : null))
               .ForMember(dest => dest.Address1, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Address1 : null))
               .ForMember(dest => dest.Address2, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Address2 : null))
               .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.City : null))
               .ForMember(dest => dest.PostalCode, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.PostalCode : null))
               .ForMember(dest => dest.EmailAddress, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.EmailAddress : null))
               .ForMember(dest => dest.MobilePhone, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.MobilePhone : null))
               .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.PhoneNumber : null))
               .ForMember(dest => dest.FaxNumber, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.FaxNumber : null))
               .ForMember(dest => dest.DoctorGroup, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.DoctorGroup : null))
               .ForMember(dest => dest.Upin, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Upin : null))
               .ForMember(dest => dest.MedicalID, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.MedicalID : null))
               .ForMember(dest => dest.Deanumber, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Deanumber : null))
               .ForMember(dest => dest.DeaexpiryDate, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.DeaexpiryDate : null))
               .ForMember(dest => dest.LicenseExpiryDate, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.LicenseExpiryDate : null))
               .ForMember(dest => dest.StateMedicaidID, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.StateMedicaidID : null))
               .ForMember(dest => dest.NPINumber, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.NPINumber : null))
               .ForMember(dest => dest.CommercialNumber, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.CommercialNumber : null))
               .ForMember(dest => dest.TaxonomyCode, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.TaxonomyCode : null))
               .ForMember(dest => dest.Specialty, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Specialty : null))
               .ForMember(dest => dest.IMSRxerID, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.IMSRxerID : null))
               .ForMember(dest => dest.Location, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Location : null))
               .ForMember(dest => dest.MarketDecile, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.MarketDecile : null))
               .ForMember(dest => dest.DegreeDescription, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.DegreeDescription : null))
               .ForMember(dest => dest.Suffix, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.Suffix : null))
               .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.State : null))
               .ForMember(dest => dest.MiddleName, opts => opts.MapFrom(src => src.Provider != null ? src.Provider.MiddleName : null));
        }
    }
}
