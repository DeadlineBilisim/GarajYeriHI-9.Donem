using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Abstract
{
    public interface IVehicleRepository:IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAll(bool isAdmin,int userId);

    }
}
