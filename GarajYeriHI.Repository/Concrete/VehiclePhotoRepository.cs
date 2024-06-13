using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using GarajYeriHI.Repository.Shared.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Concrete
{
    public class VehiclePhotoRepository:Repository<VehiclePhoto>,IVehiclePhotoRepository
    {
          private readonly IVehicleRepository _vehicleRepository;


        public VehiclePhotoRepository(ApplicationDbContext context, IVehicleRepository vehicleRepository) : base(context)
        {
            _vehicleRepository = vehicleRepository;
          
        }

        public IEnumerable<VehiclePhoto> GetAll(Guid vehicleGuid)
        {
            // _context.Vehicles.FirstOrDefault(v => v.Guid == vehicleGuid);
          int vehicleId=  _vehicleRepository.GetByGuid(vehicleGuid).Id;

           return base.GetAll(vp=>vp.VehicleId==vehicleId);
            
        }
    }
}
