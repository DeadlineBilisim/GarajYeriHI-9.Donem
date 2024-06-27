using GarajYeriHI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business.Abstract
{
    public interface IPolicyTypeService
    {
        IQueryable<PolicyType> GetAllPolicyType();
        PolicyType Add(PolicyType policyType);

        bool Delete(int policyTypeId);

        PolicyType Update(PolicyType policyType);

        PolicyType GetById(int policyTypeId);
    }
}
