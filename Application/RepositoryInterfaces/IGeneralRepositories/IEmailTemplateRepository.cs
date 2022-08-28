using Application.Dto.UserAccount;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces.IGeneralRepositories
{
    public interface IEmailTemplateRepository : IGenericRepository<EmailTemplate>
    {
        EmailTemplate GetEmailTemplateByName(string name);
    }
}
