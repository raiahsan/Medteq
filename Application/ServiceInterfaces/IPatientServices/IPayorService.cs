using Domain.Entities;
using Application.Dto.Lead;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.Patient;
using Application.General.Dto;

namespace Application.ServiceInterfaces.IPatientServices
{
    public interface IPayorService
    {
        bool UpdatePayorList();
    }
  
}
