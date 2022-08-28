#region Imports

using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Application.ServiceInterfaces;
using FluentValidation.AspNetCore;
using Application.Dto.Lead;
using Microsoft.Extensions.Configuration;
using Application.Configurations;
using AutoMapper;
using Application.Mapper;
using Application.ServiceInterfaces.IUserServices;
using Application.Services.UserServices;
using Application.ServiceInterfaces.ILeadServices;
using Application.ServiceInterfaces.IPatientServices;
using Application.Services.PatientServices;
using Application.Services.LeadServices;
using Application.ServiceInterfaces.IGeneralServices;
using Application.ServiceInterfaces.IProviderServices;
using Application.Services.GeneralServices;
using Application.Services.ProviderServices;
using Application.ServiceInterfaces.ILookupServices;
using Application.Services.LookupServices;

#endregion

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IUsersService, UsersService>();
            services.AddScoped<IApiLogService, ApiLogService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IExceptionLogService, ExceptionLogService>();
            services.AddTransient<ILeadService, LeadService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPatientPayorService, PatientPayorService>();
            services.AddTransient<IContactTypeService, ContactTypeService>();
            services.AddTransient<IBranchService, BranchService>();
            services.AddTransient<ILookupService, LookupService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISystemSettingService, SystemSettingService>();
            services.AddTransient<IProviderService, ProviderService>();
            services.AddTransient<IPayorService, PayorService>();
            services.AddTransient<IAppointmentService, AppointmentService>();

            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MapperProfile()); });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(
                    fv =>
                    {
                        fv.RegisterValidatorsFromAssemblyContaining<CreateLeadDtoValidator>(lifetime: ServiceLifetime.Scoped, includeInternalTypes: true);
                        fv.ImplicitlyValidateChildProperties = true;
                    });
            return services;
        }

    }
}