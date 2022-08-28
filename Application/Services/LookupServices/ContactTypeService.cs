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
using Application.Dto.ContactType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Domain.Constants;
using Application.RepositoryInterfaces.ILookupRepositories;
using Application.ServiceInterfaces.ILookupServices;

namespace Application.Services.LookupServices
{
    public class ContactTypeService : IContactTypeService
    {
        private readonly IMapper _mapper;
        private readonly IContactTypeRepository _contactTypeRepository;
        private readonly IMemoryCache _memoryCache;

        public ContactTypeService(
            IMapper mapper,
            IContactTypeRepository contactTypeRepository,
            IMemoryCache memoryCache)
        {
            _contactTypeRepository = contactTypeRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public async Task<ContactType> UpsertContactType(ContactTypeDto contactTypeDto)
        {
            try
            {
                ContactType contactType = null;
                if (contactTypeDto.ID == 0)
                {
                    contactType = new ContactType
                    {
                        Type = contactTypeDto.Type,
                        Active = contactTypeDto.Active
                    };
                    await _contactTypeRepository.Add(contactType);
                }
                else
                {
                    contactType = _contactTypeRepository.GetContactType(contactTypeDto.ID);
                    if (contactType != null)
                    {
                        contactType.Type = contactTypeDto.Type;
                        contactType.Active = contactTypeDto.Active;
                        _contactTypeRepository.Update(contactType);
                    }
                }
                _contactTypeRepository.Complete();
                _memoryCache.Remove(CacheKey.ContactTypes);
                return contactType;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ContactTypeDto> GetContactTypes()
        {
            var contacts = _contactTypeRepository.GetAllContactTypes();
            return _mapper.Map<List<ContactType>, List<ContactTypeDto>>(contacts);

        }

        public ContactTypeDto GetContactTypesByID(int id)
        {
            var contacts = _contactTypeRepository.GetContactType(id);
            return _mapper.Map<ContactType, ContactTypeDto>(contacts);

        }
    }
}
