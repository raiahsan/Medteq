using Application.Dto.Branch;
using Application.Helper;
using Application.RepositoryInterfaces;
using Application.RepositoryInterfaces.IGeneralRepositories;
using Application.RepositoryInterfaces.ILookupRepositories;
using Application.ServiceInterfaces;
using Application.ServiceInterfaces.ILookupServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.LookupServices
{
    public class BranchService : IBranchService
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IBranchRepository _branchRepository;
        private readonly IStateRepository _stateRepository;


        public BranchService(
            IMapper mapper,
            IBranchRepository branchRepository,
            IMemoryCache memoryCache,
            IStateRepository stateRepository)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
            _stateRepository = stateRepository;
        }

        public BranchDto GetBranchByID(int id)
        {
            var branches = _branchRepository.GetBranchById(id);
            return _mapper.Map<Branch, BranchDto>(branches);
        }

        public List<BranchDto> GetBranches()
        {
            var branches = _branchRepository.GetAllBranches();
            return _mapper.Map<List<Branch>, List<BranchDto>>(branches);
        }

        public async Task<Branch> UpsertBranch(BranchDto branchDto)
        {
            try
            {
                Branch branch = null;
                if (branchDto.ID == 0)
                {
                    branch = new Branch
                    {
                        BranchName = branchDto.BranchName,
                        BranchNumber = branchDto.BranchNumber,
                        fk_StateID = _stateRepository.GetState(branchDto.State)?.ID,
                        AddressLine1 = branchDto.AddressLine1,
                        AddressLine2 = branchDto.AddressLine2,
                        City = branchDto.City,
                        Region = branchDto.Region,
                        Active = branchDto.Active,
                        Fax = branchDto.Fax,
                        PostalCode = branchDto.PostalCode,
                        TaxID = branchDto.TaxID,
                        NPI = branchDto.NPI,
                        TaxonomyCode = branchDto.TaxonomyCode,
                        Phone = branchDto.Phone.RemoveSpecialCharacters(),
                    };
                    await _branchRepository.Add(branch);
                }
                else
                {
                    branch = _branchRepository.GetBranchById(branchDto.ID);
                    if (branch != null)
                    {
                        branch.BranchName = branchDto.BranchName;
                        branch.BranchNumber = branchDto.BranchNumber;
                        branch.AddressLine1 = branchDto.AddressLine1;
                        branch.AddressLine2 = branchDto.AddressLine2;
                        branch.City = branchDto.City;
                        branch.Region = branchDto.Region;
                        branch.Active = branchDto.Active;
                        branch.Fax = branchDto.Fax;
                        branch.PostalCode = branchDto.PostalCode;
                        branch.TaxID = branchDto.TaxID;
                        branch.NPI = branchDto.NPI;
                        branch.TaxonomyCode = branchDto.TaxonomyCode;
                        branch.Phone = branch.Phone;
                        _branchRepository.Update(branch);
                    }
                }
                _branchRepository.Complete();
                return branch;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
