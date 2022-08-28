using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IProviderRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories.ProviderRepositories
{
    class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(AppDbContext context) : base(context)
        {
        }
        public List<Appointment> GetAppointmentsByProviderID(int providerID)
        {
            return _context.Appointments.Where(c => c.fk_ProviderID == providerID && c.Active).ToList();
        }
        public List<Appointment> GetAppointmentsByPatientID(int patientID)
        {
            return _context.Appointments.Where(c => c.fk_PatientID == patientID && c.Active).ToList();
        }
        public Appointment GetAppointmentByID(int id)
        {
            return _context.Appointments.Where(c => c.ID == id && c.Active).FirstOrDefault();
        }
    }
}
