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
    public class VehiclePhotoService : IVehiclePhotoService
    {
        private readonly IRepository<VehiclePhoto> _vehiclePhotoRepository;
        private readonly IVehicleService _vehicleService;

        public VehiclePhotoService(IRepository<VehiclePhoto> vehiclePhotoRepository, IVehicleService vehicleService)
        {
            _vehiclePhotoRepository = vehiclePhotoRepository;
            _vehicleService = vehicleService;
        }

        public bool Delete(int id)
        {
            _vehiclePhotoRepository.DeleteById(id);
            return true;
        }

        public IQueryable<VehiclePhoto> GetAll(Guid guid)
        {
          int vehicleId=  _vehicleService.GetByGuid(guid).Id;
            return _vehiclePhotoRepository.GetAll(vp => vp.VehicleId == vehicleId);
        }

        public VehiclePhoto Update(VehiclePhoto vehiclePhoto)
        {
           return _vehiclePhotoRepository.Delete(vehiclePhoto);
        }
    }
}
