using GarajYeriHI.Models;
using GarajYeriHI.Repository.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Abstract
{
    public interface IVehiclePhotoRepository:IRepository<VehiclePhoto>
    {
        IEnumerable<VehiclePhoto> GetAll(Guid vehicleGuid);
    }
}
