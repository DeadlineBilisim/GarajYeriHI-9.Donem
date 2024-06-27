using GarajYeriHI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business.Abstract
{
    public interface IPolicyService
    {
        IQueryable<Policy> GetAllByUser(AppUser user);
        IQueryable<Policy> GetAllByVehicleGuid(Guid vehicleGuid);

        Policy Add(Policy policy);
        Policy Update(Policy policy);
        bool Delete(int policyId);
        Policy GetById(int policyId);
    }
}
