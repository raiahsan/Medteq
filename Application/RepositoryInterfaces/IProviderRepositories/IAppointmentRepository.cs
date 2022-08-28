using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.RepositoryInterfaces.IProviderRepositories
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        List<Appointment> GetAppointmentsByProviderID(int providerID);
        List<Appointment> GetAppointmentsByPatientID(int patientID);
        Appointment GetAppointmentByID(int id);
    }
}
