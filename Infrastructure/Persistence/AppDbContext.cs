#region Imports

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.ServiceInterfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Application.ServiceInterfaces.IUserServices;

#endregion

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService) :
            base(options)
        {
            _currentUserService = currentUserService;
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityDirection> ActivityDirections { get; set; }
        public virtual DbSet<ActivityEmail> ActivityEmails { get; set; }
        public virtual DbSet<ActivityMessage> ActivityMessages { get; set; }
        public virtual DbSet<ActivityNote> ActivityNotes { get; set; }
        public virtual DbSet<ActivityPhoneCall> ActivityPhoneCalls { get; set; }
        public virtual DbSet<ActivityStatus> ActivityStatuses { get; set; }
        public virtual DbSet<ActivityTask> ActivityTasks { get; set; }
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }
        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<ContactMethod> ContactMethods { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Diagnosis> Diagnoses { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<ICDCodeType> ICDCodeTypes { get; set; }
        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<LeadContact> LeadContacts { get; set; }
        public virtual DbSet<LeadSource> LeadSources { get; set; }
        public virtual DbSet<LeadType> LeadTypes { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientAddress> PatientAddresses { get; set; }
        public virtual DbSet<PatientContact> PatientContacts { get; set; }
        public virtual DbSet<PatientDiagnosis> PatientDiagnoses { get; set; }
        public virtual DbSet<PatientPayor> PatientPayors { get; set; }
        public virtual DbSet<PatientPayorEligibility> PatientPayorEligibilities { get; set; }
        public virtual DbSet<PatientPayorEligibilityDetail> PatientPayorEligibilityDetails { get; set; }
        public virtual DbSet<PatientProvider> PatientProviders { get; set; }
        public virtual DbSet<Payor> Payors { get; set; }
        public virtual DbSet<PayorLevel> PayorLevels { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderAvailability> ProviderAvailabilities { get; set; }
        public virtual DbSet<ProviderType> ProviderTypes { get; set; }
        public virtual DbSet<ProviderUnavailability> ProviderUnavailabilities { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserToRole> UserToRoles { get; set; }
        public virtual DbSet<UserWorkflowStep> UserWorkflowSteps { get; set; }
        public virtual DbSet<Workflow> Workflows { get; set; }
        public virtual DbSet<WorkflowRecord> WorkflowRecords { get; set; }
        public virtual DbSet<WorkflowRecordNote> WorkflowRecordNotes { get; set; }
        public virtual DbSet<WorkflowRecordStateHistory> WorkflowRecordStateHistories { get; set; }
        public virtual DbSet<WorkflowRecordUserLock> WorkflowRecordUserLocks { get; set; }
        public virtual DbSet<WorkflowState> WorkflowStates { get; set; }
        public virtual DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public virtual DbSet<WorkflowStepHistory> WorkflowStepHistories { get; set; }
        public virtual DbSet<ApiLog> ApiLogs { get; set; }
        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = getZeroOrCurrentUserID();
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = getZeroOrCurrentUserID();
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = getZeroOrCurrentUserID();
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                }

            return base.SaveChangesAsync(cancellationToken);
        }

        private int getZeroOrCurrentUserID()
        {
            //var id = 0;
            //try
            //{
            //    if (!String.IsNullOrEmpty(_currentUserService.Fullname)){
            //        //id = _currentUserService.Fullname;
            //    }
            //}
            //catch (Exception)
            //{
            //}

            return _currentUserService?.UserId ?? 0;
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseModel>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = getZeroOrCurrentUserID();
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = getZeroOrCurrentUserID();
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = getZeroOrCurrentUserID();
                        entry.Entity.ModifiedDate = DateTime.Now;
                        break;
                }

            return base.SaveChanges();
        }

        public DataSet ExecuteSqlStoredProcedure(string sqlQueryToExecuteStoredProcedure, List<SqlParameter> parameters)
        {
            var dbConnection = Database.GetDbConnection();
            var dataset = new DataSet();
            var sqlDataAdapter = new SqlDataAdapter(sqlQueryToExecuteStoredProcedure, dbConnection.ConnectionString);
            sqlDataAdapter.SelectCommand.Parameters.Clear();
            if (parameters?.Count > 0)
            {
                sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
            }
            sqlDataAdapter.SelectCommand.CommandTimeout = 100;
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.Fill(dataset);
            return dataset;
        }
    }
}