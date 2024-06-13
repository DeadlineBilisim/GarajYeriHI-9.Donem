using GarajYeriHI.Data;
using GarajYeriHI.Models;
using GarajYeriHI.Repository.Abstract;
using GarajYeriHI.Repository.Shared.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarajYeriHI.Repository.Concrete
{
    public class PolicyRepository:Repository<Policy>,IPolicyRepository
    {
      //  private readonly ApplicationDbContext _context;
        private readonly IVehiclePhotoRepository _vehiclePhotoRepository;
        public PolicyRepository(ApplicationDbContext context, IVehiclePhotoRepository vehiclePhotoRepository) : base(context)
        {
       //     _context = context;
            _vehiclePhotoRepository = vehiclePhotoRepository;
        }

        public IEnumerable<Policy> GetAll(Guid vehicleId)
        {
           // _context.Vehicles.FirstOrDefault(v => v.Guid == vehicleId).Id;
            ;
           return base.GetAll(p => p.VehicleId == _vehiclePhotoRepository.GetByGuid(vehicleId).Id);
        }
    }
}
