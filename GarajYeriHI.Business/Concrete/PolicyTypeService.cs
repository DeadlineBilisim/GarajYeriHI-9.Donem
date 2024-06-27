using GarajYeriHI.Business.Abstract;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business.Concrete
{
    public class PolicyTypeService : IPolicyTypeService
    {
        private readonly IRepository<PolicyType> _repo;

        public PolicyTypeService(IRepository<PolicyType> repo)
        {
            _repo = repo;
        }

        public PolicyType Add(PolicyType policyType)
        {
         return _repo.Add(policyType);
        }

        public bool Delete(int policyTypeId)
        {
          _repo.DeleteById(policyTypeId);
            return true;
        }

        public IQueryable<PolicyType> GetAllPolicyType()
        {
            return _repo.GetAll();
        }

        public PolicyType GetById(int policyTypeId)
        {
          return _repo.GetById(policyTypeId);
        }

        public PolicyType Update(PolicyType policyType)
        {
           return _repo.Update(policyType);
        }
    }
}
