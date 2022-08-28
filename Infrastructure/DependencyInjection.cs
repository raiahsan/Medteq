#region Imports
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain;
using Infrastructure.Repositories;
using Infrastructure.ExternalDependenciesImplementation;
using Application.RepositoryInterfaces;
using Application.ExternalDependencies;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Repositories.ProviderRepositories;
using Infrastructure.Repositories.UserRepositories;
using Infrastructure.Repositories.LeadRepositories;
using Infrastructure.Repositories.PatientRepositories;
using Infrastructure.Repositories.GeneralRepositories;
using Application.RepositoryInterfaces.IUserRepositories;
using Application.RepositoryInterfaces.ILeadRepositories;
using Application.RepositoryInterfaces.IPatientRepositories;
using Application.RepositoryInterfaces.IProviderRepositories;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using Infrastructure.Repositories.LookupRepositories;
#endregion

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IApiLogRepository, ApiLogRepository>();
            services.AddTransient<IExceptionLogRepository, ExceptionLogRepository>();
            services.AddTransient<ILeadRepository, LeadRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientPayorRepository, PatientPayorRepository>();
            services.AddTransient<IPayorRepository, PayorRepository>();
            services.AddTransient<IPatientContactRepository, PatientContactRepository>();
            services.AddTransient<IPatientAddressRepository, PatientAddressRepository>();
            services.AddTransient<ILeadContactRepository, LeadContactRepository>();
            services.AddTransient<IProviderRepository, ProviderRepository>();
            services.AddTransient<IProviderTypeRepository, ProviderTypeRepository>();
            services.AddTransient<IPatientProviderRepository, PatientProviderRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddTransient<IProviderAvailabilityRepository, ProviderAvailabilityRepository>();
            services.AddTransient<IProviderUnavailabilityRepository, ProviderUnavailabilityRepository>();
            services.AddTransient<IPatientDiagnosisRepository, PatientDiagnosisRepository>();
            services.AddTransient<IDiagnosisRepository, DiagnosisRepository>();

            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<IAddressTypeRepository, AddressTypeRepository>();
            services.AddTransient<IContactMethodRepository, ContactMethodRepository>();
            services.AddTransient<IContactTypeRepository, ContactTypeRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<ILeadSourceRepository, LeadSourceRepository>();
            services.AddTransient<ILeadTypeRepository, LeadTypeRepository>();
            services.AddTransient<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddTransient<IRelationshipTypeRepository, RelationshipTypeRepository>();
            services.AddTransient<IICDCodeTypeRepository, ICDCodeTypeRepository>();
            services.AddTransient<IPayorLevelRepository, PayorLevelRepository>();
            services.AddTransient<IPatientPayorEligibilityRepository, PatientPayorEligibilityRepository>();
            services.AddTransient<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddTransient<ISystemSettingRepository, SystemSettingRepository>();

            services.AddSingleton<IEmailHandler, EmailHandler>();
            services.AddMemoryCache();
            services.AddDbContext<AppDbContext>(opt => opt
                //.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}