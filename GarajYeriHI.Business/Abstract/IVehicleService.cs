using GarajYeriHI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Business.Abstract
{
    public interface IVehicleService
    {
        IQueryable<Vehicle> GetAll(bool isAdmin, int userId);
        Vehicle Add(Vehicle vehicle);
        Vehicle Update(Vehicle vehicle);
        bool Delete(int vehicleId);
        Vehicle GetById(int vehicleId);

       bool DeleteVehiclesByUserId(int userId);
        Vehicle GetByGuid(Guid guid);
    }
}
